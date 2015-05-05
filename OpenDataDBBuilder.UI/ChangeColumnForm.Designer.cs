namespace OpenDataDBBuilder.UI
{
    partial class ChangeColumnForm
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
            this.dtcTables = new OpenDataDBBuilder.UI.Components.DraggableTabControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSaveColumns = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dtcTables.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtcTables
            // 
            this.dtcTables.AllowDrop = true;
            this.dtcTables.Controls.Add(this.tabPage1);
            this.dtcTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtcTables.Location = new System.Drawing.Point(3, 3);
            this.dtcTables.Name = "dtcTables";
            this.dtcTables.SelectedIndex = 0;
            this.dtcTables.Size = new System.Drawing.Size(535, 291);
            this.dtcTables.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dtcTables, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSaveColumns, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.48949F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.51051F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(541, 333);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // btnSaveColumns
            // 
            this.btnSaveColumns.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSaveColumns.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSaveColumns.Location = new System.Drawing.Point(463, 303);
            this.btnSaveColumns.Name = "btnSaveColumns";
            this.btnSaveColumns.Size = new System.Drawing.Size(75, 23);
            this.btnSaveColumns.TabIndex = 4;
            this.btnSaveColumns.Text = "Save";
            this.btnSaveColumns.UseVisualStyleBackColor = true;
            this.btnSaveColumns.Click += new System.EventHandler(this.btnSaveColumns_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(527, 265);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(27, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(133, 18);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // ChangeColumnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 333);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ChangeColumnForm";
            this.Text = "ChangeColumnForm";
            this.dtcTables.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Components.DraggableTabControl dtcTables;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnSaveColumns;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;

    }
}