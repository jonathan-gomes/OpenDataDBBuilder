namespace OpenDataDBBuilder.UI
{
    partial class ExecuteSQLForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rtbSQL = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddDB = new System.Windows.Forms.Button();
            this.lblTables = new System.Windows.Forms.Label();
            this.btnRunSQL = new System.Windows.Forms.Button();
            this.lbxTables = new System.Windows.Forms.ListBox();
            this.lblDataBases = new System.Windows.Forms.Label();
            this.cmbDBs = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 253F));
            this.tableLayoutPanel1.Controls.Add(this.rtbSQL, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(828, 448);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rtbSQL
            // 
            this.rtbSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSQL.Location = new System.Drawing.Point(3, 3);
            this.rtbSQL.Name = "rtbSQL";
            this.rtbSQL.Size = new System.Drawing.Size(569, 442);
            this.rtbSQL.TabIndex = 0;
            this.rtbSQL.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddDB);
            this.groupBox1.Controls.Add(this.lblTables);
            this.groupBox1.Controls.Add(this.btnRunSQL);
            this.groupBox1.Controls.Add(this.lbxTables);
            this.groupBox1.Controls.Add(this.lblDataBases);
            this.groupBox1.Controls.Add(this.cmbDBs);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(578, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 442);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnAddDB
            // 
            this.btnAddDB.Location = new System.Drawing.Point(185, 47);
            this.btnAddDB.Name = "btnAddDB";
            this.btnAddDB.Size = new System.Drawing.Size(37, 23);
            this.btnAddDB.TabIndex = 7;
            this.btnAddDB.Text = "+";
            this.btnAddDB.UseVisualStyleBackColor = true;
            this.btnAddDB.Click += new System.EventHandler(this.btnAddDB_Click);
            // 
            // lblTables
            // 
            this.lblTables.AutoSize = true;
            this.lblTables.Location = new System.Drawing.Point(12, 82);
            this.lblTables.Name = "lblTables";
            this.lblTables.Size = new System.Drawing.Size(35, 13);
            this.lblTables.TabIndex = 6;
            this.lblTables.Text = "label1";
            // 
            // btnRunSQL
            // 
            this.btnRunSQL.Location = new System.Drawing.Point(90, 363);
            this.btnRunSQL.Name = "btnRunSQL";
            this.btnRunSQL.Size = new System.Drawing.Size(69, 48);
            this.btnRunSQL.TabIndex = 5;
            this.btnRunSQL.UseVisualStyleBackColor = true;
            this.btnRunSQL.Click += new System.EventHandler(this.btnRunSQL_Click);
            // 
            // lbxTables
            // 
            this.lbxTables.FormattingEnabled = true;
            this.lbxTables.Location = new System.Drawing.Point(6, 98);
            this.lbxTables.Name = "lbxTables";
            this.lbxTables.Size = new System.Drawing.Size(235, 238);
            this.lbxTables.TabIndex = 4;
            this.lbxTables.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxTables_MouseDoubleClick);
            // 
            // lblDataBases
            // 
            this.lblDataBases.AutoSize = true;
            this.lblDataBases.Location = new System.Drawing.Point(12, 33);
            this.lblDataBases.Name = "lblDataBases";
            this.lblDataBases.Size = new System.Drawing.Size(35, 13);
            this.lblDataBases.TabIndex = 3;
            this.lblDataBases.Text = "label1";
            // 
            // cmbDBs
            // 
            this.cmbDBs.FormattingEnabled = true;
            this.cmbDBs.Location = new System.Drawing.Point(6, 49);
            this.cmbDBs.Name = "cmbDBs";
            this.cmbDBs.Size = new System.Drawing.Size(173, 21);
            this.cmbDBs.TabIndex = 2;
            this.cmbDBs.SelectedValueChanged += new System.EventHandler(this.cmbDBs_SelectedValueChanged);
            // 
            // ExecuteSQLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 448);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ExecuteSQLForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExecuteSQLForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RichTextBox rtbSQL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbxTables;
        private System.Windows.Forms.Label lblDataBases;
        private System.Windows.Forms.ComboBox cmbDBs;
        private System.Windows.Forms.Button btnRunSQL;
        private System.Windows.Forms.Label lblTables;
        private System.Windows.Forms.Button btnAddDB;
    }
}