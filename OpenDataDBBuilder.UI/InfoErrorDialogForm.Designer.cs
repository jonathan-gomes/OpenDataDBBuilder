namespace OpenDataDBBuilder.UI
{
    partial class InfoErrorDialogForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.ptbIconInfoError = new System.Windows.Forms.PictureBox();
            this.txbInfoError = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptbIconInfoError)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(255, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ptbIconInfoError
            // 
            this.ptbIconInfoError.Location = new System.Drawing.Point(22, 42);
            this.ptbIconInfoError.Name = "ptbIconInfoError";
            this.ptbIconInfoError.Size = new System.Drawing.Size(76, 71);
            this.ptbIconInfoError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbIconInfoError.TabIndex = 2;
            this.ptbIconInfoError.TabStop = false;
            // 
            // txbInfoError
            // 
            this.txbInfoError.BackColor = System.Drawing.SystemColors.Control;
            this.txbInfoError.Location = new System.Drawing.Point(116, 42);
            this.txbInfoError.Multiline = true;
            this.txbInfoError.Name = "txbInfoError";
            this.txbInfoError.ReadOnly = true;
            this.txbInfoError.Size = new System.Drawing.Size(230, 71);
            this.txbInfoError.TabIndex = 3;
            // 
            // InfoErrorDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 165);
            this.Controls.Add(this.txbInfoError);
            this.Controls.Add(this.ptbIconInfoError);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoErrorDialogForm";
            this.Text = "Info";
            ((System.ComponentModel.ISupportInitialize)(this.ptbIconInfoError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox ptbIconInfoError;
        private System.Windows.Forms.TextBox txbInfoError;
    }
}