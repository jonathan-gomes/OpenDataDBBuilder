using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenDataDBBuilder.Business.VO;
using OpenDataDBBuilder.Business.DB.VO;
using OpenDataDBBuilder.Business.DB;

using System.Globalization;
using System.Threading;
using OpenDataDBBuilder.UI.Localization;

namespace OpenDataDBBuilder.UI
{
    public partial class ExecuteSQLForm : Form
    {
        TableList tablesList;
        DBConfig dbconfig;
        DatabaseHelper dbHelper;
        List<String> conflictingTables;

        String noSQLMsg = "";
        String noDBMsg = "";
        String msgSuccessExecuteSQL = "";
        String retInsertRowsError = "";

        Boolean isInserting = false;
        public ExecuteSQLForm(TableList tablesList, DBConfig dbconfig, Boolean isInserting)
        {
            this.isInserting = isInserting;
            this.dbconfig = dbconfig;
            this.tablesList = tablesList;
            this.dbHelper = new DatabaseHelper(dbconfig);
            InitializeComponent();

            getLocalizedLabelsMessages();
            getDefaultValues();
        }

        private void getDefaultValues()
        {
            this.Icon = Properties.Resources.icooddb;

            conflictingTables = getConflictingTables();
            if(isInserting)
                getInsertQueryPreview();
            else
                getSQLFromTables();
            this.btnRunSQL.Image = Properties.Resources.icorun.ToBitmap();
            updateDBList();
        }

        private void getInsertQueryPreview()
        {
            int startIndex = 0;
            if (tablesList != null && tablesList.Tables != null && tablesList.Tables.Count > 0)
            {
                startIndex = this.rtbSQL.Text.Length;
                this.rtbSQL.Text += SQLGenerator.insertRowsPreview(tablesList);

            }
        }

        private String getInsertPreview()
        {
            return "";
        }
        private List<String> getConflictingTables()
        {
            List<String> tables = new List<String>();
            if (this.cmbDBs.SelectedItem != null && !"".Equals(this.cmbDBs.SelectedItem.ToString()))
            {
                //this.lbxTables.Items
            }
            return tables;
        }
        private void getLocalizedLabelsMessages()
        {
            CultureInfo language = Thread.CurrentThread.CurrentUICulture;
            Localization.Localization loc = new Localization.Localization();
            this.Text = loc.getLocalizedResource(language, this.Name);
            this.lblDataBases.Text = loc.getLocalizedResource(language, this.lblDataBases.Name);
            this.lblTables.Text = loc.getLocalizedResource(language, this.lblTables.Name);
            noSQLMsg = loc.getLocalizedResource(language, "noSQLMsg");
            noDBMsg = loc.getLocalizedResource(language, "noDBMsg");
            msgSuccessExecuteSQL = loc.getLocalizedResource(language, "msgSuccessExecuteSQL");
            retInsertRowsError = loc.getLocalizedResource(language, "retInsertRowsError");
        }

        private void updateDBList()
        {
            foreach (String s in listDataBases())
            {
                this.cmbDBs.Items.Add(s);
            }
            if (this.cmbDBs.Items.Contains(dbconfig.DbName))
            {
                this.cmbDBs.SelectedItem = dbconfig.DbName;
            }
        }

        private List<String> listDataBases()
        {
            return dbHelper.selectDataBases();
        }

        private void getSQLFromTables()
        {
            int startIndex = 0;
            if (tablesList != null && tablesList.Tables != null)
            {
                foreach (Table t in tablesList.Tables)
                {
                    startIndex = this.rtbSQL.Text.Length;
                    this.rtbSQL.Text += t.SQLcreate;
                    if (conflictingTables.Contains(t.TableName))
                    {
                        this.rtbSQL.SelectionStart = startIndex;
                        this.rtbSQL.SelectionLength = this.rtbSQL.Text.Length;
                        this.rtbSQL.SelectionFont = new System.Drawing.Font("Tahoma", 10);
                    }

                }
            }
            
        }

        private void btnRunSQL_Click(object sender, EventArgs e)
        {
            if(rtbSQL.Text == null || rtbSQL.Text.Equals(""))
            {
                showInfoErrorForm(noSQLMsg, true);
                return;
            }
            else if (cmbDBs.SelectedItem == null || cmbDBs.SelectedItem.ToString().Equals(""))
            {
                showInfoErrorForm(noDBMsg, true);
                return;
            }
            else
            {
                if (isInserting)
                {
                    DialogInsertingForm dgForm = new DialogInsertingForm(dbHelper, tablesList);
                    DialogResult result = dgForm.ShowDialog();
                    dgForm.Dispose();

                    if (result.Equals(DialogResult.Cancel) || result.Equals(DialogResult.OK))
                    {
                        this.Close();
                    }
                }
                else
                {
                    String retCreateTables = dbHelper.runSQL(rtbSQL.Text);
                    if (retCreateTables != null && !retCreateTables.Equals(""))
                        showInfoErrorForm(retCreateTables, true);
                    else
                        showInfoErrorForm(msgSuccessExecuteSQL, false);
                }
                
            }
            updatetableList();
        }

        private void showInfoErrorForm(String msg, bool error)
        {
            InfoErrorDialogForm infoErrorDialogForm = new InfoErrorDialogForm(error, msg);
            infoErrorDialogForm.StartPosition = FormStartPosition.CenterScreen;
            infoErrorDialogForm.ShowDialog();
            infoErrorDialogForm.Dispose();
        }

        private void cmbDBs_SelectedValueChanged(object sender, EventArgs e)
        {
            updatetableList();
        }
        private void updatetableList()
        {
            if (cmbDBs.SelectedItem != null && !cmbDBs.SelectedItem.ToString().Equals(""))
            {
                dbconfig.DbName = cmbDBs.SelectedItem.ToString();
                List<String> tablesInSelectedDataBase = dbHelper.getTablesFromDataBase(cmbDBs.SelectedItem.ToString());
                lbxTables.Items.Clear();
                foreach (String s in tablesInSelectedDataBase)
                {
                    lbxTables.Items.Add(s);
                }
            }
        }

        private void lbxTables_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((lbxTables.SelectedItem != null && !lbxTables.SelectedItem.ToString().Equals(""))
                && (cmbDBs.SelectedItem != null && !cmbDBs.SelectedItem.ToString().Equals("")))
            {
                TableDescriptionForm tableDescriptionForm = new TableDescriptionForm(dbconfig, lbxTables.SelectedItem.ToString());
                tableDescriptionForm.ShowDialog();
                tableDescriptionForm.Dispose();
                updateDBList();
                updatetableList();
            }
        }

        private void btnAddDB_Click(object sender, EventArgs e)
        {
           AddDBForm addDBForm = new AddDBForm(dbconfig);
           addDBForm.ShowDialog();
           if (addDBForm.dbAdded != null && !addDBForm.dbAdded.Equals(""))
           {
               updateDBList();
               for (int i = 0; i < cmbDBs.Items.Count; i++)
               {
                   if (cmbDBs.Items[i].ToString().Equals(addDBForm.dbAdded))
                   {
                       cmbDBs.SelectedIndex = i;
                       break;
                   }
               }
           }
           addDBForm.Dispose();
        }
    }
}
