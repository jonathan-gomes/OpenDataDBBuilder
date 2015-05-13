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

using System.Globalization;
using System.Threading;
using OpenDataDBBuilder.UI.Localization;

namespace OpenDataDBBuilder.UI
{
    public partial class TableDescriptionForm : Form
    {
        DatabaseHelper dbHelper;
        DataTable dt;
        String db;
        String dbName;
        String tableName;
        public TableDescriptionForm(String db, String dbName, String tableName)
        {
            InitializeComponent();
            this.db = db;
            this.dbName = dbName;
            this.tableName = tableName;
            this.dbHelper = new DatabaseHelper(db);
            getLocalizedLabelsMessages();
            this.dt = getTableDescription();
            this.dgvTableDescription.DataSource = dt;
            
        }

        public DataTable getTableDescription()
        {
            return dbHelper.getTableDescription(dbName, tableName);
        }
        private void getLocalizedLabelsMessages()
        {
            CultureInfo language = Thread.CurrentThread.CurrentUICulture;
            Localization.Localization loc = new Localization.Localization();
            this.Text = loc.getLocalizedResource(language, "table") + tableName;
        }
    }
}
