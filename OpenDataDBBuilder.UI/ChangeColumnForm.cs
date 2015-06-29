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
        public TableList TablesList {get; set;}
        DBConfig dbconfig;
        String lblColumnText = "";
        String lblTypeText = "";
        String cbxSkipText = "";
        DatabaseHelper dbHelper;
        String errorMsgFK = "";

        String cbxDeafultValueText = "";

        public ChangeColumnForm(List<Table> tables, DBConfig dbconfig)
        {
            this.TablesList = new TableList(tables);
            this.dbconfig = dbconfig;
            this.dbHelper = new DatabaseHelper(dbconfig);
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
            int gpbxY = 3;

            dtcTables.TabPages.Clear();

            foreach (Table table in this.TablesList.Tables)
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
                            gpbx.Size = new System.Drawing.Size(696, 82);


                            CheckBox cbxSkip = new CheckBox();
                            cbxSkip.Text = cbxSkipText;
                            cbxSkip.Name = "SKIP" + c.OriginalColumnName;
                            cbxSkip.Size = new System.Drawing.Size(80, 17);
                            cbxSkip.Location = new Point(05, 05);
                            Binding bindSKIP = new Binding("Checked", c, "SKIP");
                            bindSKIP.Format += SwitchBool;
                            bindSKIP.Parse += SwitchBool;
                            cbxSkip.Click += isSKIPClicked;
                            cbxSkip.DataBindings.Add(bindSKIP);
                            gpbx.Controls.Add(cbxSkip);

                            TextBox texb = new TextBox();
                            texb.Name = c.OriginalColumnName;
                            texb.DataBindings.Add("Text", c,"ColumnName");
                            texb.Size = new System.Drawing.Size(100, 20);
                            texb.Location = new Point(13, 34);
                            gpbx.Controls.Add(texb);

                            TextBox texbType = new TextBox();
                            texbType.Name = "TYPE" + c.OriginalColumnName;
                            c.sqlType = c.sqlType != null && !c.sqlType.Equals("") ? c.sqlType : "VARCHAR(40)";
                            texbType.DataBindings.Add("Text", c, "sqlType");
                            texbType.Size = new System.Drawing.Size(121, 21);
                            texbType.Location = new Point(129, 33);
                            gpbx.Controls.Add(texbType);

                            CheckBox cbxIsPK = new CheckBox();
                            cbxIsPK.Text = "PK";
                            cbxIsPK.Name = "ISPK" + c.OriginalColumnName;                           
                            cbxIsPK.Size = new System.Drawing.Size(40, 17);
                            cbxIsPK.Location = new Point(259, 19);
                            Binding bindPK = new Binding("Checked", c, "IsPK");
                            bindPK.Format += SwitchBool;
                            bindPK.Parse += SwitchBool;
                            cbxIsPK.Click += isPKClicked;
                            cbxIsPK.DataBindings.Add(bindPK);
                            gpbx.Controls.Add(cbxIsPK);

                            CheckBox cbxIsFK = new CheckBox();
                            cbxIsFK.Text = "FK";
                            cbxIsFK.Name = "ISFK" + c.OriginalColumnName;
                            cbxIsFK.Size = new System.Drawing.Size(40, 17);
                            cbxIsFK.Location = new Point(259, 53);                            
                            Binding bindFK = new Binding("Checked", c, "IsFK");
                            bindFK.Format += SwitchBool;
                            bindFK.Parse += SwitchBool;
                            cbxIsFK.DataBindings.Add(bindFK);
                            cbxIsFK.Click += isFKClicked;
                            gpbx.Controls.Add(cbxIsFK);
                            if (c.IsFK)
                                addSelectedCbxs(ref gpbx, c);

                            CheckBox cbxIsNullable = new CheckBox();
                            cbxIsNullable.Text = "Null";
                            cbxIsNullable.Name = "ISNULLABLE" + c.OriginalColumnName;
                            cbxIsNullable.Size = new System.Drawing.Size(44, 17);
                            cbxIsNullable.Location = new Point(305, 19);
                            Binding bindNullable = new Binding("Checked", c, "IsNullable");
                            bindNullable.Format += SwitchBool;
                            bindNullable.Parse += SwitchBool;
                            cbxIsNullable.DataBindings.Add(bindNullable);
                            cbxIsNullable.Click += isNullableClicked;
                            gpbx.Controls.Add(cbxIsNullable);

                            CheckBox cbxIsUnique = new CheckBox();
                            cbxIsUnique.Text = "UNI";
                            cbxIsUnique.Name = "ISUNI" + c.OriginalColumnName;
                            cbxIsUnique.Size = new System.Drawing.Size(45, 17);
                            cbxIsUnique.Location = new Point(353, 19);
                            Binding bindUnique = new Binding("Checked", c, "IsUnique");
                            bindUnique.Format += SwitchBool;
                            bindUnique.Parse += SwitchBool;
                            cbxIsUnique.DataBindings.Add(bindUnique);
                            cbxIsUnique.Click += isUniqueClicked;
                            gpbx.Controls.Add(cbxIsUnique);

                            CheckBox cbxDeafultValue = new CheckBox();
                            cbxDeafultValue.Text = cbxDeafultValueText;
                            cbxDeafultValue.Name = "DEFVALUE" + c.OriginalColumnName;
                            cbxDeafultValue.Size = new System.Drawing.Size(93, 17);
                            cbxDeafultValue.Location = new Point(403, 19);
                            cbxDeafultValue.Click += cbxDeafultValueClicked;
                            gpbx.Controls.Add(cbxDeafultValue);
                            if (c.defaulValue != null && !"".Equals(c.defaulValue))
                            {
                                cbxDeafultValue.Checked = true;
                                addTxbDefValue(gpbx, c);
                            }
                            gpbx.Location = new Point(gpbxX,gpbxY);
                            tab.Controls.Add(gpbx);
                            gpbxY += 82;
                        }
                    }
                    tab.AutoScroll = true;
                    dtcTables.TabPages.Add(tab);
                }
            }
        }

        private void isSKIPClicked(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                foreach (Control c in ((Control)sender).Parent.Controls)
                {
                    if (!c.Name.Contains("SKIP"))
                        c.Enabled = false;
                    else
                        c.Enabled = true;
                }
            }
            else
            {
                foreach (Control c in ((Control)sender).Parent.Controls)
                    c.Enabled = true;
            }
            
            
        }

        private void addTxbDefValue(GroupBox gpbx, Column c)
        {
            if (gpbx != null)
            {
                TextBox txbDefValue = new TextBox();
                txbDefValue.Name = "txbDefValue" + c.OriginalColumnName;
                txbDefValue.DataBindings.Add("Text", c, "defaulValue");
                txbDefValue.Size = new System.Drawing.Size(100, 20);
                txbDefValue.Location = new Point(500, 17);
                gpbx.Controls.Add(txbDefValue);
            }
        }
        private void removeTxbDefValue(GroupBox gpbx, Column c)
        {
            if (gpbx != null)
            {
                gpbx.Controls.Remove(gpbx.Controls["txbDefValue" + c.OriginalColumnName]);
            }
        }
        private void cbxDeafultValueClicked(object sender, EventArgs e)
        {
            String tableName = ((Control)sender).Parent.Parent.Name.Replace("TAB", "");
            String originalColumnName = ((Control)sender).Name.Replace("DEFVALUE", "");
            foreach (Table t in this.TablesList.Tables)
            {
                if (t.TableName.Equals(tableName))
                {
                    foreach (Column c in t.Columns)
                    {
                        if (c.OriginalColumnName.Equals(originalColumnName))
                        {
                            if (((CheckBox)sender).Checked)
                                addTxbDefValue(((GroupBox)((CheckBox)sender).Parent), c);
                            else
                                removeTxbDefValue(((GroupBox)((CheckBox)sender).Parent), c);
                            break;
                        }
                    }
                    break;
                }
            }
        }

        private void isPKClicked(object sender, EventArgs e)
        {
            String originalColumnName = ((Control)sender).Name.Replace("ISPK", "");
            if (((CheckBox)sender).Checked)
            {
                ((CheckBox)((Control)sender).Parent.Controls["ISUNI" + originalColumnName]).Checked = false;
                ((Control)sender).Parent.Controls["ISUNI" + originalColumnName].Enabled = false;
                ((CheckBox)((Control)sender).Parent.Controls["ISNULLABLE" + originalColumnName]).Checked = false;
                ((Control)sender).Parent.Controls["ISNULLABLE" + originalColumnName].Enabled = false;
            }
            else
            {
                ((Control)sender).Parent.Controls["ISUNI" + originalColumnName].Enabled = true;
                ((Control)sender).Parent.Controls["ISNULLABLE" + originalColumnName].Enabled = true;
            }
        }

        private void isUniqueClicked(object sender, EventArgs e)
        {
            String originalColumnName = ((Control)sender).Name.Replace("ISUNI", "");
            if (((CheckBox)sender).Checked)
            {
                ((CheckBox)((Control)sender).Parent.Controls["ISPK" + originalColumnName]).Checked = false;
                ((Control)sender).Parent.Controls["ISPK" + originalColumnName].Enabled = false;
                ((CheckBox)((Control)sender).Parent.Controls["ISNULLABLE" + originalColumnName]).Checked = false;
                ((Control)sender).Parent.Controls["ISNULLABLE" + originalColumnName].Enabled = false;
            }
            else
            {
                ((Control)sender).Parent.Controls["ISPK" + originalColumnName].Enabled = true;
                ((Control)sender).Parent.Controls["ISNULLABLE" + originalColumnName].Enabled = true;
            }
        }

        private void isNullableClicked(object sender, EventArgs e)
        {
            String originalColumnName = ((Control)sender).Name.Replace("ISNULLABLE", "");
            if (((CheckBox)sender).Checked)
            {
                ((CheckBox)((Control)sender).Parent.Controls["ISPK" + originalColumnName]).Checked = false;
                ((Control)sender).Parent.Controls["ISPK" + originalColumnName].Enabled = false;
                ((CheckBox)((Control)sender).Parent.Controls["ISUNI" + originalColumnName]).Checked = false;
                ((Control)sender).Parent.Controls["ISUNI" + originalColumnName].Enabled = false;
            }
            else
            {
                ((Control)sender).Parent.Controls["ISPK" + originalColumnName].Enabled = true;
                ((Control)sender).Parent.Controls["ISUNI" + originalColumnName].Enabled = true;
            }
        }

        private void addSelectedCbxs(ref GroupBox gpbx, Column c)
        {
            if (gpbx != null)
            {
                String tableName = gpbx.Parent == null ? c.Reference.Key.Split('.')[0] : gpbx.Parent.Text;
                ComboBox cbxDataBases = new ComboBox();
                cbxDataBases.Location = new Point(305, 53);
                cbxDataBases.Name = "cbxDataBases";
                cbxDataBases.DrawMode = DrawMode.OwnerDrawFixed;
                cbxDataBases.DrawItem += onDrawnCbxItem;
                List<String> dataBases = getDataBasesNames();
                
                foreach (String s in dataBases)
                    cbxDataBases.Items.Add(s);
                    
                if (c != null && c.Reference != null && c.Reference.Key != null)
                    cbxDataBases.SelectedItem = c.Reference.Key.Split('.')[0];

                cbxDataBases.SelectedValueChanged += onCbxValueChange;

                ComboBox cbxTables = new ComboBox();
                cbxTables.DrawMode = DrawMode.OwnerDrawFixed;
                cbxTables.DrawItem += onDrawnCbxItem;
                cbxTables.Location = new Point(432, 53);
                cbxTables.Name = "cbxTables";
                if (cbxDataBases.SelectedItem != null && !cbxDataBases.SelectedItem.ToString().Equals(""))
                {
                    List<String> tables = getTablesListFromDB(cbxDataBases.SelectedItem.ToString());
                   
                    foreach (String s in tables)
                           cbxTables.Items.Add(s);

                    if (cbxDataBases.SelectedItem.ToString().Equals(dbconfig.DbName))
                        foreach (String t in TablesList.TablesNames)
                            if (!t.Equals(tableName))
                               cbxTables.Items.Add(t);
                    
                    if (c != null && c.Reference != null && c.Reference.Key != null)
                        cbxTables.SelectedItem = c.Reference.Key.Split('.')[1];
                }
                cbxTables.SelectedValueChanged += onCbxValueChange;

                ComboBox cbxFields = new ComboBox();
                cbxFields.DrawMode = DrawMode.OwnerDrawFixed;
                cbxFields.DrawItem += onDrawnCbxItem;
                cbxFields.Location = new Point(559, 53);
                cbxFields.Name = "cbxFields";
                if ((cbxDataBases.SelectedItem != null && !cbxDataBases.SelectedItem.ToString().Equals(""))
                    && (cbxTables.SelectedItem != null && !cbxTables.SelectedItem.ToString().Equals("")))
                {
                    List<String> fields;
                    bool isTableToCreate = false;
                    Table tableSelected = null;
                    TablesList.Tables.ForEach(t => 
                    {
                        isTableToCreate = t.TableName.Equals(cbxTables.SelectedItem.ToString());
                        tableSelected = t;
                    });
                    if (isTableToCreate)
                    {
                        tableSelected.Columns.ForEach(column =>
                        {
                            cbxFields.Items.Add(column.ColumnName);
                        });
                    }
                    else
                    {
                        fields = getFieldListFromDBTable(cbxDataBases.SelectedItem.ToString(), cbxTables.SelectedItem.ToString());
                        foreach (String s in fields)
                            cbxFields.Items.Add(s);
                    }
                    
                    if (c != null && c.Reference != null && c.Reference.Key != null)
                        cbxFields.SelectedItem = c.Reference.Value.ToString();
                }
                cbxFields.SelectedValueChanged += onCbxValueChange;

                gpbx.Controls.Add(cbxDataBases);
                gpbx.Controls.Add(cbxTables);
                gpbx.Controls.Add(cbxFields);
            }
        }

        private void onDrawnCbxItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();        
            string text = ((ComboBox)sender).Items[e.Index].ToString();
            string tableName = ((ComboBox)sender).Parent.Parent.Name.Replace("TAB","");
            string cbxName = ((ComboBox)sender).Name;
            Table table = null;
            TablesList.Tables.ForEach(t =>
            {
                if(t.TableName.Equals(tableName))
                {
                    table = t;
                }
            });
            Brush brush = null;
            if (cbxName.Equals("cbxDataBases"))
            {
                if (text.Equals(dbconfig.DbName))
                    brush = Brushes.Blue;
                else
                    brush = Brushes.Black;
            }
            else if (cbxName.Equals("cbxTables"))
            {
                if (TablesList.TablesNames.Contains(text))
                    brush = Brushes.Red;
                else
                    brush = Brushes.Black;
            }
            else if (cbxName.Equals("cbxFields"))
            {
                if (table.columnNames().Contains(text))
                    brush = Brushes.Red;
                else
                    brush = Brushes.Black;
            }
            
            e.Graphics.DrawString(text, ((Control)sender).Font, brush, e.Bounds.X, e.Bounds.Y);
        }

        private void onCbxValueChange(object sender, EventArgs e)
        {
            String name = ((Control)sender).Name;
            String originalColumnName = "";
            ComboBox dbCbx = null;
            ComboBox tableCbx = null;
            ComboBox fieldsCbx = null;
            String selectedDB;
            foreach (Control c in ((ComboBox)sender).Parent.Controls)
            {
                if (c.Name.Contains("ISPK"))
                    originalColumnName = c.Name.Replace("ISPK", "");
                else if(c.Name.Contains("cbxDataBases"))
                    dbCbx = c as ComboBox;
                else if(c.Name.Contains("cbxTables"))
                    tableCbx = c as ComboBox;
                else if(c.Name.Contains("cbxFields"))
                    fieldsCbx = c as ComboBox;
            }
            foreach (Table t in TablesList.Tables)
            {
                if (t.TableName.Equals(((ComboBox)sender).Parent.Parent.Text))
                {
                    foreach (Column c in t.Columns)
                    {
                        if (c.OriginalColumnName.Equals(originalColumnName))
                        {
                            if (name.Contains("cbxDataBases"))
                            {
                                selectedDB = ((ComboBox)sender).SelectedItem != null ? ((ComboBox)sender).SelectedItem.ToString() : "";
                                if (!selectedDB.Equals(""))
                                {
                                    tableCbx.Items.Clear();
                                    tableCbx.SelectedItem = null;
                                    tableCbx.Text = "";
                                    tableCbx.DrawItem += onDrawnCbxItem;
                                    fieldsCbx.Items.Clear();
                                    fieldsCbx.SelectedItem = null;
                                    fieldsCbx.Text = "";
                                    List<String> tables = getTablesListFromDB(((ComboBox)sender).SelectedItem.ToString());
                                    foreach (String s in tables)
                                        tableCbx.Items.Add(s);
                                    if (selectedDB.Equals(dbconfig.DbName))
                                        tableCbx.Items.AddRange(TablesList.TablesNames.ToArray());

                                }
                                else
                                    tableCbx.Items.Clear();

                                String tableName = tableCbx.SelectedItem != null ? tableCbx.SelectedItem.ToString() : "";
                                c.Reference = c.Reference == null ? new KeyValue() : c.Reference;
                                c.Reference.Key = ((ComboBox)sender).SelectedItem.ToString() + "." + tableName;
                                return;
                            }
                            selectedDB = dbCbx.SelectedItem != null ? dbCbx.SelectedItem.ToString() : "";
                            if (name.Contains("cbxTables"))
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
                                    if (selectedDB.Equals(dbconfig.DbName) && TablesList.TablesNames.Contains(selectedTable))
                                        fieldsCbx.Items.AddRange(t.columnNames().ToArray());
                                }
                                else
                                    fieldsCbx.Items.Clear();

                                c.Reference.Key = dbconfig.DbName + "." + ((ComboBox)sender).SelectedItem;
                                return;
                            }
                            if (name.Contains("cbxFields"))
                            {
                                c.Reference.Value = ((ComboBox)sender).SelectedItem;
                                return;
                            }
                        }
                    }
                }
            }
                
        }

        private void isFKClicked(object sender, EventArgs e)
        {
            GroupBox gpbx = ((CheckBox)sender).Parent as GroupBox;
            String tableName = ((CheckBox)sender).Parent.Parent.Name.Replace("TAB","");
            String originalColumnName = ((CheckBox)sender).Name.Replace("ISFK", "");


            foreach (Table t in TablesList.Tables)
            {
                if (t.TableName.Equals(tableName))
                {
                    foreach (Column c in t.Columns)
                    {
                        if (c.OriginalColumnName.Equals(originalColumnName))
                        {
                            if (((CheckBox)sender).Checked)
                            {
                                addSelectedCbxs(ref gpbx, c);
                                break;
                            }
                            else
                            {
                                c.Reference = null;
                                break;
                            }
                        }
                    }
                    break;
                }
            }
           
            if(!((CheckBox)sender).Checked)
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
            this.lblUsedDB.Text = loc.getLocalizedResource(language, this.lblUsedDB.Name);
            this.lblTableColumn.Text = loc.getLocalizedResource(language, this.lblTableColumn.Name);
            this.cbxDeafultValueText = loc.getLocalizedResource(language, "cbxDeafultValue");            
            lblColumnText = loc.getLocalizedResource(language, "lblColumnText");
            lblTypeText = loc.getLocalizedResource(language, "lblTypeText");
            errorMsgFK = loc.getLocalizedResource(language, "errorMsgFK");
            cbxSkipText = loc.getLocalizedResource(language, "cbxSkipText");
        }

        private void updateIsFKFalse(String tableName, String columnName)
        {
            foreach (Table t in TablesList.Tables)
            {
                if (t.TableName.Equals(tableName))
                {
                    foreach (Column c in t.Columns)
                    {
                        if (c.ColumnName.Equals(columnName))
                        {
                            c.Reference = null;
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
                        Boolean isPK = false;
                        Boolean isNULL = false;
                        Boolean isUnique = false;
                        Boolean hasDefaulValue = false;
                        Boolean skip = false;

                        Boolean isFK = false;
                        Boolean isDBEmpty = false;
                        Boolean isTableEmpty = false;
                        Boolean isFieldEmpty = false;
                        String originalColumnName = "";
                        for (int i = 0; i <= groupBox.Controls.Count; i++ )
                        {
                            if (i < groupBox.Controls.Count)
                            {
                                Control c = groupBox.Controls[i];
                                if (c.Name.Contains("SKIP"))
                                {
                                    skip = ((CheckBox)c).Checked;
                                }                               
                                
                                if (c.Name.Contains("ISPK"))
                                {
                                    isPK = ((CheckBox)c).Checked;
                                    originalColumnName = c.Name.Replace("ISPK","");
                                }

                                if (c.Name.Contains("ISNULLABLE"))
                                {
                                    isNULL = ((CheckBox)c).Checked;
                                }

                                if (c.Name.Contains("ISUNI"))
                                {
                                    isUnique = ((CheckBox)c).Checked;
                                }

                                if (c.Name.Contains("DEFVALUE"))
                                {
                                    hasDefaulValue = ((CheckBox)c).Checked;
                                }

                                if (c.Name.Contains("ISFK"))
                                {
                                    isFK = ((CheckBox)c).Checked;
                                }
                            }
                            else
                            {
                                foreach (Table t in TablesList.Tables)
                                {
                                    if (t.TableName.Equals(ctrl.Name.Replace("TAB", "")))
                                    {
                                        foreach (Column c in t.Columns)
                                        {
                                            if (c.OriginalColumnName.Equals(originalColumnName))
                                            {
                                                c.SKIP = skip;
                                                c.IsPK = isPK;
                                                c.IsUnique = isUnique;
                                                c.IsNullable = isNULL;
                                                if (hasDefaulValue)
                                                {
                                                    c.defaulValue = ((TextBox)groupBox.Controls["txbDefValue"]).Text;
                                                }
                                                if (isFK)
                                                {
                                                    if (((ComboBox)groupBox.Controls["cbxDataBases"]).SelectedItem == null ||
                                                        ((ComboBox)groupBox.Controls["cbxDataBases"]).SelectedItem.ToString().Equals(""))
                                                        isDBEmpty = true;
                                                    if (((ComboBox)groupBox.Controls["cbxTables"]).SelectedItem == null ||
                                                        ((ComboBox)groupBox.Controls["cbxTables"]).SelectedItem.ToString().Equals(""))
                                                        isTableEmpty = true;
                                                    if (((ComboBox)groupBox.Controls["cbxFields"]).SelectedItem == null ||
                                                        ((ComboBox)groupBox.Controls["cbxFields"]).SelectedItem.ToString().Equals(""))
                                                        isFieldEmpty = true;
                                                    if (isFK && (isDBEmpty || isTableEmpty || isFieldEmpty))
                                                    {
                                                        c.IsFK = false;
                                                    }                                                        
                                                    else
                                                    {
                                                        c.IsFK = true;
                                                        c.Reference = new KeyValue(((ComboBox)groupBox.Controls["cbxDataBases"]).SelectedItem.ToString() + "." + ((ComboBox)groupBox.Controls["cbxTables"]).SelectedItem.ToString(),
                                                            ((ComboBox)groupBox.Controls["cbxFields"]).SelectedItem.ToString());
                                                    }
                                                }
                                                break;
                                            }
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }


            foreach (Table t in TablesList.Tables)
            { 
                foreach(TabPage tabPage in this.dtcTables.TabPages)
                {
                    if (tabPage.Name.Replace("TAB", "").Equals(t.TableName))
                    {
                        foreach (Control ctrlGpbx in tabPage.Controls.Find("gpbx", true))
                        {
                            foreach (Column c in t.Columns)
                            {
                                if (ctrlGpbx.Controls.Find(c.OriginalColumnName, true).Count() > 0)
                                {
                                    String columnName = ((TextBox)ctrlGpbx.Controls.Find(c.OriginalColumnName, true)[0]).Text;
                                    c.ColumnName = columnName == null || columnName.Equals("") ? c.ColumnName : columnName;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            foreach (Table t in TablesList.Tables)
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
