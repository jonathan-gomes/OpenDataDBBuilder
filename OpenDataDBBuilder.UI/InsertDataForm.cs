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
    public partial class InsertDataForm : Form
    {
        String rbtnSkipLineText = "";
        String rbtnDefaultValueText = "";

        String lblOnErrorActionText = "";
        String lblCollumnNameText = "";

        DatabaseHelper dbHelper;
        StartScreenForm startForm;
        public TableList TablesList { get; set; }

        public InsertDataForm(StartScreenForm startForm, TableList tablesList)
        {
            this.startForm = startForm;
            InitializeComponent();
            this.dbHelper = new DatabaseHelper(startForm.Template.DBconfig);
            this.TablesList = tablesList;
            getLocalizedLabelsMessages();
            getDefaultValues();
            createTablesView();
        }

        private void getLocalizedLabelsMessages()
        {
            CultureInfo language = Thread.CurrentThread.CurrentUICulture;
            Localization.Localization loc = new Localization.Localization();
            this.Text = loc.getLocalizedResource(language, this.Name);
            this.btnSetDbConnection.Text = loc.getLocalizedResource(language, this.btnSetDbConnection.Name);
            this.btnPreviewInsertValues.Text = loc.getLocalizedResource(language, this.btnPreviewInsertValues.Name);
            this.lblCollumnNameText = loc.getLocalizedResource(language, "lblCollumnName");
            this.lblOnErrorActionText = loc.getLocalizedResource(language, "lblOnErrorAction");
            this.rbtnSkipLineText = loc.getLocalizedResource(language, "rbtnSkipLineText");
            this.rbtnDefaultValueText = loc.getLocalizedResource(language, "rbtnDefaultValueText");
        }

        private void getDefaultValues()
        {
            this.Icon = Properties.Resources.icooddb;
        }

        private void createTablesView()
        {
            int gpbxX = 6;
            int gpbxY = 1;

            dtcTables.TabPages.Clear();

            foreach (Table table in this.TablesList.Tables)
            {
                if (table != null)
                {
                    TabPage tab = new TabPage(table.TableName.ToString());
                    tab.Name = "TAB" + table.TableName;

                    TableLayoutPanel pnlHeaderColumnName = new TableLayoutPanel();
                    pnlHeaderColumnName.BorderStyle = BorderStyle.FixedSingle;
                    pnlHeaderColumnName.Size = new System.Drawing.Size(150, 35);
                    Label lblCollumnName = new Label();
                    lblCollumnName.Text = lblCollumnNameText;
                    lblCollumnName.Font = new Font(lblCollumnName.Font, FontStyle.Bold);
                    pnlHeaderColumnName.Controls.Add(lblCollumnName);
                    lblCollumnName.Anchor = AnchorStyles.None;
                    lblCollumnName.TextAlign = ContentAlignment.MiddleCenter;

                    TableLayoutPanel pnlOnErrorAction = new TableLayoutPanel();
                    pnlOnErrorAction.BorderStyle = BorderStyle.FixedSingle;
                    pnlOnErrorAction.Size = new System.Drawing.Size(450, 35);
                    Label lblOnErrorAction = new Label();
                    lblOnErrorAction.Text = lblOnErrorActionText;
                    lblOnErrorAction.Font = new Font(lblOnErrorAction.Font, FontStyle.Bold);
                    pnlOnErrorAction.Controls.Add(lblOnErrorAction);
                    lblOnErrorAction.Anchor = AnchorStyles.None;
                    lblOnErrorAction.TextAlign = ContentAlignment.MiddleCenter;

                    pnlHeaderColumnName.Location = new Point(gpbxX, gpbxY);
                    pnlOnErrorAction.Location = new Point(gpbxX + 150, gpbxY);
                    tab.Controls.Add(pnlHeaderColumnName);
                    tab.Controls.Add(pnlOnErrorAction);


                    gpbxY += 37;

                    if (table.Columns != null)
                    {
                        foreach (Column c in table.Columns)
                        {
                            GroupBox gpbx = new GroupBox();
                            gpbx.Name = "gpbx";
                            gpbx.Size = new System.Drawing.Size(600, 56);

                            TextBox texb = new TextBox();
                            texb.Name = c.OriginalColumnName;
                            texb.DataBindings.Add("Text", c, "ColumnName");
                            texb.Location = new Point(16, 19);
                            texb.ReadOnly = true;
                            gpbx.Controls.Add(texb);

                            Panel pnlErrorAction = new Panel();
                            pnlErrorAction.Location = new Point(132, 8);
                            pnlErrorAction.Size = new System.Drawing.Size(400, 45);
                            pnlErrorAction.BorderStyle = System.Windows.Forms.BorderStyle.None;

                            RadioButton rbtnSkipLine = new RadioButton();
                            rbtnSkipLine.Checked = true;
                            rbtnSkipLine.Name = "rbtnSkipLine" + c.OriginalColumnName;
                            rbtnSkipLine.Text = rbtnSkipLineText;
                            
                            RadioButton rbtnDefaultValue = new RadioButton();
                            rbtnDefaultValue.Checked = false;
                            rbtnDefaultValue.Name = "rbtnDefaultValue" + c.OriginalColumnName;
                            rbtnDefaultValue.CheckedChanged += rbtnDefaultValue_CheckedChanged;
                            rbtnDefaultValue.Text = rbtnDefaultValueText;

                            pnlErrorAction.Controls.Add(rbtnSkipLine);
                            pnlErrorAction.Controls.Add(rbtnDefaultValue);

                            rbtnSkipLine.Location = new Point(19, 15);
                            rbtnDefaultValue.Location = new Point(125, 15);
                            rbtnDefaultValue.Size = new System.Drawing.Size(120, 17);

                            gpbx.Controls.Add(pnlErrorAction);

                            //TextBox texbDV = new TextBox();
                           // texbDV.Name = c.OriginalColumnName;
                          //  texbDV.DataBindings.Add("Text", c, "defaulValue");
                           // texbDV.Location = new Point(132, 19);
                           // gpbx.Controls.Add(texbDV);

                            gpbx.Location = new Point(gpbxX, gpbxY);
                            tab.Controls.Add(gpbx);
                            gpbxY += 55;
                        }
                    }
                    tab.AutoScroll = true;
                    dtcTables.TabPages.Add(tab);
                }
            }
        }

        void rbtnDefaultValue_CheckedChanged(object sender, EventArgs e)
        {
            String originalTableName = ((Control)sender).Parent.Parent.Parent.Name.Replace("TAB","");
            String originalColumnName = ((Control)sender).Name.Replace("rbtnDefaultValue", "");

            foreach (Table t in TablesList.Tables)
            {
                if(t.OriginalTableName.Equals(originalTableName))
                {
                    foreach (Column c in t.Columns)
                    {
                        if (c.OriginalColumnName.Equals(originalColumnName))
                        {
                            if (((RadioButton)sender).Name.Contains("rbtnDefaultValue"))
                            {
                                if (((RadioButton)sender).Checked)
                                {
                                    TextBox txbDefaultValue = new TextBox();
                                    txbDefaultValue.Name = "txbDefaultValue" + ((RadioButton)sender).Name.Replace("rbtnDefaultValue", "");
                                    txbDefaultValue.DataBindings.Add("Text", c, "defaulValueOnError");
                                    ((RadioButton)sender).Parent.Controls.Add(txbDefaultValue);
                                    txbDefaultValue.Location = new Point(255, 15);
                                }
                                else
                                {
                                    foreach (Control ctrl in ((RadioButton)sender).Parent.Controls)
                                    {
                                        c.defaulValueOnError = null;
                                        if (ctrl.Name.Contains("txbDefaultValue"))
                                            ((RadioButton)sender).Parent.Controls.Remove(ctrl);
                                    }
                                }
                            }
                            break;
                        }
                    }
                    break;
                }
            }
        }

        private void btnSetDbConnection_Click(object sender, EventArgs e)
        {
            EditDBConnectionForm editDBConnectionForm  = new EditDBConnectionForm(startForm.Template.DBconfig);
            DialogResult result = editDBConnectionForm.ShowDialog();
            if (DialogResult.OK.Equals(result))
                startForm.Template.DBconfig = editDBConnectionForm.dbconfig;
            editDBConnectionForm.Dispose();
        }

        private void btnPreviewInsertValues_Click(object sender, EventArgs e)
        {
            ExecuteSQLForm executeSQLForm = new ExecuteSQLForm(TablesList,startForm.Template.DBconfig, true);
            executeSQLForm.ShowDialog();
            executeSQLForm.Dispose();
        }


    }
}
