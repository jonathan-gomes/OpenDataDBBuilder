namespace OpenDataDBBuilder.UI
{
    partial class SQLPreviewForm
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
            this.rtbSQL = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbSQL
            // 
            this.rtbSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSQL.Location = new System.Drawing.Point(0, 0);
            this.rtbSQL.Name = "rtbSQL";
            this.rtbSQL.ReadOnly = true;
            this.rtbSQL.Size = new System.Drawing.Size(550, 433);
            this.rtbSQL.TabIndex = 0;
            this.rtbSQL.Text = "";
            // 
            // SQLPreviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 433);
            this.Controls.Add(this.rtbSQL);
            this.Name = "SQLPreviewForm";
            this.Text = "SQLPreviewForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbSQL;
    }
}