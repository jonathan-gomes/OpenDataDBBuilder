using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenDataDBBuilder.Business.DB.VO;
using OpenDataDBBuilder.Business.DB;

using System.Globalization;
using System.Threading;
using OpenDataDBBuilder.UI.Localization;

namespace OpenDataDBBuilder.UI
{
    public partial class CreateTablesForm : Form
    {
        List<Table> tables;
        String db;
        DatabaseHelper dbHelper;
        String noSQLMsg = "";
        String noDBMsg = "";
        public CreateTablesForm(List<Table> tables, String db)
        {
            this.db = db;
            this.tables = tables;
            this.dbHelper = new DatabaseHelper(db);
            InitializeComponent();

            getLocalizedLabelsMessages();
            getDefaultValues();
        }

        private void getDefaultValues()
        {
            this.Icon = Properties.Resources.icooddb;
            this.rtbSQL.Text = getSQLFromTables();
            this.btnRunSQL.Image = Properties.Resources.icorun.ToBitmap();
            updateDBList();
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
        }

        private void updateDBList()
        {
            foreach (String s in listDataBases())
            {
                this.cmbDBs.Items.Add(s);
            }
        }

        private List<String> listDataBases()
        {
            return dbHelper.selectDataBases();
        }

        private String getSQLFromTables()
        {
            StringBuilder sql = new StringBuilder();
            foreach (Table t in tables)
            {
                sql.Append(t.SQLcreate);
            }
            return sql.ToString();
        }

        private void btnRunSQL_Click(object sender, EventArgs e)
        {
            if(rtbSQL.Text == null || rtbSQL.Text.Equals(""))
            {
                showInfoErrorForm(noSQLMsg);
                return;
            }
            else if (cmbDBs.SelectedItem == null || cmbDBs.SelectedItem.ToString().Equals(""))
            {
                showInfoErrorForm(noDBMsg);
                return;
            }
            else
            {
                String retCreateTables = dbHelper.runSQL(rtbSQL.Text);
                if (retCreateTables != null && !retCreateTables.Equals(""))
                {
                    showInfoErrorForm(retCreateTables);
                }
            }
        }

        private void showInfoErrorForm(String msg)
        {
            InfoErrorDialogForm infoErrorDialogForm = new InfoErrorDialogForm(true, msg);
            infoErrorDialogForm.StartPosition = FormStartPosition.CenterScreen;
            infoErrorDialogForm.ShowDialog();
            infoErrorDialogForm.Dispose();
        }

        private void cmbDBs_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbDBs.SelectedItem != null && !cmbDBs.SelectedItem.ToString().Equals(""))
            {
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
                TableDescriptionForm tableDescriptionForm = new TableDescriptionForm(db, cmbDBs.SelectedItem.ToString(), lbxTables.SelectedItem.ToString());
                tableDescriptionForm.ShowDialog();
                tableDescriptionForm.Dispose();
            }
        }

        private void btnAddDB_Click(object sender, EventArgs e)
        {
           AddDBForm addDBForm = new AddDBForm(db);
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
