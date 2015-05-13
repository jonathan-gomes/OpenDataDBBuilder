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
using OpenDataDBBuilder.Business.DB.VO;
//using OpenDataDBBuilder.Business.VO;

using System.Globalization;
using System.Threading;
using OpenDataDBBuilder.UI.Localization;

namespace OpenDataDBBuilder.UI
{
    public partial class ChangeTablesForm : Form
    {
        String db = "";
        public List<Table> Tables { get; set; }
        DatabaseHelper dbHelper;
        String lblTableText = "";

        public ChangeTablesForm(List<Table> tables, String db)
        {
            this.Tables = tables;
            this.db = db;
            this.dbHelper = new DatabaseHelper(db);
            InitializeComponent();
            getLocalizedLabelsMessages();
            getDefaultValues();
        }

        private void getLocalizedLabelsMessages()
        {
            CultureInfo language = Thread.CurrentThread.CurrentUICulture;
            Localization.Localization loc = new Localization.Localization();
            this.Text = loc.getLocalizedResource(language, this.Name);
            //lblTableText
        }
        private void getDefaultValues()
        {
            int gpbxX = 12;
            int gpbxY = 12;
            this.Controls.Clear();
            foreach (Table t in Tables)
            {
                GroupBox gpx = new GroupBox();
                gpx.Location = new Point(gpbxX, gpbxY);
                gpx.Size = new System.Drawing.Size(355, 61);
                gpx.Name = t.TableName;

                TextBox texb = new TextBox();
                texb.Name = t.TableName;
                texb.DataBindings.Add(new Binding("Text", t, "TableName"));
                texb.Location = new Point(19, 19);
                texb.Size = new System.Drawing.Size(305, 20);

                gpx.Controls.Add(texb);
                this.Controls.Add(gpx);
                gpbxY += 60;
            }
        }
    }
}
