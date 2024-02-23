using HovLibrary.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HovLibrary.Master
{
    public partial class BooklistFrm : Form
    {
        HovLibraryEntities db = new HovLibraryEntities();
        Book book;
        int identity;
        public BooklistFrm(int id)
        {
            InitializeComponent();
            book = db.Book.Where(book=> book.id == id).FirstOrDefault();
            identity = db.BookDetails.OrderByDescending(x => x.id).FirstOrDefault(x => x.deleted_at == null).id + 1;
        }

        private void BooklistFrm_Load(object sender, EventArgs e)
        {
            identity = db.BookDetails.OrderByDescending(x => x.id).FirstOrDefault(x => x.deleted_at == null).id + 1;
            textBox1.Text = book.title;
            bindingSource1.DataSource = db.BookDetails.Where(f => f.id == book.id && f.deleted_at == null).ToList();
            LocationBindingSource.DataSource = db.Location.Where(f => f.deleted_at == null).ToList();
            bindingSource2.Clear();
            bindingSource2.AddNew();

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is BookDetails detail)
            {
                if(e.ColumnIndex == LocationColumn.Index)
                {
                    e.Value = detail.Location.name;
                }
                else if(e.ColumnIndex == StatusC.Index)
                {
                    e.Value = db.Borrowing.Where(c => c.bookdetails_id == detail.id && c.return_date == null).Count() > 0 ? "Unavailable" : "Available";
                }
            }
        }

        private void LocationBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if(LocationBindingSource.Current is Location locati && bindingSource2.Current is BookDetails detail)
            {
                detail.location_id = locati.id;
                textBox2.Text = identity.ToString("D4") + "." + book.id.ToString("D4") + "." + locati.id.ToString("D2") + "." + book.publication_date.Year;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(bindingSource2.Current is BookDetails detail)
            {
                detail.id = identity;
                detail.created_at = DateTime.Now;
                detail.code = textBox2.Text;

                db.BookDetails.AddOrUpdate(detail);
                db.SaveChanges();

                BooklistFrm_Load(sender, e);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is BookDetails detail)
            {
                if(e.ColumnIndex == DeleteColumn.Index)
                {
                    if(db.Borrowing.Where(f=> f.bookdetails_id == detail.id && f.return_date == null).Count() > 0)
                    {
                        Alert.Information("Cannot Delete because book still borrowed");
                        return;
                    }

                    if(Alert.Confirm("Are you sure to delete ?") == DialogResult.Yes)
                    {
                        detail.deleted_at = DateTime.Now;
                        db.SaveChanges();
                        BooklistFrm_Load(sender, e);
                    }
                }
            }
        }
    }
}
