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
using OpenDataDBBuilder.Business.VO;

using System.Globalization;
using System.Threading;
using OpenDataDBBuilder.UI.Localization;

namespace OpenDataDBBuilder.UI
{
    public partial class ChangeTablesForm : Form
    {
        public List<Table> Tables { get; set; }
        DBConfig dbconfig;
        DatabaseHelper dbHelper;

        public ChangeTablesForm(List<Table> tables, DBConfig dbconfig)
        {
            this.Tables = tables;
            this.dbconfig = dbconfig;
            this.dbHelper = new DatabaseHelper(dbconfig);
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
            this.Icon = Properties.Resources.icooddb;
            int gpbxX = 12;
            int gpbxY = 12;
            this.Controls.Clear();
            foreach (Table t in Tables)
            {
                GroupBox gpx = new GroupBox();
                gpx.Name = "gpbx";
                gpx.Location = new Point(gpbxX, gpbxY);
                gpx.Size = new System.Drawing.Size(355, 61);

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

        private void ChangeTablesForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            foreach (Table t in Tables)
            {
                foreach (Control ctrlGpbx in this.Controls.Find("gpbx", true))
                {
                    if (ctrlGpbx.Controls.Find(t.TableName, true).Count() > 0)
                    {
                        String tableName = ((TextBox)ctrlGpbx.Controls.Find(t.TableName, true)[0]).Text;
                        t.TableName = tableName == null || tableName.Equals("") ? t.TableName : tableName;
                        break;
                    }
                }
            }
        }

    }
}
