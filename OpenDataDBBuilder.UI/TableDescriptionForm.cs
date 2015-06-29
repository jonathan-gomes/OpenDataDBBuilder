using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenDataDBBuilder.Business.DB;
using OpenDataDBBuilder.Business.VO;

using System.Globalization;
using System.Threading;
using OpenDataDBBuilder.UI.Localization;

namespace OpenDataDBBuilder.UI
{
    public partial class TableDescriptionForm : Form
    {
        DatabaseHelper dbHelper;
        DataTable dtDesc;
        DataTable dtTableValues;
        DBConfig dbconfig;
        String tableName;
        public Int16 Limit { get; set; }
        public TableDescriptionForm(DBConfig dbconfig, String tableName)
        {
            InitializeComponent();
            this.txbLimit.DataBindings.Add("Text", this, "Limit");
            this.tableName = tableName;
            this.dbconfig = dbconfig;
            this.dbHelper = new DatabaseHelper(dbconfig);
            getLocalizedLabelsMessages();
            getDefaultValues();
            setFormSize();          
        }

        public DataTable getTableDescription()
        {
            return dbHelper.getTableDescription(dbconfig.DbName, tableName);
        }
        public DataTable getTableRows()
        {
            return dbHelper.getTableRows(dbconfig.DbName, tableName, Limit);
        }

        private void getLocalizedLabelsMessages()
        {
            CultureInfo language = Thread.CurrentThread.CurrentUICulture;
            Localization.Localization loc = new Localization.Localization();
            this.Text = loc.getLocalizedResource(language, "table") + tableName;
            this.lblLimit.Text = loc.getLocalizedResource(language, this.lblLimit.Name);
        }
        private void getDefaultValues()
        {
            Limit = 10;
            this.dtDesc = getTableDescription();
            this.dtTableValues = getTableRows();
            this.dgvTableDescription.DataSource = this.dtDesc;
            this.dgvTableRows.DataSource = this.dtTableValues;
            this.Icon = Properties.Resources.icooddb;
        }
        private void setFormSize()
        {
            int height = 62;
            int width = 60;
            foreach (DataGridViewRow r in dgvTableDescription.Rows)
                height += r.Height;
            foreach (DataGridViewColumn c in dgvTableDescription.Columns)
                width += c.Width;
            this.Height = height > 62 ? height : this.Height;
            this.Width = width > 60 ? width : this.Width;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            this.dtTableValues = getTableRows();
            this.dgvTableRows.DataSource = this.dtTableValues;
        }

        private void btnDropTable_Click(object sender, EventArgs e)
        {
            DialogForm dialogForm = new DialogForm("Excluir tabela e todo seu conteúdo?");
            DialogResult result = dialogForm.ShowDialog();
            if (DialogResult.OK.Equals(result))
            {
                String rtnDrop = dbHelper.dropTable(tableName);
                if (rtnDrop != null && !rtnDrop.Equals(""))
                {
                    showInfoErrorForm(rtnDrop, false);
                    
                }
                this.Close();
            }
            
        }

        private void showInfoErrorForm(String msg, bool error)
        {
            InfoErrorDialogForm infoErrorDialogForm = new InfoErrorDialogForm(error, msg);
            infoErrorDialogForm.StartPosition = FormStartPosition.CenterScreen;
            infoErrorDialogForm.ShowDialog();
            infoErrorDialogForm.Dispose();
        }
    }
}
