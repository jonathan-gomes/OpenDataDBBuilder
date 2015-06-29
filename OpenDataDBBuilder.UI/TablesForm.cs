using System;
using System.IO;
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
using OpenDataDBBuilder.Business.File.Util;
using OpenDataDBBuilder.Business.DB;

using System.Globalization;
using System.Threading;
using OpenDataDBBuilder.UI.Localization;



namespace OpenDataDBBuilder.UI
{
    public partial class TablesForm : Form
    {
        String filePath;
        StartScreenForm startForm;
        TableList tablesList;
        String templateFilePath = "";

        String openFileDialogTitle = "openFileDialogTitleMsg";
        String openFileDialogTitleMsg = "";

        public TablesForm(TableList tablesList, StartScreenForm startForm)
        {
            this.startForm = startForm;
            InitializeComponent();
            getLocalizedLabelsMessages();
            this.tablesList = tablesList;
            this.Icon = Properties.Resources.icooddb;
            createTablesTabsView(tablesList.Tables);
            updateSQLCreateTables();
            getDefaultValues();
        }

        private void createTablesTabsView(List<Table> tables)
        {
            this.tablesList.Tables = tables;
            dtcTables.TabPages.Clear();

            if (tablesList != null && tablesList.Tables != null) 
            { 
                foreach (Table table in this.tablesList.Tables)
                {
                    if (table != null)
                    {
                        TabPage tab = new TabPage(table.TableName.ToString());
                        DataGridView dgvTable = new DataGridView();
                        dgvTable.ReadOnly = true;
                        dgvTable.Name = table.TableName;
                        dgvTable.Dock = DockStyle.Fill;
                        tab.Controls.Add(dgvTable);
                        tab.BackColor = System.Drawing.SystemColors.Window;
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
                            int count = 0;
                            foreach (Row r in table.Rows)
                            {
                                if(count < 100)
                                {
                                    DataGridViewRow row = new DataGridViewRow();
                                    DataGridViewCell cell = null;
                                    foreach (KeyValue k in r.Values)
                                    {
                                        for (int columnIndex = 0; columnIndex < dgvTable.Columns.Count; columnIndex++)
                                        {
                                            int columnIndexIndex = TableList.getIndexColumnPerName(dgvTable.Columns[columnIndex].Name, table);
                                            if (columnIndexIndex >-1
                                                &&(k.Key.Equals(table.Columns[columnIndex].OriginalColumnName)
                                                    || k.Key.Equals(table.Columns[columnIndex].ColumnName)))
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
                                else
                                {
                                    break;
                                }
                                count++;
                            }
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
            openFileDialog.Dispose();
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
            this.tsiEdit.Text = loc.getLocalizedResource(language, this.tsiEdit.Name);
            this.tsiEditColumns.Text = loc.getLocalizedResource(language, this.tsiEditColumns.Name);
            this.tsiCreate.Text = loc.getLocalizedResource(language, this.tsiCreate.Name);
            this.tsiTablesEdit.Text = loc.getLocalizedResource(language, this.tsiTablesEdit.Name);
            this.tsiTablesCreate.Text = loc.getLocalizedResource(language, this.tsiTablesCreate.Name);
            this.tsiSaveTemplate.Text = loc.getLocalizedResource(language, this.tsiSaveTemplate.Name);
            this.tsiInsert.Text = loc.getLocalizedResource(language, this.tsiInsert.Name);
            this.tsiConnection.Text = loc.getLocalizedResource(language, this.tsiConnection.Name);
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
            ChangeColumnForm columnForm = new ChangeColumnForm(this.tablesList.Tables, startForm.Template.DBconfig);
            DialogResult result = columnForm.ShowDialog();
            if (!"".Equals(result.ToString()))
            {
                createTablesTabsView(columnForm.TablesList.Tables);
                updateSQLCreateTables();
            }
            columnForm.Dispose();
        }

        private void updateSQLCreateTables()
        {
            List<Table> tables = this.tablesList.Tables;
            SQLGenerator.prepareTablesSQL(ref tables);
            this.tablesList.Tables = tables;
        }

        private void tsiTablesCreate_Click(object sender, EventArgs e)
        {
            ExecuteSQLForm executeSQLForm = new ExecuteSQLForm(tablesList, startForm.Template.DBconfig, false);
            executeSQLForm.ShowDialog();
            executeSQLForm.Dispose();
        }

        private void tsiTablesEdit_Click(object sender, EventArgs e)
        {
            ChangeTablesForm changeTablesForm = new ChangeTablesForm(this.tablesList.Tables, startForm.Template.DBconfig);
            DialogResult result = changeTablesForm.ShowDialog();
            if (!"".Equals(result.ToString()))
            {
                createTablesTabsView(changeTablesForm.Tables);
                updateSQLCreateTables();
            }
            changeTablesForm.Dispose();
        }

        private void tsiSaveTemplate_Click(object sender, EventArgs e)
        {
            if (saveDialogTemplateFile.ShowDialog() == DialogResult.OK)
            {
                TemplateFileUtil templateFileUtil = new TemplateFileUtil();
                startForm.Template.TableList = this.tablesList;
                templateFileUtil.createTemplateFile(startForm.Template, saveDialogTemplateFile.FileName);
            }
            saveDialogTemplateFile.Dispose();
        }

        private void tsiConnection_Click(object sender, EventArgs e)
        {
            EditDBConnectionForm editDBConnectionForm = new EditDBConnectionForm(startForm.Template.DBconfig);
            DialogResult result = editDBConnectionForm.ShowDialog();
            if (DialogResult.OK.Equals(result))
                startForm.Template.DBconfig = editDBConnectionForm.dbconfig;
            editDBConnectionForm.Dispose();
        }

        private void tsiInsert_Click(object sender, EventArgs e)
        {
            ExecuteSQLForm executeSQLForm = new ExecuteSQLForm(tablesList, startForm.Template.DBconfig, true);
            executeSQLForm.ShowDialog();
            executeSQLForm.Dispose();
        }

        private void tsiOpenTemplate_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "(*.oddb)|*.oddb";
            DialogResult result = openFile.ShowDialog();
            try { 
                if ("OK".Equals(result.ToString()))
                {
                    templateFilePath = openFile.FileName.ToString();
                    startForm.Template = new TemplateFileUtil().getTemplateFile(templateFilePath);
                    if (validateTemplateFileTable())
                        readTemplateIntoTableList();
                    else
                        showInfoErrorForm("Erro ao abrir template");
                }
            }
            catch (Exception)
            {
                showInfoErrorForm("Erro ao abrir template");
            }
        }

        private Boolean validateTemplateFileTable()
        {
            if (startForm.Template != null)
            {
                if (startForm.Template.TableList != null && startForm.Template.TableList.Tables != null && startForm.Template.TableList.Tables.Count > 0)
                {
                    if (startForm.Template.TableList.TablesNames.Count != tablesList.TablesNames.Count)
                    {
                        return false;
                    }
                    foreach (Table t in tablesList.Tables)
                    {
                        foreach (Table tl in startForm.Template.TableList.Tables)
                        {
                            if (tl.Columns.Count != t.Columns.Count)
                            {
                                return false;
                            }
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private void readTemplateIntoTableList()
        {
            foreach (Table t in tablesList.Tables)
            {
                foreach (Table tl in startForm.Template.TableList.Tables)
                {
                    if (t.OriginalTableName.Equals(tl.OriginalTableName))
                    {
                        t.TableName = tl.TableName;
                        foreach (Column c in t.Columns)
                        {
                            foreach (Column cl in tl.Columns)
                            {
                                if (c.OriginalColumnName.Equals(cl.OriginalColumnName))
                                {
                                    c.ColumnName = cl.ColumnName;
                                    c.IsPK = cl.IsPK;
                                    c.IsFK = cl.IsFK;
                                    c.Reference = cl.Reference;
                                    c.sqlType = cl.sqlType;
                                }
                            }
                        }
                    }
                }
            }
            createTablesTabsView(tablesList.Tables);
        }

        private void showInfoErrorForm(String msg)
        {
            InfoErrorDialogForm infoErrorDialogForm = new InfoErrorDialogForm(true, msg);
            infoErrorDialogForm.StartPosition = FormStartPosition.CenterScreen;
            infoErrorDialogForm.ShowDialog();
            infoErrorDialogForm.Dispose();
        }
    }
}
