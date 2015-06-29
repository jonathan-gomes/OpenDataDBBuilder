namespace OpenDataDBBuilder.UI
{
    partial class AddDBForm
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
            this.txbAddDB = new System.Windows.Forms.TextBox();
            this.btnOKAddDB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbAddDB
            // 
            this.txbAddDB.Location = new System.Drawing.Point(34, 12);
            this.txbAddDB.Name = "txbAddDB";
            this.txbAddDB.Size = new System.Drawing.Size(248, 20);
            this.txbAddDB.TabIndex = 0;
            // 
            // btnOKAddDB
            // 
            this.btnOKAddDB.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOKAddDB.Location = new System.Drawing.Point(301, 13);
            this.btnOKAddDB.Name = "btnOKAddDB";
            this.btnOKAddDB.Size = new System.Drawing.Size(57, 23);
            this.btnOKAddDB.TabIndex = 1;
            this.btnOKAddDB.Text = "OK";
            this.btnOKAddDB.UseVisualStyleBackColor = true;
            this.btnOKAddDB.Click += new System.EventHandler(this.btnOKAddDB_Click);
            // 
            // AddDBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 61);
            this.Controls.Add(this.btnOKAddDB);
            this.Controls.Add(this.txbAddDB);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(386, 99);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(386, 99);
            this.Name = "AddDBForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddDBForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbAddDB;
        private System.Windows.Forms.Button btnOKAddDB;
    }
}