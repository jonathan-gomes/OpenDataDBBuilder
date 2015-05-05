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
using OpenDataDBBuilder.UI.Components;
using OpenDataDBBuilder.Business.File.XML.Util;

using System.Globalization;
using System.Threading;
using OpenDataDBBuilder.UI.Localization;
using OpenDataDBBuilder.Business.File.Util;


namespace OpenDataDBBuilder.UI
{
    public partial class TablesForm : Form
    {
        String filePath;
        StartScreenForm startForm;
        List<Table> tables;

        String openFileDialogTitle = "openFileDialogTitleMsg";
        String openFileDialogTitleMsg = "";

        public TablesForm(List<Table> tables, StartScreenForm startForm)
        {
            this.startForm = startForm;
            InitializeComponent();
            getLocalizedLabelsMessages();
            this.Icon = Properties.Resources.icooddb;
            createTablesTabsView(tables);
            getDefaultValues();
        }

        private void createTablesTabsView(List<Table> tables)
        {
            this.tables = tables;
            dtcTables.TabPages.Clear();
            
            foreach (Table table in this.tables)
            {
                if (table != null)
                {
                    TabPage tab = new TabPage(table.TableName.ToString());
                    DataGridView dgvTable = new DataGridView();
                    dgvTable.Name = table.TableName;
                    dgvTable.Dock = DockStyle.Fill;
                    tab.Controls.Add(dgvTable);
                    dtcTables.TabPages.Add(tab);
                    if (table.Columns != null)
                    {
                        foreach (Column c in table.Columns)
                        {
                            addColumnDgvTable(c.ColumnName, dgvTable);
                        }
                    }

                    if (table.Rows != null)
                    {
                        foreach (Row r in table.Rows)
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            DataGridViewCell cell = null;
                            foreach (KeyValue k in r.Values)
                            {
                                for (int columnIndex = 0; columnIndex < dgvTable.Columns.Count; columnIndex++)
                                {
                                    if (k.Key.Equals(dgvTable.Columns[columnIndex].Name))
                                    {
                                        cell = new DataGridViewTextBoxCell();
                                        cell.Value = k.Value.ToString();
                                        int cellsCount = 0;
                                        if (row.Cells.Count > 0)
                                            cellsCount = row.Cells.Count - 1;
                                        if (columnIndex >= cellsCount)
                                            row.Cells.AddRange(getEmptyDataGridViewTextBoxCellRange(columnIndex - cellsCount));
                                        row.Cells[columnIndex] = cell;
                                        break;
                                    }
                                }
                            }
                            dgvTable.Rows.Add(row);
                        }
                    }

                }
            }
        }

        private void closeParentForm(object sender, FormClosedEventArgs e)
        {
            if (startForm != null)
                startForm.Close();
        }

        private void addColumnDgvTable(String name, DataGridView dgvTable)
        {
            DataGridViewColumn column = new DataGridViewColumn();
            column.Name = name;
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            column.CellTemplate = cell;
            dgvTable.Columns.Add(column);
        }

        private DataGridViewTextBoxCell[] getEmptyDataGridViewTextBoxCellRange(int range) 
        {
            range = range == 0 ? range + 1 : range;
            DataGridViewTextBoxCell[] cellsArray =  new DataGridViewTextBoxCell[range];
            int count = 0;
            while(count < range)
            {
                cellsArray[count] = new DataGridViewTextBoxCell();
                count++;
            }
            return cellsArray;
        }

        private void tsiOpenFile_Click(object sender, EventArgs e)
        {
            String validationMsg = "";
            openFileDialog.Filter = "|*.xml;*.csv;*.txt";
            openFileDialog.Title = openFileDialogTitleMsg;
            DialogResult result = openFileDialog.ShowDialog();
            
            
            if ("OK".Equals(result.ToString()))
            {
                filePath = openFileDialog.FileName.ToString();

                if (filePath.EndsWith("XML") || filePath.EndsWith("xml"))
                {
                    Application.DoEvents();
                    if (XMLFileUtil.IsValidXML(filePath, out validationMsg))
                    {
                        openFileDialog.Dispose();
                        List<Table> tables = XMLFileUtil.getTablesFromXMLFileNew(filePath);
                        createTablesTabsView(tables);
                    }
                }
                else
                {
                    Table table = FileUtil.getTableFromFile(filePath);
                    List<Table> tables = new List<Table>();
                    tables.Add(table);
                    createTablesTabsView(tables);
                }

            }
        }

