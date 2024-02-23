using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HovLibrary.Transaksi
{
    public partial class AllBorrowingFrm : Form
    {
        DateTime first;
        DateTime last;
        string status;

        HovLibraryEntities db = new HovLibraryEntities();   
        public AllBorrowingFrm()
        {
            InitializeComponent();
        }

        void filter()
        {
            var borrow = db.Borrowing.Where(x => x.deleted_at == null);
            if(first == null || last == null || status == null)
            {
                bindingSource1.DataSource = borrow.ToList();
            }

            var a = borrow.Where(c=> DbFunctions.TruncateTime(c.borrow_date) >= first && DbFunctions.TruncateTime(c.borrow_date) <= last);

            if (status == "Late")
                a = a.Where(b => DbFunctions.DiffDays(b.borrow_date, DateTime.Now) > 7 && b.return_date == null);
            else if (status == "Ongoing")
                a = a.Where(z => DbFunctions.DiffDays(z.borrow_date, DateTime.Now) >= 7 && z.return_date == null);
            else if(status == "Returned")
                a = a.Where(c=> c.return_date != null);

            bindingSource1.DataSource= a.ToList();
        }
        private void AllBorrowingFrm_Load(object sender, EventArgs e)
        {
            filter();
            comboBox1.DataSource = new List<string> { "Ongoing", "Late", "Returned" };
            var firstDate = db.Borrowing.OrderBy(x => x.borrow_date).Select(x => x.borrow_date).First();
            var lastdate  =  db.Borrowing.OrderByDescending(x=> x.borrow_date).Select(x=> x.borrow_date).First();
            dateTimePicker1.Value = firstDate;
            dateTimePicker2.Value = lastdate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            first  = dateTimePicker1.Value;
            last = dateTimePicker2.Value;
            status = comboBox1.SelectedItem.ToString();
            filter();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Borrowing borrowing)
            {
                if (e.ColumnIndex == ReturnColumn.Index)
                {
                    if (borrowing.return_date != null) return;

                    if ((DateTime.Now - borrowing.borrow_date).Days > 7)
                        borrowing.fine = (DateTime.Now - borrowing.borrow_date).Days * 1000;
                    else
                        borrowing.fine = 0;

                    borrowing.return_date = DateTime.Now;
                    borrowing.last_updated_at = DateTime.Now;
                    db.SaveChanges();
                    filter();
                }   
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Borrowing borrowing)              
            {
                if (e.ColumnIndex == MemberColumn.Index)
                    e.Value = borrowing.Member.name;

                else if (e.ColumnIndex == BookTitlec.Index)
                    e.Value = borrowing.BookDetails.Book.title;

                else if (e.ColumnIndex == BookCodeColumn.Index)
                    e.Value = borrowing.BookDetails.code;

                else if (e.ColumnIndex == borrowdateDataGridViewTextBoxColumn.Index)
                    e.Value = borrowing.borrow_date.ToString("dd MM yyyy");

                else if (e.ColumnIndex == returndateDataGridViewTextBoxColumn.Index && borrowing.return_date is DateTime returnDate)
                    e.Value = returnDate.ToString("dd MM yyyy");

                else if (e.ColumnIndex == fineDataGridViewTextBoxColumn.Index && borrowing.fine is decimal fine)
                    e.Value = fine.ToString("#,##0");
                    
            }
        }
    }
}
