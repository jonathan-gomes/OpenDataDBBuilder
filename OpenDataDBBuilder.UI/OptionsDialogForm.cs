using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenDataDBBuilder.UI
{
    public partial class OptionsDialogForm : Form
    {
        private int linesPerPage;

        public OptionsDialogForm()
        {
            InitializeComponent();
        }

        public OptionsDialogForm(int pages)
        {
            InitializeComponent();
            mtbLinesPage.Text = pages.ToString();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            copyValueFromMaskedTxb();              
        }

        public int getLinesPerPage()
        {
           return linesPerPage;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            copyValueFromMaskedTxb();
        }

        private void copyValueFromMaskedTxb()
        {
            int aux;
            if (int.TryParse(mtbLinesPage.Text, out aux))
            {
                linesPerPage = int.Parse(mtbLinesPage.Text);
            }
            else
            {
                String msg = "Invalid value!";
                InfoErrorDialogForm infoErrorDialog = new InfoErrorDialogForm(true, msg);
                infoErrorDialog.ShowDialog();
            }
        }
    }
}
