using HovLibrary.Library;
using HovLibrary.Window;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HovLibrary
{
    public partial class Login : Form
    {

        HovLibraryEntities db = new HovLibraryEntities();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox1.Text = "ghuriche0@skyrock.com";
            textBox2.Text = "25f43b1486ad95a1398e3eeb3d83bc4010015fcc9bedb35b432e00298d5021f7";
        }

         void Openform<T>(T form) where T : Form
         {
            form.Show();
            form.FormClosed += formClosed;
            Hide();
         }

         void formClosed(object sender , FormClosedEventArgs e)
         {
            Show();
         }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == string.Empty)
            {
                Alert.Error("Email Cannot Be Empty");
                return;
            }
            else if(textBox2.Text == string.Empty)
            {
                Alert.Error("Password Cannot Be Empty");
                return;
            }
            else
            {
                string email = textBox1.Text;
                string password = textBox2.Text;
                var emp = db.Employee.Where(f => f.email == email && f.password == password && f.deleted_at == null).FirstOrDefault();
                if(emp != null)
                {
                    Openform(new MainFrm());
                }
                else
                {
                    Alert.Error("Email or Password Incorrect");
                }
            }
        }
    }
}
