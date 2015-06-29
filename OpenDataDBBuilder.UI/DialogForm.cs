using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using OpenDataDBBuilder.UI.Localization;

namespace OpenDataDBBuilder.UI
{
    public partial class DialogForm : Form
    {
        String message = "";
        public DialogForm(String message)
        {
            this.message = message;
            InitializeComponent();
            getLocalizedLabelsMessages();
            getDefaultValues();
        }

        private void getLocalizedLabelsMessages()
        {
            CultureInfo language = Thread.CurrentThread.CurrentUICulture;
            Localization.Localization loc = new Localization.Localization();
            this.btnOK.Text = loc.getLocalizedResource(language, this.btnOK.Name);
            this.btnCancel.Text = loc.getLocalizedResource(language, this.btnCancel.Name);
        }

        private void getDefaultValues()
        {
            this.Icon = Properties.Resources.icooddb;
            this.txbMessage.Text = message;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
