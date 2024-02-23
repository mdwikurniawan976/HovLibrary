using HovLibrary.Library;
using HovLibrary.Master;
using HovLibrary.Transaksi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HovLibrary.Window
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void memberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            MemberFrm member = new MemberFrm();
            member.MdiParent = this;
            member.Show();
        }

        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            BookFrm book = new BookFrm();
            book.MdiParent = this;
            book.Show();
        }

        private void newBorrowingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            FrmAddNewBorrowing add = new FrmAddNewBorrowing();
            add.MdiParent = this;
            add.Show();
        }

        private void allBorrowingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            AllBorrowingFrm all = new AllBorrowingFrm();
            all.MdiParent = this;
            all.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Alert.Confirm("Are you sure you want to logout of this form ?") == DialogResult.Yes)
            {
                new Login().Show();
                Dispose();
            }
       }
    }
}
