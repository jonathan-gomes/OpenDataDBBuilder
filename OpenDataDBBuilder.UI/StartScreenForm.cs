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

using OpenDataDBBuilder.Business.VO;
using OpenDataDBBuilder.Business.File.Util;
using OpenDataDBBuilder.Business.File.XML.Util;
using OpenDataDBBuilder.Business.DB.VO;
using OpenDataDBBuilder.Business.DB;

namespace OpenDataDBBuilder.UI
{
    public partial class StartScreenForm : Form
    {
        private String filePath = "";
        public String dbConnection { get; set; }
        public String Db { get; set; }

        String openFileDialogTitle = "openFileDialogTitleMsg";
        String openFileDialogTitleMsg = "";
        String validatingXMLMsg = "";
        String validatingXML = "validatingXML";
        static Localization.Localization loc = new Localization.Localization();
    
        public StartScreenForm()
        {
            InitializeComponent();
            getDefaultValues();
            getLocalizedLabelsMessages();
            this.Icon = Properties.Resources.icooddb;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            String validationMsg = "";
            openFileDialog.Filter = "|*.xml;*.csv;*.txt";
            openFileDialog.Title = openFileDialogTitleMsg;
            DialogResult result = openFileDialog.ShowDialog();
            if ("OK".Equals(result.ToString()))
            {
                filePath = openFileDialog.FileName.ToString();
                
                if(filePath.EndsWith("XML") || filePath.EndsWith("xml"))
                {
                    prepareComponentsToOpenFile();
                    updateProgressBar(validatingXMLMsg);
                    Application.DoEvents();
                    if (XMLFileUtil.IsValidXML(filePath, out validationMsg))
                    {
                        openFileDialog.Dispose();
                        List<Table> tables = XMLFileUtil.getTablesFromXMLFileNew(filePath);
                        TablesForm tablesForm = new TablesForm(tables, this);
                        tablesForm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    Table table = FileUtil.getTableFromFile(filePath);
                    List<Table> tables = new List<Table>();
                    tables.Add(table);
                    TablesForm tablesForm = new TablesForm(tables, this);
                    tablesForm.Show();
                    this.Hide();
                }
            }
        }


        private void updateProgressBar(String message)
        {
            txbProgress.Text = message;
            psbStarScreenProgress.Increment(10);
            Application.DoEvents();

        }
        private void prepareComponentsToOpenFile()
        {
            btnOpenFile.Enabled = false;
            psbStarScreenProgress.Visible = true;
            txbProgress.Visible = true;
            Application.DoEvents();
        }

        private void getLocalizedLabelsMessages()
        {
            CultureInfo language = Thread.CurrentThread.CurrentUICulture;
           
            this.btnOpenFile.Text = loc.getLocalizedResource(language, btnOpenFile.Name);

            openFileDialogTitleMsg = loc.getLocalizedResource(language, openFileDialogTitle);
            validatingXMLMsg = loc.getLocalizedResource(language, validatingXML);
            this.lblDB.Text = loc.getLocalizedResource(language, this.lblDB.Name);
            this.lblLanguage.Text = loc.getLocalizedResource(language, this.lblLanguage.Name);
            this.btnOKDB.Text = loc.getLocalizedResource(language, this.btnOKDB.Name);
        }

        private void getDefaultValues()
        {
            this.cmbLanguage.DataSource = getLanguageComoboList();
            this.cmbLanguage.ValueMember = "key";
            this.cmbLanguage.DisplayMember = "value";
            this.cmbLanguage.SelectedIndex = 1;
            this.cmbDB.SelectedIndex = 0;
        }

        private void cmbLanguage_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach(KeyValue lang in loc.languages)
            {
                if (cmbLanguage.SelectedValue.Equals(lang.Key))
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang.Key);
                    getLocalizedLabelsMessages();
                    return;
                }
                
            }
            
        }

        private IList<KeyValue> getLanguageComoboList()
        { 
            return loc.languages;
        }

        private void btnOKDB_Click(object sender, EventArgs e)
        {
            this.Db = cmbDB.Text;
            EditDBConnectionForm editDBConnectionForm = new EditDBConnectionForm(cmbDB.Text);
            DialogResult result = editDBConnectionForm.ShowDialog();
           if ("OK".Equals(result.ToString()))
            {
               this.dbConnection = editDBConnectionForm.dbConnection;
               this.btnOpenFile.Enabled = true;
            }
           editDBConnectionForm.Dispose();
        }

        private void showErrorInfoWindow(String msg)
        {
            InfoErrorDialogForm error = new InfoErrorDialogForm(true, msg);
            error.ShowDialog();
            error.Dispose();
        }
    }
}
