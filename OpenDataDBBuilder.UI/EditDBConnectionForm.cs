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
using OpenDataDBBuilder.Business.DB;
using OpenDataDBBuilder.Business.File.Util;


namespace OpenDataDBBuilder.UI
{
    public partial class EditDBConnectionForm : Form
    {
        String db = "";
        String testFail = "";
        String testSuccess = "";
        String DBConfigPath = "";
        public String dbConnection { get; set; }

        public EditDBConnectionForm(String db)
        {
            this.db = db;
            this.dbConnection = "";
            InitializeComponent();
            getDefaultValues();
            getLocalizedLabelsMessages();
            this.Icon = Properties.Resources.icooddb;
        }

        private void getLocalizedLabelsMessages()
        {
            CultureInfo language = Thread.CurrentThread.CurrentUICulture;
            Localization.Localization loc = new Localization.Localization();

            this.Text = loc.getLocalizedResource(language, this.Name).Replace("{0}",db);
            this.lblPassword.Text = loc.getLocalizedResource(language, this.lblPassword.Name);
            this.lblPort.Text = loc.getLocalizedResource(language, this.lblPort.Name);
            this.lblServer.Text = loc.getLocalizedResource(language, this.lblServer.Name);
            this.lblUser.Text = loc.getLocalizedResource(language, this.lblUser.Name);
            this.btnSave.Text = loc.getLocalizedResource(language, this.btnSave.Name);
            this.btnTest.Text = loc.getLocalizedResource(language, this.btnTest.Name);
            testSuccess = loc.getLocalizedResource(language, "testSuccess");
            testFail = loc.getLocalizedResource(language, "testFail");
        }

        private void getDefaultValues()
        {
            this.lblTestResult.Text = "";
            string appPath = Application.StartupPath;
            DBConfigPath = appPath + "/DBConfig" + db + ".config";
            createDBConfigFile();
            readDBConfigFile();
        }

        private void btnTest_Click_1(object sender, EventArgs e)
        {
            DatabaseHelper dbHelper = new DatabaseHelper(db);
            StringBuilder conn = new StringBuilder("Server={0};Port={1};Uid={2};Pwd={3};");
            conn.Replace("{0}", txbServer.Text);
            conn.Replace("{1}", txbPort.Text);
            conn.Replace("{2}", txbUser.Text);
            conn.Replace("{3}", txbPassword.Text);

            if (dbHelper.isConnectionAvailable(db, conn.ToString()))
            {
                this.lblTestResult.Text = testSuccess;
                this.lblTestResult.ForeColor = System.Drawing.Color.Green;
                this.btnSave.Enabled = true;
            }
            else
            {
                this.lblTestResult.Text = testFail;
                this.lblTestResult.ForeColor = System.Drawing.Color.Red;
                this.btnSave.Enabled = false;
            }
        }

        private void createDBConfigFile()
        {
            string appPath = Application.StartupPath;
            FileUtil.createFile(DBConfigPath, "");
        }

        private void readDBConfigFile()
        {
            string appPath = Application.StartupPath;
            List<String> file = FileUtil.openFile(DBConfigPath);

            foreach (String s in file)
            {
                if (s.Contains("Server"))
                    this.txbServer.Text = s.Replace("Server=", "");
                if (s.Contains("Port"))
                    this.txbPort.Text = s.Replace("Port=", "");
                if (s.Contains("User"))
                    this.txbUser.Text = s.Replace("User=", "");
                if (s.Contains("Password"))
                    this.txbPassword.Text = s.Replace("Password=", "");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string appPath = Application.StartupPath;
            String file = "";
            file += "Server="+txbServer.Text+"\n";
            file += "Port=" + txbPort.Text + "\n";
            file += "User=" + txbUser.Text + "\n";
            file += "Password=" + txbPassword.Text + "\n";
            FileUtil.overWriteFile(DBConfigPath, file);
            this.dbConnection += "Server=" + txbServer.Text+";";
            this.dbConnection += "Port=" + txbPort.Text + ";";
            this.dbConnection += "User=" + txbUser.Text + ";";
            this.dbConnection += "Password=" + txbPassword.Text + ";";
            this.Close();
        }
    }
}
