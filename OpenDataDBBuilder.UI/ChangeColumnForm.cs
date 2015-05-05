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
using OpenDataDBBuilder.Business.VO;

using System.Globalization;
using System.Threading;
using OpenDataDBBuilder.UI.Localization;

namespace OpenDataDBBuilder.UI
{
    public partial class ChangeColumnForm : Form
    {
        String db = "";
        public List<Table> Tables {get; set;}
        public ChangeColumnForm(List<Table> tables, String db)
        {
            this.Tables = tables;
            this.db = db;
            InitializeComponent();
            getLocalizedLabelsMessages();
            this.Icon = Properties.Resources.icooddb;
            createTablesView();
            
        }

        private void createTablesView()
        {
            int txbX = 27;
            int txbY = 18;

            int txbX2 = 133;
            dtcTables.TabPages.Clear();

            foreach (Table table in this.Tables)
            {
                if (table != null)
                {
                    TabPage tab = new TabPage(table.TableName.ToString());
                    if (table.Columns != null)
                    {
                        foreach (Column c in table.Columns)
                        {
                            TextBox texb = new TextBox();
                            texb.Name = c.ColumnName;
                            texb.DataBindings.Add("Text", c,"ColumnName");
                            texb.Location = new Point(txbX, txbY);
                            tab.Controls.Add(texb);

                            TextBox texbType = new TextBox();
                            texbType.Name = "TYPE"+c.ColumnName;
                            c.sqlType = c.sqlType != null && !c.sqlType.Equals("") ? c.sqlType : "VARCHAR(40)";
                            texbType.DataBindings.Add("Text", c, "sqlType");
                            texbType.Location = new Point(txbX2, txbY);
                            tab.Controls.Add(texbType);
                            txbY+=26;
                        }
                    }
                    dtcTables.TabPages.Add(tab);
                }
            }
        }


        private void getLocalizedLabelsMessages()
        {
            CultureInfo language = Thread.CurrentThread.CurrentUICulture;
            Localization.Localization loc = new Localization.Localization();
            this.Text = loc.getLocalizedResource(language,this.Name);
        }

        private void btnSaveColumns_Click(object sender, EventArgs e)
        {
            
            foreach (Table t in Tables)
            {
                foreach (Row r in t.Rows)
                {
                    for(int i = 0; i < r.Values.Count; i++)// KeyValue k in r.Values)
                    {
                        String columnName = t.Columns.ElementAt(i).ColumnName;
                        if(!columnName.Equals(r.Values.ElementAt(i)))
                        {
                            r.Values.ElementAt(i).Key = columnName;
                        }
                    }
                }
            }

            this.Close();
        }

        private Boolean columnExist(List<Column> columns, String columnName)
        {
            foreach (Column c in columns)
            {
                if (columnName.Equals(c.ColumnName))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
