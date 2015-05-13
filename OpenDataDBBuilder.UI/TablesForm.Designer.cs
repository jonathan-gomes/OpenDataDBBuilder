using OpenDataDBBuilder.UI.Components;
namespace OpenDataDBBuilder.UI
{
    partial class TablesForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiLangEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiLangPortuguese = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiTables = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiEditColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiTablesEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiTablesCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.dtcTables = new OpenDataDBBuilder.UI.Components.DraggableTabControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiFile,
            this.tsiOptions,
            this.tsiTables,
            this.tsiCreate});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(815, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsiFile
            // 
            this.tsiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiOpenFile});
            this.tsiFile.Name = "tsiFile";
            this.tsiFile.Size = new System.Drawing.Size(37, 20);
            this.tsiFile.Text = "File";
            // 
            // tsiOpenFile
            // 
            this.tsiOpenFile.Name = "tsiOpenFile";
            this.tsiOpenFile.Size = new System.Drawing.Size(103, 22);
            this.tsiOpenFile.Text = "Open";
            this.tsiOpenFile.Click += new System.EventHandler(this.tsiOpenFile_Click);
            // 
            // tsiOptions
            // 
            this.tsiOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiLanguage});
            this.tsiOptions.Name = "tsiOptions";
            this.tsiOptions.Size = new System.Drawing.Size(61, 20);
            this.tsiOptions.Text = "Options";
            // 
            // tsiLanguage
            // 
            this.tsiLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiLangEnglish,
            this.tsiLangPortuguese});
            this.tsiLanguage.Name = "tsiLanguage";
            this.tsiLanguage.Size = new System.Drawing.Size(152, 22);
            this.tsiLanguage.Text = "Language";
            // 
            // tsiLangEnglish
            // 
            this.tsiLangEnglish.Checked = true;
            this.tsiLangEnglish.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsiLangEnglish.Name = "tsiLangEnglish";
            this.tsiLangEnglish.Size = new System.Drawing.Size(167, 22);
            this.tsiLangEnglish.Text = "English";
            this.tsiLangEnglish.Click += new System.EventHandler(this.tsiLangEnglish_Click);
            // 
            // tsiLangPortuguese
            // 
            this.tsiLangPortuguese.Name = "tsiLangPortuguese";
            this.tsiLangPortuguese.Size = new System.Drawing.Size(167, 22);
            this.tsiLangPortuguese.Text = "Português (Brasil)";
            this.tsiLangPortuguese.Click += new System.EventHandler(this.tsiLangPortuguese_Click);
            // 
            // tsiTables
            // 
            this.tsiTables.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiEditColumns,
            this.tsiTablesEdit});
            this.tsiTables.Name = "tsiTables";
            this.tsiTables.Size = new System.Drawing.Size(53, 20);
            this.tsiTables.Text = "Tables";
            // 
            // tsiEditColumns
            // 
            this.tsiEditColumns.Name = "tsiEditColumns";
            this.tsiEditColumns.Size = new System.Drawing.Size(152, 22);
            this.tsiEditColumns.Text = "Edit Columns";
            this.tsiEditColumns.Click += new System.EventHandler(this.tsiEditColumns_Click);
            // 
            // tsiTablesEdit
            // 
            this.tsiTablesEdit.Name = "tsiTablesEdit";
            this.tsiTablesEdit.Size = new System.Drawing.Size(152, 22);
            this.tsiTablesEdit.Text = "Edit Tables";
            this.tsiTablesEdit.Click += new System.EventHandler(this.tsiTablesEdit_Click);
            // 
            // tsiCreate
            // 
            this.tsiCreate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiTablesCreate});
            this.tsiCreate.Name = "tsiCreate";
            this.tsiCreate.Size = new System.Drawing.Size(53, 20);
            this.tsiCreate.Text = "Create";
            // 
            // tsiTablesCreate
            // 
            this.tsiTablesCreate.Name = "tsiTablesCreate";
            this.tsiTablesCreate.Size = new System.Drawing.Size(152, 22);
            this.tsiTablesCreate.Text = "Tables";
            this.tsiTablesCreate.Click += new System.EventHandler(this.tsiTablesCreate_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // dtcTables
            // 
            this.dtcTables.AllowDrop = true;
            this.dtcTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtcTables.Location = new System.Drawing.Point(0, 24);
            this.dtcTables.Name = "dtcTables";
            this.dtcTables.SelectedIndex = 0;
            this.dtcTables.Size = new System.Drawing.Size(815, 480);
            this.dtcTables.TabIndex = 2;
            // 
            // TablesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 504);
            this.Controls.Add(this.dtcTables);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TablesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ODDB: Tables View";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.closeParentForm);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private DraggableTabControl dtcTables;
        private System.Windows.Forms.ToolStripMenuItem tsiFile;
        private System.Windows.Forms.ToolStripMenuItem tsiOpenFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem tsiOptions;
        private System.Windows.Forms.ToolStripMenuItem tsiLanguage;
        private System.Windows.Forms.ToolStripMenuItem tsiLangEnglish;
        private System.Windows.Forms.ToolStripMenuItem tsiLangPortuguese;
        private System.Windows.Forms.ToolStripMenuItem tsiTables;
        private System.Windows.Forms.ToolStripMenuItem tsiEditColumns;
        private System.Windows.Forms.ToolStripMenuItem tsiTablesEdit;
        private System.Windows.Forms.ToolStripMenuItem tsiCreate;
        private System.Windows.Forms.ToolStripMenuItem tsiTablesCreate;

    }
}