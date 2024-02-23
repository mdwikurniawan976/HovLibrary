using HovLibrary.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HovLibrary.Transaksi
{
    public partial class FrmAddNewBorrowing : Form
    {
        HovLibraryEntities db = new HovLibraryEntities();
        List<BookDetails> books = new List<BookDetails>();  
        public FrmAddNewBorrowing()
        {
            InitializeComponent();
        }

        void search (string key)
        {
            bindingSource1.DataSource = db.BookDetails.Where(detail => detail.deleted_at == null && detail.Borrowing.Where(v => v.return_date == null).Count() <= 0 && detail.Book.title.Contains(key)).ToList();
        }
        private void FrmAddNewBorrowing_Load(object sender, EventArgs e)
        {
            var titlesource = new AutoCompleteStringCollection();
            titlesource.AddRange(db.Book.Where(f => f.deleted_at == null).Select(f => f.title).ToArray());
            textBox1.AutoCompleteCustomSource = titlesource;

            var memberSource = new AutoCompleteStringCollection();
            memberSource.AddRange(db.Member.Where(f=> f.deleted_at == null).Select(f=> f.name).ToArray());
            textBox2.AutoCompleteCustomSource = memberSource;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            search(textBox1.Text);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is BookDetails detail)
            {
                if (e.ColumnIndex == locationidDataGridViewTextBoxColumn.Index) e.Value = detail.Location.name;
                else if (e.ColumnIndex == StatusColumn.Index)
                {
                    e.Value = db.Borrowing.Where(f => f.bookdetails_id == detail.id && f.return_date == null).Count() < 0 ? "Unavailable" : "Available";
                }
                else if (e.ColumnIndex == Check.Index)
                {
                    if (!books.Contains(detail)) return;
                    var check = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    check.Value = true;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is BookDetails detail)
            {
                if(e.ColumnIndex == Check.Index)
                {
                    var check = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    if(check ==  null)
                    {
                        books.Add(detail);
                        check.Value = true;                      
                    }
                    else
                    {
                        books.Remove(detail);
                        check.Value = null;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedmember = db.Member.FirstOrDefault(x => x.name == textBox2.Text);

            if (selectedmember != null)
            {
                Alert.Error("Member Not Found");
                return;
            }

            if(books.Count == 0)
            {
                Alert.Error("Please select book");
                return;
            }

            foreach (var book in books)
            {
                Borrowing borrow = new Borrowing
                {
                    member_id = selectedmember.id,
                    bookdetails_id = book.id,
                    borrow_date = DateTime.Now,
                    created_at = DateTime.Now,
                };

                db.Borrowing.Add(borrow);
            }
            db.SaveChanges();
            books.Clear();
            search("");
            textBox2.Clear();
            FrmAddNewBorrowing_Load(sender, e);
        }
    }
}
