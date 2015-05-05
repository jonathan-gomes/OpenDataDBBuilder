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
    public partial class SQLPreviewForm : Form
    {
        public SQLPreviewForm(String SQL)
        {
            InitializeComponent();
            this.rtbSQL.Text = SQL;
            getLocalizedLabelsMessages();
        }

        private void getLocalizedLabelsMessages()
        {
            CultureInfo language = Thread.CurrentThread.CurrentUICulture;
            Localization.Localization loc = new Localization.Localization();
            this.Text = loc.getLocalizedResource(language,this.Name);
        }
    }
}
