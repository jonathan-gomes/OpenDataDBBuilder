namespace OpenDataDBBuilder.UI
{
    partial class DataBasesForm
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
            this.lbxDatabases = new System.Windows.Forms.ListBox();
            this.txbDataBase = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAddDataBase = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxDatabases
            // 
            this.lbxDatabases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxDatabases.FormattingEnabled = true;
            this.lbxDatabases.Location = new System.Drawing.Point(3, 70);
            this.lbxDatabases.Name = "lbxDatabases";
            this.lbxDatabases.Size = new System.Drawing.Size(441, 188);
            this.lbxDatabases.TabIndex = 0;
            // 
            // txbDataBase
            // 
            this.txbDataBase.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txbDataBase.Location = new System.Drawing.Point(3, 20);
            this.txbDataBase.Name = "txbDataBase";
            this.txbDataBase.Size = new System.Drawing.Size(268, 20);
            this.txbDataBase.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbxDatabases, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.87065F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.12936F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(447, 261);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 167F));
            this.tableLayoutPanel2.Controls.Add(this.txbDataBase, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAddDataBase, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(441, 61);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // btnAddDataBase
            // 
            this.btnAddDataBase.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddDataBase.Location = new System.Drawing.Point(320, 19);
            this.btnAddDataBase.Name = "btnAddDataBase";
            this.btnAddDataBase.Size = new System.Drawing.Size(75, 23);
            this.btnAddDataBase.TabIndex = 2;
            this.btnAddDataBase.Text = "Add";
            this.btnAddDataBase.UseVisualStyleBackColor = true;
            this.btnAddDataBase.Click += new System.EventHandler(this.btnAddDataBase_Click);
            // 
            // DataBasesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DataBasesForm";
            this.Text = "DataBasesForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxDatabases;
        private System.Windows.Forms.TextBox txbDataBase;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnAddDataBase;
    }
}