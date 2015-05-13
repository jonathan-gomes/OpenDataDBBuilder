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
    public partial class ChangeColumnForm : Form
    {
        String db = "";
        public List<Table> Tables {get; set;}
        String lblColumnText = "";
        String lblTypeText = "";
        DatabaseHelper dbHelper;
        String errorMsgFK = "";

        public ChangeColumnForm(List<Table> tables, String db)
        {
            this.Tables = tables;
            this.db = db;
            this.dbHelper = new DatabaseHelper(db);
            InitializeComponent();
            getLocalizedLabelsMessages();
            getDefaultValues();
            createTablesView();
            
        }

        public void getDefaultValues()
        {
            this.Icon = Properties.Resources.icooddb;
        }
        private void createTablesView()
        {
            int gpbxX = 6;
            int gpbxY = 1;

            dtcTables.TabPages.Clear();

            foreach (Table table in this.Tables)
            {
                if (table != null)
                {
                    TabPage tab = new TabPage(table.TableName.ToString());
                    tab.Name = "TAB"+table.TableName;
                    if (table.Columns != null)
                    {
                        foreach (Column c in table.Columns)
                        {
                            GroupBox gpbx = new GroupBox();
                            gpbx.Name = "gpbx";
                            gpbx.Size = new System.Drawing.Size(747, 56);

                            TextBox texb = new TextBox();
                            texb.Name = c.ColumnName;
                            texb.DataBindings.Add("Text", c,"ColumnName");
                            texb.Location = new Point(16, 19);
                            gpbx.Controls.Add(texb);

                            TextBox texbType = new TextBox();
                            texbType.Name = "TYPE"+c.ColumnName;
                            c.sqlType = c.sqlType != null && !c.sqlType.Equals("") ? c.sqlType : "VARCHAR(40)";
                            texbType.DataBindings.Add("Text", c, "sqlType");
                            texbType.Location = new Point(132, 19);
                            gpbx.Controls.Add(texbType);

                            CheckBox cbxIsPK = new CheckBox();
                            cbxIsPK.Text = "PK";
                            cbxIsPK.Name = "ISPK" + c.ColumnName;                           
                            cbxIsPK.Location = new Point(259, 19);
                            cbxIsPK.Size = new System.Drawing.Size(40, 17);
                            Binding bind = new Binding("Checked", c, "IsPK");
                            bind.Format += SwitchBool;
                            bind.Parse += SwitchBool;
                            cbxIsPK.DataBindings.Add(bind);
                            gpbx.Controls.Add(cbxIsPK);

                            CheckBox cbxIsFK = new CheckBox();
                            cbxIsFK.Text = "FK";
                            cbxIsFK.Name = "ISFK" + c.ColumnName;
                            cbxIsFK.Location = new Point(305, 19);
                            cbxIsFK.Size = new System.Drawing.Size(40, 17);
                            Binding bindFK = new Binding("Checked", c, "IsFK");
                            bind.Format += SwitchBool;
                            bind.Parse += SwitchBool;
                            cbxIsFK.DataBindings.Add(bindFK);
                            cbxIsFK.Click += isFKClicked;
                            gpbx.Controls.Add(cbxIsFK);
                            if (c.IsFK)
                                addSelectedCbxs(ref gpbx, c);

                            gpbx.Location = new Point(gpbxX,gpbxY);
                            tab.Controls.Add(gpbx);
                            gpbxY += 55;
                        }
                    }
                    tab.AutoScroll = true;
                    dtcTables.TabPages.Add(tab);
                }
            }
        }

        private void addSelectedCbxs(ref GroupBox gpbx, Column c)
        {
            if (gpbx != null)
            {
                ComboBox cbxDataBases = new ComboBox();
                cbxDataBases.Location = new Point(351, 19);
                cbxDataBases.Name = "cbxDataBases";
                List<String> dataBases = getDataBasesNames();
                foreach (String s in dataBases)
                    cbxDataBases.Items.Add(s);
                if (c != null && c.Reference != null && c.Reference.Key != null)
                    cbxDataBases.SelectedItem = c.Reference.Key.Split('.')[0];
                cbxDataBases.SelectedValueChanged += onCbxValueChange;

                ComboBox cbxTables = new ComboBox();
                cbxTables.Location = new Point(478, 19);
                cbxTables.Name = "cbxTables";
                if (cbxDataBases.SelectedItem != null && !cbxDataBases.SelectedItem.ToString().Equals(""))
                {
                    List<String> tables = getTablesListFromDB(cbxDataBases.SelectedItem.ToString());
                    foreach (String s in tables)
                           cbxTables.Items.Add(s);
                    if (c != null && c.Reference != null && c.Reference.Key != null)
                        cbxTables.SelectedItem = c.Reference.Key.Split('.')[1];
                }
                cbxTables.SelectedValueChanged += onCbxValueChange;

                ComboBox cbxFields = new ComboBox();
                cbxFields.Location = new Point(605, 19);
                cbxFields.Name = "cbxFields";
                if ((cbxDataBases.SelectedItem != null && !cbxDataBases.SelectedItem.ToString().Equals(""))
                    && (cbxTables.SelectedItem != null && !cbxTables.SelectedItem.ToString().Equals("")))
                {
                    List<String> fields = getFieldListFromDBTable(cbxDataBases.SelectedItem.ToString(), cbxTables.SelectedItem.ToString());
                    foreach (String s in fields)
                        cbxFields.Items.Add(s);
                    if (c != null && c.Reference != null && c.Reference.Key != null)
                        cbxFields.SelectedItem = c.Reference.Value.ToString();
                }
                cbxFields.SelectedValueChanged += onCbxValueChange;

                gpbx.Controls.Add(cbxDataBases);
                gpbx.Controls.Add(cbxTables);
                gpbx.Controls.Add(cbxFields);
            }
        }

        private void onCbxValueChange(object sender, EventArgs e)
        {
            String name = ((Control)sender).Name;
            String columnName = "";
            ComboBox dbCbx = null;
            ComboBox tableCbx = null;
            ComboBox fieldsCbx = null;
            
            foreach (Control c in ((ComboBox)sender).Parent.Controls)
            {
                if (c.Name.Contains("ISPK"))
                    columnName = c.Name.Replace("ISPK", "");
                else if(c.Name.Contains("cbxDataBases"))
                    dbCbx = c as ComboBox;
                else if(c.Name.Contains("cbxTables"))
                    tableCbx = c as ComboBox;
                else if(c.Name.Contains("cbxFields"))
                    fieldsCbx = c as ComboBox;
            }
            if (name.Contains("cbxDataBases"))
            {
                foreach (Table t in Tables)
                {
                    if (t.TableName.Equals(((ComboBox)sender).Parent.Parent.Text))
                    {
                        foreach (Column c in t.Columns)
                        {
                            if (c.ColumnName.Equals(columnName))
                            {
                                String selectedDB = ((ComboBox)sender).SelectedItem != null ? ((ComboBox)sender).SelectedItem.ToString() : "";
                                if (!selectedDB.Equals(""))
                                {
                                    tableCbx.Items.Clear();
                                    tableCbx.SelectedItem = null;
                                    tableCbx.Text = "";
                                    fieldsCbx.Items.Clear();
                                    fieldsCbx.SelectedItem = null;
                                    fieldsCbx.Text = "";
                                    List<String> tables = getTablesListFromDB(((ComboBox)sender).SelectedItem.ToString());
                                    foreach (String s in tables)
                                        tableCbx.Items.Add(s);
                                }
                                else
                                    tableCbx.Items.Clear();

                                String tableName = tableCbx.SelectedItem != null ? tableCbx.SelectedItem.ToString() : "";
                                c.Reference = c.Reference == null ? new KeyValue() : c.Reference;
                                c.Reference.Key = ((ComboBox)sender).SelectedItem.ToString() + "." + tableName;
                            }
                        }
                    }
                }
            }

            if (name.Contains("cbxTables"))
            {
                foreach (Table t in Tables)
                {
                    if (t.TableName.Equals(((ComboBox)sender).Parent.Parent.Text))
                    {
                        foreach (Column c in t.Columns)
                        {
                            if (c.ColumnName.Equals(columnName))
                            {
                                String selectedTable = ((ComboBox)sender).SelectedItem != null ? ((ComboBox)sender).SelectedItem.ToString() : "";
                                if (!selectedTable.Equals(""))
                                {
                                    fieldsCbx.Items.Clear();
                                    fieldsCbx.SelectedItem = null;
                                    fieldsCbx.Text = "";
                                    List<String> tables = getFieldListFromDBTable(dbCbx.SelectedItem.ToString(), ((ComboBox)sender).SelectedItem.ToString());
                                    foreach (String s in tables)
                                        fieldsCbx.Items.Add(s);
                                }
                                else
                                    fieldsCbx.Items.Clear();
                      
                                String dbName = dbCbx.SelectedItem != null ? dbCbx.SelectedItem.ToString() : "";
                                c.Reference.Key = dbName + "." + ((ComboBox)sender).SelectedItem;
                            }
                        }
                    }
                }
            }

            if (name.Contains("cbxFields"))
            {
                foreach (Table t in Tables)
                {
                    if (t.TableName.Equals(((ComboBox)sender).Parent.Parent.Text))
                    {
                        foreach (Column c in t.Columns)
                        {
                            if (c.ColumnName.Equals(columnName))
                            {
                                c.Reference.Value = ((ComboBox)sender).SelectedItem;
                            }
                        }
                    }
                }
            }
                
        }

        private void isFKClicked(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                GroupBox gpbx = ((CheckBox)sender).Parent as GroupBox;
                String tableName = ((CheckBox)sender).Parent.Parent.Name.Replace("TAB","");
                String columnName = ((CheckBox)sender).Name.Replace("ISFK","");

                foreach (Table t in Tables)
                {
                    if (t.TableName.Equals(tableName))
                    {
                        foreach (Column c in t.Columns)
                        {
                            if (c.ColumnName.Equals(columnName))
                            {
                                addSelectedCbxs(ref gpbx, c);
                                break;
                            }
                        }
                        break;
                    }
                }         
            }
                
            else 
            {
                Control controlcbxDataBases = ((CheckBox)sender).Parent.Controls.Find("cbxDataBases", true)[0];
                Control controlcbxTables = ((CheckBox)sender).Parent.Controls.Find("cbxTables", true)[0];
                Control controlcbxFields = ((CheckBox)sender).Parent.Controls.Find("cbxFields", true)[0];
                ((CheckBox)sender).Parent.Controls.Remove(controlcbxDataBases);
                ((CheckBox)sender).Parent.Controls.Remove(controlcbxTables);
                ((CheckBox)sender).Parent.Controls.Remove(controlcbxFields);
            }
        }
        private void SwitchBool(object sender, ConvertEventArgs e)
        {
            if (e.Value == null)
                e.Value = false;
            else
                e.Value = (bool)e.Value;
        }
        
        private void getLocalizedLabelsMessages()
        {
            CultureInfo language = Thread.CurrentThread.CurrentUICulture;
            Localization.Localization loc = new Localization.Localization();
            this.Text = loc.getLocalizedResource(language,this.Name);
            lblColumnText = loc.getLocalizedResource(language, "lblColumnText");
            lblTypeText = loc.getLocalizedResource(language, "lblTypeText");
            errorMsgFK = loc.getLocalizedResource(language, "errorMsgFK");
        }

        private void updateIsFKFalse(String tableName, String columnName)
        {
            foreach (Table t in Tables)
            {
                if (t.TableName.Equals(tableName))
                {
                    foreach (Column c in t.Columns)
                    {
                        if (c.ColumnName.Equals(columnName))
                        {
                            c.IsFK = false;
                            break;
                        }
                    }
                    break;
                }
            }
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

        private List<String> getDataBasesNames()
        {
            return dbHelper.selectDataBases();
        }
        private List<String> getTablesListFromDB(String dataBase)
        {
            return dbHelper.getTablesFromDataBase(dataBase);
        }
        private List<String> getFieldListFromDBTable(String dataBase, String table)
        {
            return dbHelper.getFieldListFromDBTable(dataBase,table);
        }

        private void showInfoErrorForm(String msg)
        {
            InfoErrorDialogForm infoErrorDialogForm = new InfoErrorDialogForm(true, msg);
            infoErrorDialogForm.StartPosition = FormStartPosition.CenterScreen;
            infoErrorDialogForm.ShowDialog();
            infoErrorDialogForm.Dispose();
        }

        private void ChangeColumnForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Control ctrl in this.Controls["tableLayoutPanel1"].Controls["dtcTables"].Controls)
            {
                if (ctrl.Name.Contains("TAB"))
                {
                    foreach (Control groupBox in ctrl.Controls.Find("gpbx", true))
                    {
                        Boolean isFK = false;
                        Boolean isDBEmpty = false;
                        Boolean isTableEmpty = false;
                        Boolean isFieldEmpty = false;
                        String columnName = "";
                        foreach (Control c in groupBox.Controls)
                        {
                            if (c.Name.Contains("ISFK"))
                            {
                                isFK = ((CheckBox)c).Checked;
                                if (isFK)
                                {
                                    columnName = c.Name.Replace("ISFK", "");
                                    if (((ComboBox)groupBox.Controls["cbxDataBases"]).SelectedItem == null || ((ComboBox)groupBox.Controls["cbxDataBases"]).SelectedItem.ToString().Equals(""))
                                        isDBEmpty = true;
                                    if (((ComboBox)groupBox.Controls["cbxTables"]).SelectedItem == null || ((ComboBox)groupBox.Controls["cbxTables"]).SelectedItem.ToString().Equals(""))
                                        isTableEmpty = true;
                                    if (((ComboBox)groupBox.Controls["cbxFields"]).SelectedItem == null || ((ComboBox)groupBox.Controls["cbxFields"]).SelectedItem.ToString().Equals(""))
                                        isFieldEmpty = true;
                                    if (isFK && (isDBEmpty || isTableEmpty || isFieldEmpty))
                                        updateIsFKFalse(ctrl.Name.Replace("TAB", ""), columnName);
                                }
                            }
                        }
                    }
                }
            }


            foreach (Table t in Tables)
            { 
                foreach(TabPage tabPage in this.dtcTables.TabPages)
                {
                    if (tabPage.Name.Replace("TAB", "").Equals(t.TableName))
                    {
                        foreach (Control ctrlGpbx in tabPage.Controls.Find("gpbx", true))
                        {
                            foreach (Column c in t.Columns)
                            {
                                if(ctrlGpbx.Controls.Find(c.ColumnName, true).Count() > 0)
                                {
                                    String columnName = ((TextBox)ctrlGpbx.Controls.Find(c.ColumnName, true)[0]).Text;
                                    c.ColumnName = columnName == null || columnName.Equals("") ? c.ColumnName : columnName;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            foreach (Table t in Tables)
            {
                foreach (Row r in t.Rows)
                {
                    for (int i = 0; i < r.Values.Count; i++)// KeyValue k in r.Values)
                    {
                        String columnName = t.Columns.ElementAt(i).ColumnName;
                        if (!columnName.Equals(r.Values.ElementAt(i)))
                        {
                            r.Values.ElementAt(i).Key = columnName;
                        }
                    }
                }
            }
        }

    }
}