        private void getLocalizedLabelsMessages()
        {
            CultureInfo language = Thread.CurrentThread.CurrentUICulture;
            Localization.Localization loc = new Localization.Localization();
            this.Text = loc.getLocalizedResource(language, this.Name);
            this.tsiFile.Text = loc.getLocalizedResource(language, this.tsiFile.Name);
            this.tsiOpenFile.Text = loc.getLocalizedResource(language, this.tsiOpenFile.Name);
            this.tsiOptions.Text = loc.getLocalizedResource(language, this.tsiOptions.Name);
            this.tsiLanguage.Text = loc.getLocalizedResource(language, this.tsiLanguage.Name);
            this.tsiTables.Text = loc.getLocalizedResource(language, this.tsiTables.Name);
            this.tsiEditColumns.Text = loc.getLocalizedResource(language, this.tsiEditColumns.Name);
            this.tsiCreate.Text = loc.getLocalizedResource(language, this.tsiCreate.Name);
            this.tsiPreviewSQL.Text = loc.getLocalizedResource(language, this.tsiPreviewSQL.Name);
            this.tsiTablesEdit.Text = loc.getLocalizedResource(language, this.tsiTablesEdit.Name);
            this.tsiCreateDatabase.Text = loc.getLocalizedResource(language, this.tsiCreateDatabase.Name);
            openFileDialogTitleMsg = loc.getLocalizedResource(language, openFileDialogTitle);
        }

        private void tsiLangEnglish_Click(object sender, EventArgs e)
        {
            tsiLangEnglish.Checked = true;
            tsiLangPortuguese.Checked = false;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            getLocalizedLabelsMessages();

        }

        private void tsiLangPortuguese_Click(object sender, EventArgs e)
        {
            tsiLangPortuguese.Checked = true;
            tsiLangEnglish.Checked = false;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-BR");
            getLocalizedLabelsMessages();
        }

        private void getDefaultValues()
        {
            if (Thread.CurrentThread.CurrentUICulture.Name.Equals("pt-BR"))
            {
                tsiLangPortuguese.Checked = true;
                tsiLangEnglish.Checked = false;
            }
            else if (Thread.CurrentThread.CurrentUICulture.Name.Equals("en-US"))
            {
                tsiLangEnglish.Checked = true;
                tsiLangPortuguese.Checked = false;
            }
        }

        private void tsiEditColumns_Click(object sender, EventArgs e)
        {
            ChangeColumnForm columnForm = new ChangeColumnForm(this.tables, startForm.Db);
            DialogResult result = columnForm.ShowDialog();
            if ("OK".Equals(result.ToString()))
            {
                createTablesTabsView(columnForm.Tables);
            }
            columnForm.Dispose();
        }

        private void tsiPreviewSQL_Click(object sender, EventArgs e)
        {
            String dataBaseName = "testeODDB";
            StringBuilder sql = new StringBuilder("CREATE DATABASE " + dataBaseName+";\n");
            sql.Append("USE " + dataBaseName + ";\n");

            prepareTablesSQL();

            foreach(Table t in tables){
                sql.Append(t.SQLcreate);
            }

            SQLPreviewForm sqlPreviewForm = new SQLPreviewForm(sql.ToString());
            sqlPreviewForm.ShowDialog();
            sqlPreviewForm.Dispose();
        }

        private void prepareTablesSQL()
        {
            foreach (Table t in tables)
            {
                StringBuilder sql =  new StringBuilder("CREATE TABLE " + t.TableName + " (\n");
                for (int i = 0; i < t.Columns.Count; i++)
                {
                    sql.Append(t.Columns.ElementAt(i).ColumnName + " " + t.Columns.ElementAt(i).sqlType);
                    if (i < t.Columns.Count - 1)
                        sql.Append(",\n");
                    else
                        sql.Append("\n");
                }
                sql.Append(");\n");
                t.SQLcreate = sql.ToString();
            }
        }

        private void tsiCreateDatabase_Click(object sender, EventArgs e)
        {
            DataBasesForm dataBasesForm = new DataBasesForm(startForm.Db);
            dataBasesForm.ShowDialog();
            dataBasesForm.Dispose();
        }
    }
}
