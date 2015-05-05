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
    public partial class InfoErrorDialogForm : Form
    {
        String error = "error";
        String info = "info";
        public InfoErrorDialogForm(Boolean isError, String msg)
        {
            InitializeComponent();
            getLocalizedLabelsMessages();
            if (isError)
            {
                ptbIconInfoError.Image = Properties.Resources.imgwarning;
                txbInfoError.Text = error + msg;
                this.Text = error;
            }
            else
            {
                ptbIconInfoError.Image = Properties.Resources.imginfo;
                txbInfoError.Text = info + msg;
                this.Text = info;
            }
        }

        private void getLocalizedLabelsMessages()
        {
            CultureInfo language = Thread.CurrentThread.CurrentUICulture;
            Localization.Localization loc = new Localization.Localization();
            error = loc.getLocalizedResource(language, error);
            info = loc.getLocalizedResource(language, info);
        }
    }
}
