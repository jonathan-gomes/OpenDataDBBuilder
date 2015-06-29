using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using OpenDataDBBuilder.UI.Localization;
using OpenDataDBBuilder.Business.DB;
using OpenDataDBBuilder.Business.DB.VO;
using OpenDataDBBuilder.Business.File.Util;

namespace OpenDataDBBuilder.UI
{
    public partial class DialogInsertingForm : Form
    {
        TableList tablesList;
        DatabaseHelper dbHelper;
        Thread insertValuesThread;
        int initialSize;
        Int16 nConnections = 4;

        String initialMessageInserting = "";

        public DialogInsertingForm(DatabaseHelper dbHelper, TableList tablesList)
        {
            this.dbHelper = dbHelper;
            this.tablesList = tablesList;
            InitializeComponent();
            getLocalizedLabelsMessages();
            getDefaultValues();
        }

        private void getLocalizedLabelsMessages()
        {
            bgwProgress.WorkerReportsProgress = true;
            bgwProgress.WorkerSupportsCancellation = true;
            CultureInfo language = Thread.CurrentThread.CurrentUICulture;
            Localization.Localization loc = new Localization.Localization();
            this.btnOK.Text = loc.getLocalizedResource(language, this.btnOK.Name);
            this.btnCancel.Text = loc.getLocalizedResource(language, this.btnCancel.Name);
            this.btnFinish.Text = loc.getLocalizedResource(language, this.btnFinish.Name);
            this.cbxStopOnError.Text = loc.getLocalizedResource(language, this.cbxStopOnError.Name);
            this.lblNofConn.Text = loc.getLocalizedResource(language, this.lblNofConn.Name);
            initialMessageInserting = loc.getLocalizedResource(language, "initialMessageInserting");
            
        }

        private void getDefaultValues()
        {
            this.Icon = Properties.Resources.icooddb;
            txbMessage.Text = initialMessageInserting;
            insertValuesThread = new Thread(insertRowsOneByOne);
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            cbxStopOnError.Enabled = false;
            txbMessage.Text = "";
            btnOK.Enabled = false;
            nConnections = Convert.ToInt16(txbNConnections.Text);
            dbHelper.insertRowsEnqueue(tablesList);
            initialSize = dbHelper.RowsInsert.Count;
            insertValuesThread.Start();
            bgwProgress.RunWorkerAsync();
        }

        void insertRowsOneByOne()
        {
             try
             {
                 dbHelper.insertRowsDequeue(nConnections);
             }
             catch
             {
                 showInfoErrorForm("", true);
             }
        }
        private void DialogInsertingForm_Load(object sender, EventArgs e)
        {
            
        }

        private void showInfoErrorForm(String msg, bool error)
        {
            InfoErrorDialogForm infoErrorDialogForm = new InfoErrorDialogForm(error, msg);
            infoErrorDialogForm.StartPosition = FormStartPosition.CenterScreen;
            infoErrorDialogForm.ShowDialog();
            infoErrorDialogForm.Dispose();
        }
        private void DialogInsertingForm_Shown(object sender, EventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dbHelper.terminateAllInsertThreads();
            insertValuesThread.Abort();
            this.Close();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            dbHelper.terminateAllInsertThreads();
            insertValuesThread.Abort();
            this.Close();
        }

        private void bgwProgress_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            while (i < 100)
            {
                if (dbHelper.threadException == null)
                {
                    Double d = ((double)(initialSize - dbHelper.RowsInsert.Count) / initialSize) * 100;
                    i = (Int16)Math.Truncate(d);
                    // Wait 100 milliseconds.
                    Thread.Sleep(100);
                    // Report progress.
                    bgwProgress.ReportProgress(i);
                    if (i == 100)
                        break;
                }
                else
                {
                    showInfoErrorForm(dbHelper.threadException.Message, true);
                    dbHelper.terminateAllInsertThreads();
                    break;
                }
                
            }
        }

        private void bgwProgress_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Change the value of the ProgressBar to the BackgroundWorker progress.
            psbInsert.Value = e.ProgressPercentage;
            // Set the text.
            this.Text = e.ProgressPercentage.ToString() + "%";
            this.txbMessage.Text += Environment.NewLine + dbHelper.msgInserting;
            this.txbMessage.Select(txbMessage.Text.Length, 0);
            this.txbMessage.ScrollToCaret();
                
        }

        private void DialogInsertingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dbHelper.terminateAllInsertThreads();
            insertValuesThread.Abort();
        }

        private void bgwProgress_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           // bgwProgress.CancelAsync();
            this.btnFinish.Enabled = true;
            this.btnSaveLog.Enabled = true;
        }

        private void txbNConnections_Leave(object sender, EventArgs e)
        {
            if ("".Equals(this.txbNConnections.Text))
                this.txbNConnections.Text = nConnections.ToString();
        }

        private void btnSaveLog_Click(object sender, EventArgs e)
        {
            if (sfdInsertLogFile.ShowDialog() == DialogResult.OK)
            {
                FileUtil.createFile(sfdInsertLogFile.FileName, dbHelper.LogInsert, true);
            }
            sfdInsertLogFile.Dispose();
        }

        private void cbxStopOnError_CheckedChanged(object sender, EventArgs e)
        {
            dbHelper.skip = !cbxStopOnError.Checked;
        }

    }
}
