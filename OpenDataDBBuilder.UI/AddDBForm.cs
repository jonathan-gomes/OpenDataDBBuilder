using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenDataDBBuilder.Business.DB;
using OpenDataDBBuilder.Business.VO;

using System.Globalization;
using System.Threading;
using OpenDataDBBuilder.UI.Localization;

namespace OpenDataDBBuilder.UI
{
    public partial class AddDBForm : Form
    {
        DatabaseHelper dbHelper;
        public String dbAdded { get; set; }
        public DBConfig dbconfig { get; set; }
        public AddDBForm(DBConfig dbconfig)
        {
            this.dbconfig = dbconfig;
            dbHelper = new DatabaseHelper(dbconfig);
            InitializeComponent();
            getDefaultValues();
            getLocalizedLabelsMessages();
        }

        private void getDefaultValues()
        {
            this.Icon = Properties.Resources.icooddb;
        }

        private void getLocalizedLabelsMessages()
        {
            CultureInfo language = Thread.CurrentThread.CurrentUICulture;
            Localization.Localization loc = new Localization.Localization();
            this.Text = loc.getLocalizedResource(language, this.Name);
        }

        private void btnOKAddDB_Click(object sender, EventArgs e)
        {
            if (txbAddDB.Text != null && !txbAddDB.Text.Equals(""))
            {
                dbAdded = txbAddDB.Text;
                String addDBReturn = dbHelper.addDatabase(txbAddDB.Text);
                if (addDBReturn != null && !addDBReturn.Equals(""))
                {
                    showInfoErrorForm(addDBReturn);
                    dbAdded = "";
                }
                   
                this.Close();
            }
           
        }

        private void showInfoErrorForm(String msg)
        {
            InfoErrorDialogForm infoErrorDialogForm = new InfoErrorDialogForm(true, msg);
            infoErrorDialogForm.StartPosition = FormStartPosition.CenterScreen;
            infoErrorDialogForm.ShowDialog();
            infoErrorDialogForm.Dispose();
        }
    }
}
