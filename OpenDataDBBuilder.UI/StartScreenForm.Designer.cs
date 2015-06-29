namespace OpenDataDBBuilder.UI
{
    partial class StartScreenForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ptbTitle = new System.Windows.Forms.PictureBox();
            this.cmbDB = new System.Windows.Forms.ComboBox();
            this.lblDB = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.openDataFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.gpbSettingsSteps = new System.Windows.Forms.GroupBox();
            this.pnlStepThree = new System.Windows.Forms.Panel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddDB = new System.Windows.Forms.Button();
            this.cmbDBs = new System.Windows.Forms.ComboBox();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblTestResult = new System.Windows.Forms.Label();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.txbServer = new System.Windows.Forms.TextBox();
            this.lblServer = new System.Windows.Forms.Label();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.txbPort = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txbUser = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblTextStepThree = new System.Windows.Forms.Label();
            this.pnlStepTwo = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTextStepTwo = new System.Windows.Forms.Label();
            this.pnlCurrentStep = new System.Windows.Forms.Panel();
            this.pnlStepOne = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDataFileHelp = new System.Windows.Forms.Label();
            this.lblTemplateFile = new System.Windows.Forms.Label();
            this.lblDataFile = new System.Windows.Forms.Label();
            this.txbDataFilePath = new System.Windows.Forms.TextBox();
            this.txbTemplateFilePath = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnOpenTemplate = new System.Windows.Forms.Button();
            this.lblTemplateHelp = new System.Windows.Forms.Label();
            this.lblTextStepOne = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnBackStep = new System.Windows.Forms.Button();
            this.btnNextStep = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ptbStep = new System.Windows.Forms.PictureBox();
            this.openTemplateFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.localizationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ptbTitle)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.gpbSettingsSteps.SuspendLayout();
            this.pnlStepThree.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.pnlStepTwo.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.pnlCurrentStep.SuspendLayout();
            this.pnlStepOne.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.localizationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbTitle
            // 
            this.ptbTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ptbTitle.Image = global::OpenDataDBBuilder.Properties.Resources.imgoddb;
            this.ptbTitle.Location = new System.Drawing.Point(7, 3);
            this.ptbTitle.Name = "ptbTitle";
            this.ptbTitle.Size = new System.Drawing.Size(106, 89);
            this.ptbTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbTitle.TabIndex = 3;
            this.ptbTitle.TabStop = false;
            // 
            // cmbDB
            // 
            this.cmbDB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbDB.FormattingEnabled = true;
            this.cmbDB.Items.AddRange(new object[] {
            "MySQL"});
            this.cmbDB.Location = new System.Drawing.Point(153, 39);
            this.cmbDB.Name = "cmbDB";
            this.cmbDB.Size = new System.Drawing.Size(109, 21);
            this.cmbDB.TabIndex = 6;
            // 
            // lblDB
            // 
            this.lblDB.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDB.AutoSize = true;
            this.lblDB.Location = new System.Drawing.Point(112, 43);
            this.lblDB.Name = "lblDB";
            this.lblDB.Size = new System.Drawing.Size(35, 13);
            this.lblDB.TabIndex = 7;
            this.lblDB.Text = "label1";
            // 
            // lblLanguage
            // 
            this.lblLanguage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(55, 13);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(35, 13);
            this.lblLanguage.TabIndex = 8;
            this.lblLanguage.Text = "label2";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(96, 9);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(114, 21);
            this.cmbLanguage.TabIndex = 5;
            this.cmbLanguage.SelectedValueChanged += new System.EventHandler(this.cmbLanguage_SelectedValueChanged);
            // 
            // openDataFileDialog
            // 
            this.openDataFileDialog.FileName = "openFileDialog1";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.33029F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.66971F));
            this.tableLayoutPanel4.Controls.Add(this.gpbSettingsSteps, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(657, 487);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // gpbSettingsSteps
            // 
            this.gpbSettingsSteps.Controls.Add(this.pnlStepThree);
            this.gpbSettingsSteps.Controls.Add(this.pnlStepTwo);
            this.gpbSettingsSteps.Controls.Add(this.pnlCurrentStep);
            this.gpbSettingsSteps.Controls.Add(this.tableLayoutPanel3);
            this.gpbSettingsSteps.Controls.Add(this.btnFinish);
            this.gpbSettingsSteps.Controls.Add(this.btnBackStep);
            this.gpbSettingsSteps.Controls.Add(this.btnNextStep);
            this.gpbSettingsSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbSettingsSteps.Location = new System.Drawing.Point(130, 3);
            this.gpbSettingsSteps.Name = "gpbSettingsSteps";
            this.gpbSettingsSteps.Size = new System.Drawing.Size(524, 481);
            this.gpbSettingsSteps.TabIndex = 3;
            this.gpbSettingsSteps.TabStop = false;
            // 
            // pnlStepThree
            // 
            this.pnlStepThree.Controls.Add(this.tableLayoutPanel10);
            this.pnlStepThree.Controls.Add(this.tableLayoutPanel6);
            this.pnlStepThree.Controls.Add(this.lblTextStepThree);
            this.pnlStepThree.Location = new System.Drawing.Point(209, 14);
            this.pnlStepThree.Name = "pnlStepThree";
            this.pnlStepThree.Size = new System.Drawing.Size(44, 37);
            this.pnlStepThree.TabIndex = 14;
            this.pnlStepThree.Visible = false;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 3;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 203F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel10.Controls.Add(this.btnAddDB, 2, 0);
            this.tableLayoutPanel10.Controls.Add(this.cmbDBs, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.lblDatabase, 0, 0);
            this.tableLayoutPanel10.Location = new System.Drawing.Point(60, 254);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(438, 38);
            this.tableLayoutPanel10.TabIndex = 13;
            // 
            // btnAddDB
            // 
            this.btnAddDB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAddDB.Enabled = false;
            this.btnAddDB.Location = new System.Drawing.Point(301, 6);
            this.btnAddDB.Name = "btnAddDB";
            this.btnAddDB.Size = new System.Drawing.Size(41, 25);
            this.btnAddDB.TabIndex = 1;
            this.btnAddDB.Text = "+";
            this.btnAddDB.UseVisualStyleBackColor = true;
            this.btnAddDB.Click += new System.EventHandler(this.btnAddDB_Click);
            // 
            // cmbDBs
            // 
            this.cmbDBs.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.cmbDBs.Enabled = false;
            this.cmbDBs.FormattingEnabled = true;
            this.cmbDBs.Location = new System.Drawing.Point(98, 8);
            this.cmbDBs.Name = "cmbDBs";
            this.cmbDBs.Size = new System.Drawing.Size(197, 21);
            this.cmbDBs.TabIndex = 0;
            this.cmbDBs.SelectedIndexChanged += new System.EventHandler(this.cmbDBs_SelectedIndexChanged);
            // 
            // lblDatabase
            // 
            this.lblDatabase.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Enabled = false;
            this.lblDatabase.Location = new System.Drawing.Point(36, 12);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(56, 13);
            this.lblDatabase.TabIndex = 2;
            this.lblDatabase.Text = "Database:";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 209F));
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel9, 0, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(60, 97);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(438, 157);
            this.tableLayoutPanel6.TabIndex = 12;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.lblTestResult, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(232, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.31788F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.68212F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(203, 151);
            this.tableLayoutPanel7.TabIndex = 10;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.btnTest, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 81);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.25926F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(197, 67);
            this.tableLayoutPanel8.TabIndex = 11;
            // 
            // btnTest
            // 
            this.btnTest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTest.Location = new System.Drawing.Point(61, 22);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 8;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // lblTestResult
            // 
            this.lblTestResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTestResult.AutoSize = true;
            this.lblTestResult.Location = new System.Drawing.Point(101, 32);
            this.lblTestResult.Name = "lblTestResult";
            this.lblTestResult.Size = new System.Drawing.Size(0, 13);
            this.lblTestResult.TabIndex = 9;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.36364F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.63636F));
            this.tableLayoutPanel9.Controls.Add(this.txbServer, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.lblServer, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.txbPassword, 1, 3);
            this.tableLayoutPanel9.Controls.Add(this.txbPort, 1, 1);
            this.tableLayoutPanel9.Controls.Add(this.lblUser, 0, 2);
            this.tableLayoutPanel9.Controls.Add(this.txbUser, 1, 2);
            this.tableLayoutPanel9.Controls.Add(this.lblPort, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.lblPassword, 0, 3);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 4;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.11538F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.88462F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(223, 151);
            this.tableLayoutPanel9.TabIndex = 8;
            // 
            // txbServer
            // 
            this.txbServer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txbServer.Location = new System.Drawing.Point(95, 6);
            this.txbServer.Name = "txbServer";
            this.txbServer.Size = new System.Drawing.Size(125, 20);
            this.txbServer.TabIndex = 1;
            // 
            // lblServer
            // 
            this.lblServer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(48, 9);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(41, 13);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "Server:";
            // 
            // txbPassword
            // 
            this.txbPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txbPassword.Location = new System.Drawing.Point(95, 120);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '*';
            this.txbPassword.Size = new System.Drawing.Size(125, 20);
            this.txbPassword.TabIndex = 6;
            // 
            // txbPort
            // 
            this.txbPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txbPort.Location = new System.Drawing.Point(95, 40);
            this.txbPort.Name = "txbPort";
            this.txbPort.Size = new System.Drawing.Size(67, 20);
            this.txbPort.TabIndex = 3;
            // 
            // lblUser
            // 
            this.lblUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(57, 82);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(32, 13);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "User:";
            // 
            // txbUser
            // 
            this.txbUser.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txbUser.Location = new System.Drawing.Point(95, 79);
            this.txbUser.Name = "txbUser";
            this.txbUser.Size = new System.Drawing.Size(125, 20);
            this.txbUser.TabIndex = 5;
            // 
            // lblPort
            // 
            this.lblPort.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(60, 43);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Port:";
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(28, 124);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 13);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Passsword:";
            // 
            // lblTextStepThree
            // 
            this.lblTextStepThree.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTextStepThree.AutoSize = true;
            this.lblTextStepThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextStepThree.Location = new System.Drawing.Point(-409, -126);
            this.lblTextStepThree.Name = "lblTextStepThree";
            this.lblTextStepThree.Size = new System.Drawing.Size(259, 24);
            this.lblTextStepThree.TabIndex = 10;
            this.lblTextStepThree.Text = "Set your database connection";
            // 
            // pnlStepTwo
            // 
            this.pnlStepTwo.Controls.Add(this.tableLayoutPanel2);
            this.pnlStepTwo.Controls.Add(this.lblTextStepTwo);
            this.pnlStepTwo.Location = new System.Drawing.Point(116, 14);
            this.pnlStepTwo.Name = "pnlStepTwo";
            this.pnlStepTwo.Size = new System.Drawing.Size(46, 33);
            this.pnlStepTwo.TabIndex = 12;
            this.pnlStepTwo.Visible = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.99517F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.00483F));
            this.tableLayoutPanel2.Controls.Add(this.cmbDB, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblDB, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(63, 117);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(350, 100);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // lblTextStepTwo
            // 
            this.lblTextStepTwo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTextStepTwo.AutoSize = true;
            this.lblTextStepTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextStepTwo.Location = new System.Drawing.Point(-407, -128);
            this.lblTextStepTwo.Name = "lblTextStepTwo";
            this.lblTextStepTwo.Size = new System.Drawing.Size(199, 24);
            this.lblTextStepTwo.TabIndex = 9;
            this.lblTextStepTwo.Text = "Choose your database";
            // 
            // pnlCurrentStep
            // 
            this.pnlCurrentStep.Controls.Add(this.pnlStepOne);
            this.pnlCurrentStep.Location = new System.Drawing.Point(6, 55);
            this.pnlCurrentStep.Name = "pnlCurrentStep";
            this.pnlCurrentStep.Size = new System.Drawing.Size(512, 341);
            this.pnlCurrentStep.TabIndex = 13;
            // 
            // pnlStepOne
            // 
            this.pnlStepOne.Controls.Add(this.tableLayoutPanel5);
            this.pnlStepOne.Controls.Add(this.lblTextStepOne);
            this.pnlStepOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStepOne.Location = new System.Drawing.Point(0, 0);
            this.pnlStepOne.Name = "pnlStepOne";
            this.pnlStepOne.Size = new System.Drawing.Size(512, 341);
            this.pnlStepOne.TabIndex = 13;
            this.pnlStepOne.Visible = false;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.99517F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.00483F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 159F));
            this.tableLayoutPanel5.Controls.Add(this.lblDataFileHelp, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblTemplateFile, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblDataFile, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.txbDataFilePath, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.txbTemplateFilePath, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.btnOpenFile, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnOpenTemplate, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.lblTemplateHelp, 3, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(63, 112);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(411, 93);
            this.tableLayoutPanel5.TabIndex = 10;
            // 
            // lblDataFileHelp
            // 
            this.lblDataFileHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDataFileHelp.AutoSize = true;
            this.lblDataFileHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataFileHelp.Location = new System.Drawing.Point(254, 19);
            this.lblDataFileHelp.Name = "lblDataFileHelp";
            this.lblDataFileHelp.Size = new System.Drawing.Size(154, 12);
            this.lblDataFileHelp.TabIndex = 14;
            this.lblDataFileHelp.Text = "* file to extract data";
            // 
            // lblTemplateFile
            // 
            this.lblTemplateFile.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTemplateFile.AutoSize = true;
            this.lblTemplateFile.Enabled = false;
            this.lblTemplateFile.Location = new System.Drawing.Point(25, 65);
            this.lblTemplateFile.Name = "lblTemplateFile";
            this.lblTemplateFile.Size = new System.Drawing.Size(51, 13);
            this.lblTemplateFile.TabIndex = 8;
            this.lblTemplateFile.Text = "Template";
            // 
            // lblDataFile
            // 
            this.lblDataFile.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDataFile.AutoSize = true;
            this.lblDataFile.Location = new System.Drawing.Point(27, 18);
            this.lblDataFile.Name = "lblDataFile";
            this.lblDataFile.Size = new System.Drawing.Size(49, 13);
            this.lblDataFile.TabIndex = 7;
            this.lblDataFile.Text = "Data file:";
            // 
            // txbDataFilePath
            // 
            this.txbDataFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbDataFilePath.Location = new System.Drawing.Point(82, 15);
            this.txbDataFilePath.Name = "txbDataFilePath";
            this.txbDataFilePath.ReadOnly = true;
            this.txbDataFilePath.Size = new System.Drawing.Size(99, 20);
            this.txbDataFilePath.TabIndex = 9;
            // 
            // txbTemplateFilePath
            // 
            this.txbTemplateFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txbTemplateFilePath.Enabled = false;
            this.txbTemplateFilePath.Location = new System.Drawing.Point(82, 61);
            this.txbTemplateFilePath.Name = "txbTemplateFilePath";
            this.txbTemplateFilePath.ReadOnly = true;
            this.txbTemplateFilePath.Size = new System.Drawing.Size(99, 20);
            this.txbTemplateFilePath.TabIndex = 10;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFile.Location = new System.Drawing.Point(187, 13);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(61, 23);
            this.btnOpenFile.TabIndex = 11;
            this.btnOpenFile.Text = "Open";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click_1);
            // 
            // btnOpenTemplate
            // 
            this.btnOpenTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenTemplate.Enabled = false;
            this.btnOpenTemplate.Location = new System.Drawing.Point(187, 60);
            this.btnOpenTemplate.Name = "btnOpenTemplate";
            this.btnOpenTemplate.Size = new System.Drawing.Size(61, 23);
            this.btnOpenTemplate.TabIndex = 12;
            this.btnOpenTemplate.Text = "Open";
            this.btnOpenTemplate.UseVisualStyleBackColor = true;
            this.btnOpenTemplate.Click += new System.EventHandler(this.btnOpenTemplate_Click);
            // 
            // lblTemplateHelp
            // 
            this.lblTemplateHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTemplateHelp.AutoSize = true;
            this.lblTemplateHelp.Enabled = false;
            this.lblTemplateHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemplateHelp.Location = new System.Drawing.Point(254, 65);
            this.lblTemplateHelp.Name = "lblTemplateHelp";
            this.lblTemplateHelp.Size = new System.Drawing.Size(154, 12);
            this.lblTemplateHelp.TabIndex = 13;
            this.lblTemplateHelp.Text = "* skip other settings";
            // 
            // lblTextStepOne
            // 
            this.lblTextStepOne.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTextStepOne.AutoSize = true;
            this.lblTextStepOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextStepOne.Location = new System.Drawing.Point(59, 26);
            this.lblTextStepOne.Name = "lblTextStepOne";
            this.lblTextStepOne.Size = new System.Drawing.Size(155, 24);
            this.lblTextStepOne.TabIndex = 9;
            this.lblTextStepOne.Text = "Choose your files";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56F));
            this.tableLayoutPanel3.Controls.Add(this.lblLanguage, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cmbLanguage, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(305, 9);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(213, 40);
            this.tableLayoutPanel3.TabIndex = 11;
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(376, 402);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(113, 57);
            this.btnFinish.TabIndex = 5;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.EnabledChanged += new System.EventHandler(this.btnFinish_EnabledChanged);
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnBackStep
            // 
            this.btnBackStep.Location = new System.Drawing.Point(40, 402);
            this.btnBackStep.Name = "btnBackStep";
            this.btnBackStep.Size = new System.Drawing.Size(113, 57);
            this.btnBackStep.TabIndex = 4;
            this.btnBackStep.Text = "Back";
            this.btnBackStep.UseVisualStyleBackColor = true;
            this.btnBackStep.Click += new System.EventHandler(this.btnBackStep_Click);
            // 
            // btnNextStep
            // 
            this.btnNextStep.Location = new System.Drawing.Point(209, 402);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(113, 57);
            this.btnNextStep.TabIndex = 3;
            this.btnNextStep.Text = "Next";
            this.btnNextStep.UseVisualStyleBackColor = true;
            this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ptbStep, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ptbTitle, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.95842F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.04158F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(121, 481);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // ptbStep
            // 
            this.ptbStep.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ptbStep.Image = global::OpenDataDBBuilder.Properties.Resources.imgstep01;
            this.ptbStep.Location = new System.Drawing.Point(3, 103);
            this.ptbStep.Name = "ptbStep";
            this.ptbStep.Size = new System.Drawing.Size(115, 369);
            this.ptbStep.TabIndex = 2;
            this.ptbStep.TabStop = false;
            // 
            // openTemplateFileDialog
            // 
            this.openTemplateFileDialog.FileName = "openFileDialog1";
            // 
            // localizationBindingSource
            // 
            this.localizationBindingSource.DataSource = typeof(OpenDataDBBuilder.UI.Localization.Localization);
            // 
            // StartScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(657, 487);
            this.Controls.Add(this.tableLayoutPanel4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(378, 332);
            this.Name = "StartScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ODDB";
            this.Load += new System.EventHandler(this.StartScreenForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbTitle)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.gpbSettingsSteps.ResumeLayout(false);
            this.pnlStepThree.ResumeLayout(false);
            this.pnlStepThree.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.pnlStepTwo.ResumeLayout(false);
            this.pnlStepTwo.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.pnlCurrentStep.ResumeLayout(false);
            this.pnlStepOne.ResumeLayout(false);
            this.pnlStepOne.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.localizationBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbTitle;
        private System.Windows.Forms.OpenFileDialog openDataFileDialog;
        private System.Windows.Forms.ComboBox cmbDB;
        private System.Windows.Forms.Label lblDB;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.BindingSource localizationBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.PictureBox ptbStep;
        private System.Windows.Forms.GroupBox gpbSettingsSteps;
        private System.Windows.Forms.Button btnNextStep;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnBackStep;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTextStepTwo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel pnlStepTwo;
        private System.Windows.Forms.Panel pnlCurrentStep;
        private System.Windows.Forms.Panel pnlStepOne;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label lblDataFile;
        private System.Windows.Forms.Label lblTextStepOne;
        private System.Windows.Forms.Label lblTemplateFile;
        private System.Windows.Forms.TextBox txbDataFilePath;
        private System.Windows.Forms.TextBox txbTemplateFilePath;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnOpenTemplate;
        private System.Windows.Forms.Label lblDataFileHelp;
        private System.Windows.Forms.Label lblTemplateHelp;
        private System.Windows.Forms.Panel pnlStepThree;
        private System.Windows.Forms.Label lblTextStepThree;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblTestResult;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.TextBox txbServer;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.TextBox txbPort;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txbUser;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Button btnAddDB;
        private System.Windows.Forms.ComboBox cmbDBs;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.OpenFileDialog openTemplateFileDialog;
    }
}