namespace OpenDataDBBuilder.UI
{
    partial class TableDescriptionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableDescriptionForm));
            this.dgvTableDescription = new System.Windows.Forms.DataGridView();
            this.tcrtTableDesc = new System.Windows.Forms.TabControl();
            this.tabDesc = new System.Windows.Forms.TabPage();
            this.tabValues = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvTableRows = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLimit = new System.Windows.Forms.Label();
            this.txbLimit = new System.Windows.Forms.TextBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDropTable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableDescription)).BeginInit();
            this.tcrtTableDesc.SuspendLayout();
            this.tabDesc.SuspendLayout();
            this.tabValues.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableRows)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTableDescription
            // 
            this.dgvTableDescription.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTableDescription.Location = new System.Drawing.Point(3, 3);
            this.dgvTableDescription.Name = "dgvTableDescription";
            this.dgvTableDescription.ReadOnly = true;
            this.dgvTableDescription.Size = new System.Drawing.Size(643, 225);
            this.dgvTableDescription.TabIndex = 0;
            // 
            // tcrtTableDesc
            // 
            this.tcrtTableDesc.Controls.Add(this.tabDesc);
            this.tcrtTableDesc.Controls.Add(this.tabValues);
            this.tcrtTableDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcrtTableDesc.Location = new System.Drawing.Point(3, 41);
            this.tcrtTableDesc.Name = "tcrtTableDesc";
            this.tcrtTableDesc.SelectedIndex = 0;
            this.tcrtTableDesc.Size = new System.Drawing.Size(657, 257);
            this.tcrtTableDesc.TabIndex = 1;
            // 
            // tabDesc
            // 
            this.tabDesc.Controls.Add(this.dgvTableDescription);
            this.tabDesc.Location = new System.Drawing.Point(4, 22);
            this.tabDesc.Name = "tabDesc";
            this.tabDesc.Padding = new System.Windows.Forms.Padding(3);
            this.tabDesc.Size = new System.Drawing.Size(649, 231);
            this.tabDesc.TabIndex = 0;
            this.tabDesc.Text = "Description";
            this.tabDesc.UseVisualStyleBackColor = true;
            // 
            // tabValues
            // 
            this.tabValues.Controls.Add(this.tableLayoutPanel1);
            this.tabValues.Location = new System.Drawing.Point(4, 22);
            this.tabValues.Name = "tabValues";
            this.tabValues.Padding = new System.Windows.Forms.Padding(3);
            this.tabValues.Size = new System.Drawing.Size(655, 275);
            this.tabValues.TabIndex = 1;
            this.tabValues.Text = "Values";
            this.tabValues.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dgvTableRows, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.3829F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.6171F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(649, 269);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvTableRows
            // 
            this.dgvTableRows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTableRows.Location = new System.Drawing.Point(3, 39);
            this.dgvTableRows.Name = "dgvTableRows";
            this.dgvTableRows.ReadOnly = true;
            this.dgvTableRows.Size = new System.Drawing.Size(643, 227);
            this.dgvTableRows.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tableLayoutPanel2.Controls.Add(this.lblLimit, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txbLimit, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnReload, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(643, 30);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblLimit
            // 
            this.lblLimit.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblLimit.AutoSize = true;
            this.lblLimit.Location = new System.Drawing.Point(460, 8);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new System.Drawing.Size(31, 13);
            this.lblLimit.TabIndex = 0;
            this.lblLimit.Text = "Limit:";
            // 
            // txbLimit
            // 
            this.txbLimit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txbLimit.Location = new System.Drawing.Point(497, 5);
            this.txbLimit.Name = "txbLimit";
            this.txbLimit.Size = new System.Drawing.Size(100, 20);
            this.txbLimit.TabIndex = 1;
            // 
            // btnReload
            // 
            this.btnReload.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnReload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReload.BackgroundImage")));
            this.btnReload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReload.Location = new System.Drawing.Point(607, 3);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(28, 23);
            this.btnReload.TabIndex = 2;
            this.btnReload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tcrtTableDesc, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.62459F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.37541F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(663, 301);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDropTable);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(657, 32);
            this.panel1.TabIndex = 2;
            // 
            // btnDropTable
            // 
            this.btnDropTable.Location = new System.Drawing.Point(558, 6);
            this.btnDropTable.Name = "btnDropTable";
            this.btnDropTable.Size = new System.Drawing.Size(75, 23);
            this.btnDropTable.TabIndex = 3;
            this.btnDropTable.Text = "Drop";
            this.btnDropTable.UseVisualStyleBackColor = true;
            this.btnDropTable.Click += new System.EventHandler(this.btnDropTable_Click);
            // 
            // TableDescriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(663, 301);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Name = "TableDescriptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TableDescriptionForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableDescription)).EndInit();
            this.tcrtTableDesc.ResumeLayout(false);
            this.tabDesc.ResumeLayout(false);
            this.tabValues.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableRows)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTableDescription;
        private System.Windows.Forms.TabControl tcrtTableDesc;
        private System.Windows.Forms.TabPage tabDesc;
        private System.Windows.Forms.TabPage tabValues;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvTableRows;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblLimit;
        private System.Windows.Forms.TextBox txbLimit;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDropTable;
    }
}