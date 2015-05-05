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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ptbTitle = new System.Windows.Forms.PictureBox();
            this.psbStarScreenProgress = new System.Windows.Forms.ProgressBar();
            this.txbProgress = new System.Windows.Forms.TextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbDB = new System.Windows.Forms.ComboBox();
            this.lblDB = new System.Windows.Forms.Label();
            this.btnOKDB = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.localizationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTitle)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localizationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ptbTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.psbStarScreenProgress, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txbProgress, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnOpenFile, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(362, 294);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // ptbTitle
            // 
            this.ptbTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ptbTitle.Image = global::OpenDataDBBuilder.Properties.Resources.imgoddb;
            this.ptbTitle.Location = new System.Drawing.Point(128, 12);
            this.ptbTitle.Name = "ptbTitle";
            this.ptbTitle.Size = new System.Drawing.Size(106, 103);
            this.ptbTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbTitle.TabIndex = 3;
            this.ptbTitle.TabStop = false;
            // 
            // psbStarScreenProgress
            // 
            this.psbStarScreenProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.psbStarScreenProgress.Location = new System.Drawing.Point(0, 273);
            this.psbStarScreenProgress.Margin = new System.Windows.Forms.Padding(0);
            this.psbStarScreenProgress.Name = "psbStarScreenProgress";
            this.psbStarScreenProgress.Size = new System.Drawing.Size(362, 21);
            this.psbStarScreenProgress.TabIndex = 0;
            this.psbStarScreenProgress.Visible = false;
            // 
            // txbProgress
            // 
            this.txbProgress.BackColor = System.Drawing.SystemColors.Window;
            this.txbProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txbProgress.Enabled = false;
            this.txbProgress.Location = new System.Drawing.Point(0, 252);
            this.txbProgress.Margin = new System.Windows.Forms.Padding(0);
            this.txbProgress.Name = "txbProgress";
            this.txbProgress.ReadOnly = true;
            this.txbProgress.Size = new System.Drawing.Size(362, 20);
            this.txbProgress.TabIndex = 1;
            this.txbProgress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbProgress.Visible = false;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOpenFile.BackColor = System.Drawing.SystemColors.Menu;
            this.btnOpenFile.Enabled = false;
            this.btnOpenFile.Location = new System.Drawing.Point(130, 207);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(102, 41);
            this.btnOpenFile.TabIndex = 2;
            this.btnOpenFile.UseVisualStyleBackColor = false;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.78486F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.21514F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tableLayoutPanel2.Controls.Add(this.cmbDB, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblDB, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnOKDB, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 169);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(356, 32);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // cmbDB
            // 
            this.cmbDB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbDB.FormattingEnabled = true;
            this.cmbDB.Items.AddRange(new object[] {
            "MySQL"});
            this.cmbDB.Location = new System.Drawing.Point(138, 5);
            this.cmbDB.Name = "cmbDB";
            this.cmbDB.Size = new System.Drawing.Size(110, 21);
            this.cmbDB.TabIndex = 6;
            // 
            // lblDB
            // 
            this.lblDB.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDB.AutoSize = true;
            this.lblDB.Location = new System.Drawing.Point(97, 9);
            this.lblDB.Name = "lblDB";
            this.lblDB.Size = new System.Drawing.Size(35, 13);
            this.lblDB.TabIndex = 7;
            this.lblDB.Text = "label1";
            // 
            // btnOKDB
            // 
            this.btnOKDB.Location = new System.Drawing.Point(254, 3);
            this.btnOKDB.Name = "btnOKDB";
            this.btnOKDB.Size = new System.Drawing.Size(61, 23);
            this.btnOKDB.TabIndex = 8;
            this.btnOKDB.Text = "OK";
            this.btnOKDB.UseVisualStyleBackColor = true;
            this.btnOKDB.Click += new System.EventHandler(this.btnOKDB_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.20225F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.79775F));
            this.tableLayoutPanel3.Controls.Add(this.lblLanguage, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.cmbLanguage, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 131);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(356, 32);
            this.tableLayoutPanel3.TabIndex = 6;
            // 
            // lblLanguage
            // 
            this.lblLanguage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Location = new System.Drawing.Point(98, 9);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(35, 13);
            this.lblLanguage.TabIndex = 8;
            this.lblLanguage.Text = "label2";
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(139, 5);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(121, 21);
            this.cmbLanguage.TabIndex = 5;
            this.cmbLanguage.SelectedValueChanged += new System.EventHandler(this.cmbLanguage_SelectedValueChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
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
            this.ClientSize = new System.Drawing.Size(362, 294);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(378, 332);
            this.MinimumSize = new System.Drawing.Size(378, 332);
            this.Name = "StartScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ODDB";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbTitle)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.localizationBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txbProgress;
        private System.Windows.Forms.ProgressBar psbStarScreenProgress;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.PictureBox ptbTitle;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox cmbDB;
        private System.Windows.Forms.Label lblDB;
        private System.Windows.Forms.Button btnOKDB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.ComboBox cmbLanguage;
        private System.Windows.Forms.BindingSource localizationBindingSource;
    }
}