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
    public partial class BookFrm : Form
    {
        string[] searchoption = { "", "Title", "Author", "Publisher" };
        string currentSearchOption;
        HovLibraryEntities db = new HovLibraryEntities();
        public BookFrm()
        {
            InitializeComponent();
        }

        void SetEnable(bool enable)
        {
            foreach (Control con in new List<Control> { comboBox13, textBox3, textBox4, textBox5, textBox6, comboBox14, textBox8, dateTimePicker3, textBox9, button3 })
            {
                if (con is TextBox text)
                    text.ReadOnly = !enable;
                else
                    con.Enabled = enable;
            }
        }

        void reset()
        {
            bindingSource1.DataSource = db.Book.Where(f => f.deleted_at == null).ToList();
            LanguageBindingSource.DataSource = db.Language.Where(f => f.deleted_at == null).ToList();
            LanguageBindingSource1.DataSource = db.Language.Where(f => f.deleted_at == null).ToList();
            PublisherBindingSource.DataSource = db.Publisher.Where(f => f.deleted_at == null).ToList();
            comboBox1.DataSource = searchoption;

            var pagerange = db.Book.Select(x => x.number_of_pages).Distinct();
            comboBox3.DataSource = pagerange.OrderBy(x => x).ToList();
            comboBox4.DataSource = pagerange.OrderByDescending(x => x).ToList();


            var ratingrange = db.Book.Select(x => x.average_rating).Distinct().ToList();
            comboBox5.DataSource = ratingrange.OrderBy(c => c).ToList();
            comboBox6.DataSource = ratingrange.OrderByDescending(c => c).ToList();

            var publisrange = db.Book.OrderBy(f => f.publication_date).Select(f => f.publication_date).First();
            var lastpublist = db.Book.OrderByDescending(f => f.publication_date).Select(f => f.publication_date).First();
            dateTimePicker1.Value = publisrange;
            dateTimePicker2.Value = lastpublist;
            SetEnable(false);
        }

        private void BookFrm_Load(object sender, EventArgs e)
        {
            reset();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(bindingSource2.Current is Book book)
            {
                var rate = textBox9.Text.Split('(');
                rate[1] = rate[1].Substring(0, rate[1].Length - 1);
                book.average_rating = Math.Round(float.Parse(rate[0]), 2);
                book.ratings_count = int.Parse(rate[1]);

                db.Book.AddOrUpdate(book);
                db.SaveChanges();
                reset();
            }
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Book book)
            {
                if (e.ColumnIndex == LanguageColumn.Index) e.Value = book.Language.long_text;

                else if (e.ColumnIndex == PublisherColumn.Index) e.Value = book.Publisher.name;

                else if (e.ColumnIndex == averageratingDataGridViewTextBoxColumn.Index) e.Value = book.average_rating + "( " + book.ratings_count + ")";

                else if (e.ColumnIndex == publicationdateDataGridViewTextBoxColumn.Index) e.Value = book.publication_date.ToString("dd MMM yyyy");
            }
        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {
            if (bindingSource2.Current is Book book)
            {
                textBox9.Text = book.average_rating + "(" + book.ratings_count + ")";
                
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            if(bindingSource1.Current is Book book)
            {
                bindingSource2.DataSource = db.Book.AsNoTracking().Where(f => f.id == book.id).ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (currentSearchOption == "Title")
                bindingSource1.DataSource = db.Book.Where(f => f.title.Contains(textBox1.Text) && f.deleted_at == null).ToList();
            else if (currentSearchOption == "Author")
                bindingSource1.DataSource = db.Book.Where(f => f.authors.Contains(textBox1.Text) && f.deleted_at == null).ToList();
            else if (currentSearchOption == "Publisher")    
                bindingSource1.DataSource = db.Book.Where(f => f.Publisher.name.Contains(textBox1.Text) && f.deleted_at == null).ToList();
            else
            {
                textBox1.Text = "";
                bindingSource1.DataSource = db.Book.Where(f => f.deleted_at == null).ToList();
            }
              

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem is string str  && !string.IsNullOrEmpty(str))
            {
                currentSearchOption = str;
                textBox1.Enabled = true;
                return;
            }

            textBox1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bindingSource1.DataSource = db.Book.Where(x => x.language_id == (int)comboBox2.SelectedValue &&
           x.publication_date > dateTimePicker1.Value && x.publication_date < dateTimePicker2.Value &&
           x.number_of_pages > (int)comboBox3.SelectedItem && x.number_of_pages < (int)comboBox4.SelectedItem && x.average_rating > (double)comboBox5.SelectedItem && x.average_rating < (double)comboBox6.SelectedItem && x.deleted_at == null).ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Book book)
            {
                if(e.ColumnIndex == EditColumn.Index)
                {
                    SetEnable(true);
                }
                else if(e.ColumnIndex == DeleteColumn.Index)
                {
                    book.deleted_at = DateTime.Now;
                    db.SaveChanges();
                    reset();   
                }

                else if(e.ColumnIndex == BooklistC.Index)
                {
                    new BooklistFrm(book.id).ShowDialog();
                      
                }

            }
        }
    }
}
