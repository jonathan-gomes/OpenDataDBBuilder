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
using OpenDataDBBuilder.Business.DB.VO;
using OpenDataDBBuilder.Business.VO;

using System.Globalization;
using System.Threading;
using OpenDataDBBuilder.UI.Localization;

namespace OpenDataDBBuilder.UI
{
    public partial class EditDBConnectionForm : Form
    {
        public DBConfig dbconfig { get; set; }
        String testSuccess = "";
        String testFail = "";
        DatabaseHelper dbHelper;
        public EditDBConnectionForm(DBConfig dbconfig)
        {
            this.dbconfig = dbconfig;
            InitializeComponent();
            getLocalizedLabelsMessages();
            getDefaultValues();
        }

        private void getLocalizedLabelsMessages()
        {
            CultureInfo language = Thread.CurrentThread.CurrentUICulture;
            Localization.Localization loc = new Localization.Localization();
            this.Text = loc.getLocalizedResource(language, this.Name).Replace("{0}", dbconfig.Db);
            this.lblPassword.Text = loc.getLocalizedResource(language, this.lblPassword.Name);
            this.lblPort.Text = loc.getLocalizedResource(language, this.lblPort.Name);
            this.lblServer.Text = loc.getLocalizedResource(language, this.lblServer.Name);
            this.lblUser.Text = loc.getLocalizedResource(language, this.lblUser.Name);
            this.btnSave.Text = loc.getLocalizedResource(language, this.btnSave.Name);
            this.btnTest.Text = loc.getLocalizedResource(language, this.btnTest.Name);
            testSuccess = loc.getLocalizedResource(language, "testSuccess").Replace("{0}",Environment.NewLine);
            testFail = loc.getLocalizedResource(language, "testFail").Replace("{0}", Environment.NewLine);
        }

        private void getDefaultValues()
        {
            this.Icon = Properties.Resources.icooddb;
            if (dbconfig != null && dbconfig.Db != null)
            {
                dbHelper = new DatabaseHelper(dbconfig);
                this.txbServer.Text = dbconfig.Server;
                this.txbPort.Text = dbconfig.Port;
                this.txbUser.Text = dbconfig.User;
                this.txbPassword.Text = dbconfig.Password;

                try
                {
                    updateCmbDBsItems(true);                     
                }
                catch (Exception ex)
                {
                    Console.Out.Write(ex.Message);
                }

                if (dbHelper.isConnectionAvailable(dbconfig))
                {
                    lblTestResult.Text = testSuccess;
                    this.lblTestResult.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblTestResult.Text = testFail;
                    this.lblTestResult.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            mapDbConfig();
            if (dbHelper.isConnectionAvailableNoDB(dbconfig))
            {
                lblTestResult.Text = testSuccess;
                this.lblTestResult.ForeColor = System.Drawing.Color.Green;                
                updateCmbDBsItems(false);
                this.lblDbName.Enabled = true;
                this.cmbDBs.Enabled = true;
            }
            else
            {
                lblTestResult.Text = testFail;
                this.lblTestResult.ForeColor = System.Drawing.Color.Red;
                cmbDBs.Items.Clear();
                this.lblDbName.Enabled = false;
                this.cmbDBs.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            mapDbConfig();
            this.Close();
        }

        private void mapDbConfig()
        {
            dbconfig.Server = txbServer.Text;
            dbconfig.Port = txbPort.Text;
            dbconfig.User = txbUser.Text;
            dbconfig.Password = txbPassword.Text;
        }

        private void updateCmbDBsItems(bool select)
        {
            cmbDBs.Items.Clear();
            cmbDBs.Text = "";
            cmbDBs.SelectedIndex = -1;
            dbHelper = new DatabaseHelper(dbconfig);
            List<String> dbList = dbHelper.selectDataBases();
            foreach (String s in dbList)
            {
                int index = cmbDBs.Items.Add(s);
                if (select && s.Equals(dbconfig.DbName))
                    cmbDBs.SelectedIndex = index;
            }    
        }

        private void btnAddDB_Click(object sender, EventArgs e)
        {
            AddDBForm addDBForm = new AddDBForm(dbconfig);
            DialogResult result = addDBForm.ShowDialog();
            if (DialogResult.OK.Equals(result))
            {
                dbconfig.DbName = addDBForm.dbAdded != null && !"".Equals(addDBForm.dbAdded) ? addDBForm.dbAdded : dbconfig.DbName;
                updateCmbDBsItems(true);
            }
        }
    }
}
