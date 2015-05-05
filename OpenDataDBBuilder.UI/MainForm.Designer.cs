namespace OpenDataDBBuilder.UI
{
    partial class MainForm
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rtbFileReader = new System.Windows.Forms.RichTextBox();
            this.tlpPagesControls = new System.Windows.Forms.TableLayoutPanel();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.txtPage = new System.Windows.Forms.TextBox();
            this.btnPreviousPage = new System.Windows.Forms.Button();
            this.lblNumberOfPages = new System.Windows.Forms.Label();
            this.mstTopBarMenu = new System.Windows.Forms.MenuStrip();
            this.tsiFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiOpenMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiTables = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tlpPagesControls.SuspendLayout();
            this.mstTopBarMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblFilePath, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 98.00885F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.99115F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(791, 452);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblFilePath.Location = new System.Drawing.Point(3, 443);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(785, 9);
            this.lblFilePath.TabIndex = 9;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(785, 437);
            this.splitContainer1.SplitterDistance = 588;
            this.splitContainer1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.rtbFileReader, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tlpPagesControls, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.13501F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.864988F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(588, 437);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // rtbFileReader
            // 
            this.rtbFileReader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbFileReader.HideSelection = false;
            this.rtbFileReader.Location = new System.Drawing.Point(3, 3);
            this.rtbFileReader.Name = "rtbFileReader";
            this.rtbFileReader.ReadOnly = true;
            this.rtbFileReader.Size = new System.Drawing.Size(582, 400);
            this.rtbFileReader.TabIndex = 0;
            this.rtbFileReader.Text = "";
            // 
            // tlpPagesControls
            // 
            this.tlpPagesControls.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tlpPagesControls.ColumnCount = 5;
            this.tlpPagesControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPagesControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpPagesControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tlpPagesControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tlpPagesControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 232F));
            this.tlpPagesControls.Controls.Add(this.btnNextPage, 3, 0);
            this.tlpPagesControls.Controls.Add(this.txtPage, 2, 0);
            this.tlpPagesControls.Controls.Add(this.btnPreviousPage, 1, 0);
            this.tlpPagesControls.Controls.Add(this.lblNumberOfPages, 4, 0);
            this.tlpPagesControls.Location = new System.Drawing.Point(18, 409);
            this.tlpPagesControls.Name = "tlpPagesControls";
            this.tlpPagesControls.RowCount = 1;
            this.tlpPagesControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPagesControls.Size = new System.Drawing.Size(551, 25);
            this.tlpPagesControls.TabIndex = 1;
            // 
            // btnNextPage
            // 
            this.btnNextPage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNextPage.Location = new System.Drawing.Point(283, 3);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(33, 19);
            this.btnNextPage.TabIndex = 1;
            this.btnNextPage.Text = ">";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // txtPage
            // 
            this.txtPage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPage.Location = new System.Drawing.Point(222, 3);
            this.txtPage.Name = "txtPage";
            this.txtPage.Size = new System.Drawing.Size(55, 20);
            this.txtPage.TabIndex = 0;
            this.txtPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPreviousPage.Location = new System.Drawing.Point(182, 3);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(33, 19);
            this.btnPreviousPage.TabIndex = 2;
            this.btnPreviousPage.Text = "<";
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // lblNumberOfPages
            // 
            this.lblNumberOfPages.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNumberOfPages.AutoSize = true;
            this.lblNumberOfPages.Location = new System.Drawing.Point(548, 6);
            this.lblNumberOfPages.Name = "lblNumberOfPages";
            this.lblNumberOfPages.Size = new System.Drawing.Size(0, 13);
            this.lblNumberOfPages.TabIndex = 3;
            // 
            // mstTopBarMenu
            // 
            this.mstTopBarMenu.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.mstTopBarMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiFileMenu,
            this.tsiOptions,
            this.tsiTables});
            this.mstTopBarMenu.Location = new System.Drawing.Point(0, 0);
            this.mstTopBarMenu.Name = "mstTopBarMenu";
            this.mstTopBarMenu.Size = new System.Drawing.Size(791, 24);
            this.mstTopBarMenu.TabIndex = 6;
            this.mstTopBarMenu.Text = "menuStrip1";
            // 
            // tsiFileMenu
            // 
            this.tsiFileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiOpenMenu});
            this.tsiFileMenu.Name = "tsiFileMenu";
            this.tsiFileMenu.Size = new System.Drawing.Size(37, 20);
            this.tsiFileMenu.Text = "File";
            // 
            // tsiOpenMenu
            // 
            this.tsiOpenMenu.Name = "tsiOpenMenu";
            this.tsiOpenMenu.Size = new System.Drawing.Size(152, 22);
            this.tsiOpenMenu.Text = "Open";
            this.tsiOpenMenu.Click += new System.EventHandler(this.tsiOpenMenu_Click);
            // 
            // tsiOptions
            // 
            this.tsiOptions.Name = "tsiOptions";
            this.tsiOptions.Size = new System.Drawing.Size(61, 20);
            this.tsiOptions.Text = "Options";
            this.tsiOptions.Click += new System.EventHandler(this.tsiOptions_Click);
            // 
            // tsiTables
            // 
            this.tsiTables.Name = "tsiTables";
            this.tsiTables.Size = new System.Drawing.Size(53, 20);
            this.tsiTables.Text = "Tables";
            this.tsiTables.Click += new System.EventHandler(this.tsiTables_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(791, 476);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.mstTopBarMenu);
            this.MainMenuStrip = this.mstTopBarMenu;
            this.Name = "MainForm";
            this.Text = "OpenData Database Builder";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tlpPagesControls.ResumeLayout(false);
            this.tlpPagesControls.PerformLayout();
            this.mstTopBarMenu.ResumeLayout(false);
            this.mstTopBarMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RichTextBox rtbFileReader;
        private System.Windows.Forms.TableLayoutPanel tlpPagesControls;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.TextBox txtPage;
        private System.Windows.Forms.Button btnPreviousPage;
        private System.Windows.Forms.Label lblNumberOfPages;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.MenuStrip mstTopBarMenu;
        private System.Windows.Forms.ToolStripMenuItem tsiFileMenu;
        private System.Windows.Forms.ToolStripMenuItem tsiOpenMenu;
        private System.Windows.Forms.ToolStripMenuItem tsiOptions;
        private System.Windows.Forms.ToolStripMenuItem tsiTables;
    }
}

