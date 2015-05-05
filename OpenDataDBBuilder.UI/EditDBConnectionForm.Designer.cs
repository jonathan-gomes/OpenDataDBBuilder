namespace OpenDataDBBuilder.UI
{
    partial class EditDBConnectionForm
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
            this.lblServer = new System.Windows.Forms.Label();
            this.txbServer = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txbPort = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.txbUser = new System.Windows.Forms.TextBox();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.lblTestResult = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblServer
            // 
            this.lblServer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(51, 18);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(41, 13);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "Server:";
            // 
            // txbServer
            // 
            this.txbServer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txbServer.Location = new System.Drawing.Point(98, 14);
            this.txbServer.Name = "txbServer";
            this.txbServer.Size = new System.Drawing.Size(125, 20);
            this.txbServer.TabIndex = 1;
            // 
            // lblPort
            // 
            this.lblPort.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(63, 70);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Port:";
            // 
            // txbPort
            // 
            this.txbPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txbPort.Location = new System.Drawing.Point(98, 66);
            this.txbPort.Name = "txbPort";
            this.txbPort.Size = new System.Drawing.Size(67, 20);
            this.txbPort.TabIndex = 3;
            // 
            // lblUser
            // 
            this.lblUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(60, 124);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(32, 13);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "User:";
            // 
            // txbUser
            // 
            this.txbUser.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txbUser.Location = new System.Drawing.Point(98, 120);
            this.txbUser.Name = "txbUser";
            this.txbUser.Size = new System.Drawing.Size(125, 20);
            this.txbUser.TabIndex = 5;
            // 
            // txbPassword
            // 
            this.txbPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txbPassword.Location = new System.Drawing.Point(98, 187);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '*';
            this.txbPassword.Size = new System.Drawing.Size(125, 20);
            this.txbPassword.TabIndex = 6;
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(31, 191);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(61, 13);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Passsword:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.36364F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.63636F));
            this.tableLayoutPanel1.Controls.Add(this.txbServer, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblServer, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txbPassword, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txbPort, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblUser, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txbUser, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblPort, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPassword, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.11538F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.88462F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(230, 238);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 281F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(517, 244);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblTestResult, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(239, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.66667F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(275, 238);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.btnSave, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.btnTest, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 120);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(269, 115);
            this.tableLayoutPanel4.TabIndex = 11;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(97, 74);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTest
            // 
            this.btnTest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTest.Location = new System.Drawing.Point(97, 17);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 8;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click_1);
            // 
            // lblTestResult
            // 
            this.lblTestResult.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTestResult.AutoSize = true;
            this.lblTestResult.Location = new System.Drawing.Point(120, 52);
            this.lblTestResult.Name = "lblTestResult";
            this.lblTestResult.Size = new System.Drawing.Size(35, 13);
            this.lblTestResult.TabIndex = 9;
            this.lblTestResult.Text = "label1";
            // 
            // EditDBConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 244);
            this.Controls.Add(this.tableLayoutPanel2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(533, 282);
            this.MinimumSize = new System.Drawing.Size(533, 282);
            this.Name = "EditDBConnectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditDBConnectionForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.TextBox txbServer;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txbPort;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txbUser;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblTestResult;
    }
}