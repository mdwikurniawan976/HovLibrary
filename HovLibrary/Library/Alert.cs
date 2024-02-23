using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HovLibrary.Library
{
    public  class Alert
    {
        public static DialogResult Error(string text)
        {
            return MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult Information(string text)
        {
            return MessageBox.Show(text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult Confirm(string text)
        {
            return MessageBox.Show(text, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }
    }
}
