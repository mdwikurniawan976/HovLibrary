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
    public partial class MemberFrm : Form
    {

        HovLibraryEntities db = new HovLibraryEntities();

        public MemberFrm()
        {
            InitializeComponent();
        }

        private void MemberFrm_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = db.Member.Where(f => f.deleted_at == null).ToList();
            SetEnable(false);
        }

        void SetEnable(bool enable)
        {
            var list = new List<Control>
            {
                textBox1,textBox2,textBox3,textBox4,textBox5,dateTimePicker1,radioButton1,radioButton2,button1
            };

            foreach (Control c in list)
            {
                c.Enabled = enable; 
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            if(bindingSource1.Current is Member member)
            {
                bindingSource2.DataSource = db.Member.AsNoTracking().Where(f => f.id == member.id).ToList();
                SetEnable(false);

                if(member.gender == "Male")
                {
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                }
                else if (member.gender == "Female")
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(bindingSource2.Current is Member mem)
            {
                if (radioButton1.Checked)
                {
                    mem.gender = "Male";
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(bindingSource2.Current is Member mem)
            {
                if (radioButton2.Checked)
                {
                    mem.gender = "Female";
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].DataBoundItem is Member member)
            {
                if (e.ColumnIndex ==EditColumn.Index)
                {
                   // bindingSource2.DataSource = db.Member.AsNoTracking().Where(f => f.id == member.id).ToList();
                    SetEnable(true);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(bindingSource2.Current is Member mem)
            {
                foreach (string str in new List<string> { mem.name, mem.email, mem.phone_number, mem.address, mem.city_of_birth })
                {
                    if (!string.IsNullOrEmpty(str)) continue;
                    Alert.Information("Field Cannot Be Empty");
                    return;
                }

                db.Member.AddOrUpdate(mem);
                db.SaveChanges();

                MemberFrm_Load(sender, e);
            }
        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {
           /* if(bindingSource2.Current is Member m)
            {
                bindingSource1.Clear();
                bindingSource1.Add(m);
            }*/
        }
    }
}
