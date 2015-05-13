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
            this.dgvTableDescription = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableDescription)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTableDescription
            // 
            this.dgvTableDescription.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTableDescription.Location = new System.Drawing.Point(0, 0);
            this.dgvTableDescription.Name = "dgvTableDescription";
            this.dgvTableDescription.ReadOnly = true;
            this.dgvTableDescription.Size = new System.Drawing.Size(535, 407);
            this.dgvTableDescription.TabIndex = 0;
            // 
            // TableDescriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 407);
            this.Controls.Add(this.dgvTableDescription);
            this.Name = "TableDescriptionForm";
            this.Text = "TableDescriptionForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableDescription)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTableDescription;
    }
}