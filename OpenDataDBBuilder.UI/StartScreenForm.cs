using OpenDataDBBuilder.Business.DB;
using OpenDataDBBuilder.Business.DB.VO;
using OpenDataDBBuilder.Business.File.Util;
using OpenDataDBBuilder.Business.File.XML.Util;
using OpenDataDBBuilder.Business.VO;
using OpenDataDBBuilder.UI.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OpenDataDBBuilder.UI
{
    public partial class StartScreenForm : Form
    {
        private int step;
        private String filePath = "";
        private String templateFilePath = "";
        public Template Template { get; set; }
        private TableList tableList { get; set; }
        public String dbConnection { get; set; }
        DatabaseHelper dbHelper;
        String openFileDialogTitle = "openFileDialogTitleMsg";
        String openFileDialogTitleMsg = "";
        String testSuccess = "";
        String testFail = "";
        static Localization.Localization loc = new Localization.Localization();


        String msgErrorNoDataFile = "";
        String msgErrorInvalidDataFile = "";
        String msgInvalidExtension = "";
        String msgInvalidTemplateDataFile = "";
        String msgInvalidTemplateConnection = "";


        public StartScreenForm()
        {
            InitializeComponent();
            getDefaultValues();
            getLocalizedLabelsMessages();
            this.Icon = Properties.Resources.icooddb;
        }
       
        private void getLocalizedLabelsMessages()
        {
            CultureInfo language = Thread.CurrentThread.CurrentUICulture;

            openFileDialogTitleMsg = loc.getLocalizedResource(language, openFileDialogTitle);
            this.lblDB.Text = loc.getLocalizedResource(language, this.lblDB.Name);
            this.lblLanguage.Text = loc.getLocalizedResource(language, this.lblLanguage.Name);
            this.lblPassword.Text = loc.getLocalizedResource(language, this.lblPassword.Name);
            this.lblPort.Text = loc.getLocalizedResource(language, this.lblPort.Name);
            this.lblServer.Text = loc.getLocalizedResource(language, this.lblServer.Name);
            this.lblUser.Text = loc.getLocalizedResource(language, this.lblUser.Name);
            this.lblDatabase.Text = loc.getLocalizedResource(language, this.lblDatabase.Name);
            this.btnTest.Text = loc.getLocalizedResource(language, this.btnTest.Name);

            this.lblTextStepOne.Text = loc.getLocalizedResource(language, this.lblTextStepOne.Name);
            this.lblTextStepTwo.Text = loc.getLocalizedResource(language, this.lblTextStepTwo.Name);
            this.lblTextStepThree.Text = loc.getLocalizedResource(language, this.lblTextStepThree.Name);

            this.btnBackStep.Text = loc.getLocalizedResource(language, this.btnBackStep.Name);
            this.btnNextStep.Text = loc.getLocalizedResource(language, this.btnNextStep.Name);
            this.btnFinish.Text = loc.getLocalizedResource(language, this.btnFinish.Name);

            this.lblDataFile.Text = loc.getLocalizedResource(language, this.lblDataFile.Name);
            this.lblTemplateFile.Text = loc.getLocalizedResource(language, this.lblTemplateFile.Name);
            this.btnOpenFile.Text = loc.getLocalizedResource(language, this.btnOpenFile.Name);
            this.btnOpenTemplate.Text = loc.getLocalizedResource(language, this.btnOpenFile.Name);
            this.lblDataFileHelp.Text = loc.getLocalizedResource(language, this.lblDataFileHelp.Name);
            this.lblTemplateHelp.Text = loc.getLocalizedResource(language, this.lblTemplateHelp.Name);

            msgErrorNoDataFile = loc.getLocalizedResource(language, "msgErrorNoDataFile");
            msgErrorInvalidDataFile = loc.getLocalizedResource(language, "msgErrorInvalidDataFile");
            msgInvalidExtension = loc.getLocalizedResource(language, "msgInvalidExtension");
            msgInvalidTemplateDataFile = loc.getLocalizedResource(language, "msgInvalidTemplateDataFile");
            msgInvalidTemplateConnection = loc.getLocalizedResource(language, "msgInvalidTemplateConnection");

            testSuccess = loc.getLocalizedResource(language, "testSuccess").Replace("{0}", Environment.NewLine);
            testFail = loc.getLocalizedResource(language, "testFail").Replace("{0}", Environment.NewLine);
        }

        private void getDefaultValues()
        {
            this.cmbLanguage.DataSource = getLanguageComoboList();
            this.cmbLanguage.ValueMember = "key";
            this.cmbLanguage.DisplayMember = "value";
            this.cmbLanguage.SelectedIndex = 1;
            this.cmbDB.SelectedIndex = 0;
            this.pnlCurrentStep.BorderStyle = BorderStyle.None;
            step = 0;
            updateStep(1);
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
        
        private void showErrorInfoWindow(String msg)
        {
            InfoErrorDialogForm error = new InfoErrorDialogForm(true, msg);
            error.StartPosition = FormStartPosition.CenterScreen;
            error.ShowDialog();
            error.Dispose();
        }
        private void showInfoWindow(String msg)
        {
            InfoErrorDialogForm info = new InfoErrorDialogForm(false, msg);
            info.StartPosition = FormStartPosition.CenterScreen;
            info.ShowDialog();
            info.Dispose();
        }

        private void StartScreenForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnNextStep_Click(object sender, EventArgs e)
        {
            if (step < 3)
                updateStep(1);
        }
        private void btnBackStep_Click(object sender, EventArgs e)
        {
            if (step > 1)
                updateStep(-1);
        }
        private void updateStep(int update)
        {
            if ((update == 1 && validateStep()) || update == -1)
                step += update;
                switch (step)
                {
                    case 1:
                        ptbStep.Image = Properties.Resources.imgstep01;
                        this.btnBackStep.Enabled = false;
                        this.btnFinish.Enabled = false;

                        if (pnlCurrentStep.Controls.Contains(pnlStepTwo))
                        {
                            pnlCurrentStep.Controls.Remove(pnlStepTwo);
                            gpbSettingsSteps.Controls.Add(pnlStepTwo);
                            pnlStepTwo.Location = new Point(66, 18);
                            pnlStepTwo.Size = new System.Drawing.Size(35,30);
                            pnlStepTwo.Visible = false;
                        }
                        pnlStepOne.Visible = true;
                        pnlStepOne.BorderStyle = BorderStyle.None;
                        pnlCurrentStep.Controls.Add(pnlStepOne);
                        pnlStepOne.Dock = DockStyle.Fill;
                    break;
                    case 2:
                        ptbStep.Image = Properties.Resources.imgstep02;
                        this.btnBackStep.Enabled = true;
                        this.btnNextStep.Enabled = true;
                        this.btnFinish.Enabled = false;
                        
                        if (pnlCurrentStep.Controls.Contains(pnlStepOne))
                        {
                            pnlCurrentStep.Controls.Remove(pnlStepOne);
                            gpbSettingsSteps.Controls.Add(pnlStepOne);
                            pnlStepOne.Location = new Point(30, 27);
                            pnlStepOne.Size = new System.Drawing.Size(10, 12);
                            pnlStepOne.Visible = false;
                        }

                        if (pnlCurrentStep.Controls.Contains(pnlStepThree))
                        {
                            pnlStepThree.Controls.Remove(pnlStepThree);
                            gpbSettingsSteps.Controls.Add(pnlStepThree);
                            pnlStepThree.Location = new Point(130, 9);
                            pnlStepThree.Size = new System.Drawing.Size(45, 39);
                            pnlStepThree.Visible = false;
                        }

                        pnlCurrentStep.Controls.Add(pnlStepTwo);
                        pnlStepTwo.BorderStyle = BorderStyle.None;
                        pnlStepTwo.Visible = true;
                        pnlStepTwo.Dock = DockStyle.Fill;
                        
                    break;
                    case 3:
                        ptbStep.Image = Properties.Resources.imgstep03;
                        this.btnNextStep.Enabled = false;
                        if (this.Template != null
                            && this.Template.DBconfig != null)
                        {
                            this.txbServer.Text = this.Template.DBconfig.Server;
                            this.txbPort.Text = this.Template.DBconfig.Port;
                            this.txbUser.Text = this.Template.DBconfig.User;
                            this.txbPassword.Text = this.Template.DBconfig.Password; 
                        }

                        if (pnlCurrentStep.Controls.Contains(pnlStepTwo))
                        {
                            pnlCurrentStep.Controls.Remove(pnlStepTwo);
                            gpbSettingsSteps.Controls.Add(pnlStepTwo);
                            pnlStepTwo.Location = new Point(66, 18);
                            pnlStepTwo.Size = new System.Drawing.Size(35, 30);
                            pnlStepTwo.Visible = false;
                        }

                        pnlCurrentStep.Controls.Add(pnlStepThree);
                        pnlStepThree.BorderStyle = BorderStyle.None;
                        pnlStepThree.Visible = true;
                        pnlStepThree.Dock = DockStyle.Fill;

                    break;
                }
        }

        private Boolean validateStep()
        {
             switch (step)
             {
                case 1:
                     if (this.txbDataFilePath.Text == null || "".Equals(this.txbDataFilePath.Text))
                     {
                        showErrorInfoWindow(msgErrorNoDataFile);
                        return false;
                     }                        
                break;
                case 2:
                if (this.cmbDB.SelectedItem != null && !"".Equals(this.cmbDB.SelectedItem.ToString()))
                {
                    DBConfig dbconfig = new DBConfig();
                    String db = this.cmbDB.SelectedItem.ToString();
                    this.Template = this.Template == null ? new Template(null, new DBConfig()) : this.Template;
                    this.Template.DBconfig = this.Template.DBconfig == null ? new DBConfig() : this.Template.DBconfig; 
                    this.Template.DBconfig.Db = db;
                    dbHelper = new DatabaseHelper(this.Template.DBconfig);
                    updateCmbDBsItems(false);
                }
                else
                    return false;
                break;
                case 3:
                    
                break;
             }
            return true;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            DatabaseHelper dbHelper = new DatabaseHelper(this.Template.DBconfig);
            this.Template.DBconfig.Db = cmbDB.SelectedItem.ToString();
            this.Template.DBconfig.Server = txbServer.Text;
            this.Template.DBconfig.Port = txbPort.Text;
            this.Template.DBconfig.User = txbUser.Text;
            this.Template.DBconfig.Password = txbPassword.Text;

            if (dbHelper.isConnectionAvailableNoDB(this.Template.DBconfig))
            {
                this.lblTestResult.Text = testSuccess;
                this.lblTestResult.ForeColor = System.Drawing.Color.Green;
                this.btnAddDB.Enabled = true;
                this.cmbDBs.Enabled = true;
                this.lblDatabase.Enabled = true;
                updateCmbDBsItems(false);
            }
            else
            {
                this.lblTestResult.Text = testFail;
                this.lblTestResult.ForeColor = System.Drawing.Color.Red;
                this.btnAddDB.Enabled = false;
                this.cmbDBs.Enabled = false;
                this.lblDatabase.Enabled = false;
            }
        }
        private void updateCmbDBsItems(bool select)
        {
            cmbDBs.Items.Clear();
            cmbDBs.Text = "";
            cmbDBs.SelectedIndex = -1;
            dbHelper = new DatabaseHelper(this.Template.DBconfig);
            List<String> dbList = dbHelper.selectDataBases();
            foreach (String s in dbList)
            {
                int index = cmbDBs.Items.Add(s);
                if (select && s.Equals(this.Template.DBconfig.DbName))
                    cmbDBs.SelectedIndex = index;
            }
        }

        private List<String> listDataBases()
        {
            return dbHelper.selectDataBases();
        }

        private void cmbDBs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDBs.SelectedItem != null && !"".Equals(this.cmbDBs.SelectedItem.ToString()))
            {
                this.btnFinish.Enabled = true;
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (step == 3)
            {
                if (cmbDBs.SelectedItem != null && !"".Equals(cmbDBs.SelectedItem.ToString()))
                    this.Template.DBconfig.DbName = cmbDBs.SelectedItem.ToString();
                this.Template.DBconfig.Server = this.txbServer.Text;
                this.Template.DBconfig.Port = this.txbPort.Text;
                this.Template.DBconfig.User = this.txbUser.Text;
                this.Template.DBconfig.Password = this.txbPassword.Text; 
            }
            TablesForm tablesForm = new TablesForm(tableList, this);
            tablesForm.Show();
            this.Hide();
        }

        private void btnOpenFile_Click_1(object sender, EventArgs e)
        {
            String validationMsg = "";
            openDataFileDialog = new OpenFileDialog();
            openDataFileDialog.Filter = "(*.csv, *.txt)|*.csv;*.txt";//"(*.xml, *.csv, *.txt)|*.xml;*.csv;*.txt"  "|*.xml;*.csv;*.txt";
            openDataFileDialog.Title = openFileDialogTitleMsg;
            DialogResult result = openDataFileDialog.ShowDialog();
            if ("OK".Equals(result.ToString()))
            {
                filePath = openDataFileDialog.FileName.ToString();

                if (filePath.EndsWith("XML") || filePath.EndsWith("xml"))
                {
                    if (XMLFileUtil.IsValidXML(filePath, out validationMsg))
                    {
                        this.txbDataFilePath.Text = filePath;
                        this.lblTemplateFile.Enabled = true;
                        this.lblTemplateHelp.Enabled = true;
                        this.txbTemplateFilePath.Text = "";
                        this.txbTemplateFilePath.Enabled = true;
                        this.btnOpenTemplate.Enabled = true;
                        //openFileDialog.Dispose();
                        //List<Table> tables = XMLFileUtil.getTablesFromXMLFileNew(filePath);
                       // TablesForm tablesForm = new TablesForm(tables, this);
                       // tablesForm.Show();
                       // this.Hide();
                    }
                    else
                    {
                        filePath = "";
                        this.lblTemplateFile.Enabled = false;
                        this.lblTemplateHelp.Enabled = false;
                        this.txbTemplateFilePath.Text = "";
                        this.txbTemplateFilePath.Enabled = false;
                        this.btnOpenTemplate.Enabled = false;
                        showErrorInfoWindow(msgErrorInvalidDataFile + ":" + System.Environment.NewLine + validationMsg);
                    }
                }
                else if ((filePath.EndsWith("CSV") || filePath.EndsWith("csv"))
                    || (filePath.EndsWith("TXT") || filePath.EndsWith("txt")))
                {
                    
                    this.txbDataFilePath.Text = filePath;
                    this.lblTemplateFile.Enabled = true;
                    this.lblTemplateHelp.Enabled = true;
                    this.txbTemplateFilePath.Text = "";
                    this.txbTemplateFilePath.Enabled = true;
                    this.btnOpenTemplate.Enabled = true;
                   
                   Table table = FileUtil.getTableFromFile(filePath);
                   List<Table> tables = new List<Table>();
                   tables.Add(table);
                   tableList = new TableList(tables);
                  // TablesForm tablesForm = new TablesForm(tables, this);
                  //  tablesForm.Show();
                   // this.Hide();
                }
                else
                {
                    filePath = "";
                    this.lblTemplateFile.Enabled = false;
                    this.lblTemplateHelp.Enabled = false;
                    this.txbTemplateFilePath.Text = "";
                    this.txbTemplateFilePath.Enabled = false;
                    this.btnOpenTemplate.Enabled = false;
                    showErrorInfoWindow(msgErrorInvalidDataFile + ":" + System.Environment.NewLine + msgInvalidExtension);
                }
            }
        }

        private void btnOpenTemplate_Click(object sender, EventArgs e)
        {
            openTemplateFileDialog.Filter = "(*.oddb)|*.oddb";
            openTemplateFileDialog.Title = openFileDialogTitleMsg;
            DialogResult result = openTemplateFileDialog.ShowDialog();
            Cursor.Current = Cursors.WaitCursor;
            if ("OK".Equals(result.ToString()))
            {
                templateFilePath = openTemplateFileDialog.FileName.ToString();
                try
                {
                    bool errorData = false;
                    bool errorConnection = false;
                    Template = new TemplateFileUtil().getTemplateFile(templateFilePath);
                    if (validateTemplateFileTable())
                        readTemplateIntoTableList();
                    else
                        errorData = true;

                    if (validateTemplateFileConnection())
                    {
                        this.btnFinish.Enabled = true;
                        this.btnNextStep.Enabled = false;
                    }
                    else
                    {
                        errorConnection = true;
                        templateFilePath = "";
                        this.btnFinish.Enabled = false;
                        this.btnNextStep.Enabled = true;
                    }
                    if (errorData || errorConnection)
                        if (errorData)
                            showInfoWindow(msgInvalidTemplateDataFile);
                        else
                            showErrorInfoWindow(msgInvalidTemplateConnection);
                    
                }
                catch (Exception)
                {
                    showErrorInfoWindow(msgInvalidTemplateConnection);
                }
            }
            else
            {
                templateFilePath = "";
                this.btnFinish.Enabled = false;
                this.btnNextStep.Enabled = true;
            }
            this.txbTemplateFilePath.Text = templateFilePath;

        }

        private Boolean validateTemplateFileConnection()
        {
            if (Template != null)
            {
                if (Template.DBconfig != null && Template.DBconfig.Db != null && !"".Equals(Template.DBconfig.Db))
                {
                    dbHelper = new DatabaseHelper(Template.DBconfig);
                    return dbHelper.isConnectionAvailable(Template.DBconfig); 
                }
                             
            }
            return false;
        }
        private Boolean validateTemplateFileTable()
        {
            if (Template != null)
            {
                if (Template.TableList != null && Template.TableList.Tables != null && Template.TableList.Tables.Count > 0)
                {
                    if (Template.TableList.TablesNames.Count != tableList.TablesNames.Count)
                    {
                        return false;
                    }
                    foreach (Table t in tableList.Tables)
                    {
                        foreach (Table tl in Template.TableList.Tables)
                        {
                            if (tl.Columns.Count != t.Columns.Count)
                            {
                                return false;
                            }
                        }
                    }
                }
                else
                {
                    return false;
                } 
            }
            return true;
        }

        private void readTemplateIntoTableList()
        {
            foreach (Table t in tableList.Tables)
            {
                foreach (Table tl in Template.TableList.Tables)
                {
                    if (t.OriginalTableName.Equals(tl.OriginalTableName))
                    {
                        t.TableName = tl.TableName;
                        foreach (Column c in t.Columns)
                        {
                            foreach (Column cl in tl.Columns)
                            {
                                if (c.OriginalColumnName.Equals(cl.OriginalColumnName))
                                {
                                    c.ColumnName = cl.ColumnName;
                                    c.IsPK = cl.IsPK;
                                    c.IsFK = cl.IsFK;
                                    c.Reference = cl.Reference;
                                    c.sqlType = cl.sqlType;
                                    c.SKIP = cl.SKIP;
                                    c.IsNullable = cl.IsNullable;
                                    c.IsUnique = cl.IsUnique;
                                    c.defaulValue = cl.defaulValue;
                                    c.defaulValueOnError = c.defaulValueOnError;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnAddDB_Click(object sender, EventArgs e)
        {
            AddDBForm addDBForm = new AddDBForm(this.Template.DBconfig);
            DialogResult result = addDBForm.ShowDialog();
            if (DialogResult.OK.Equals(result))
            {
                this.Template.DBconfig.DbName = addDBForm.dbAdded != null && !"".Equals(addDBForm.dbAdded) ? addDBForm.dbAdded : this.Template.DBconfig.DbName;
                updateCmbDBsItems(true);
            }
        }

        private void btnFinish_EnabledChanged(object sender, EventArgs e)
        {
            if(this.btnFinish.Enabled)
                Cursor.Current = Cursors.Default;
        }
    }
}
