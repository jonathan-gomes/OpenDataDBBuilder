using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenDataDBBuilder.Business.File.Util;
using OpenDataDBBuilder.Business.File.XML.Util;
using OpenDataDBBuilder.Business.DB.VO;

namespace OpenDataDBBuilder.UI
{
    public partial class MainForm : Form
    {
        private int pageSize = 70;
        private int numberOfPages;
        private int lines;
        private int currentPage;

        private String filePath = "";

        public MainForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.icooddb;
            tooglePageControls(false);
            tsiTables.Enabled = false;
        }


        private void updatePage(String page, int pageNumber)
        {
            currentPage = pageNumber;
            rtbFileReader.Text = page;
            txtPage.Text = currentPage.ToString();
        }

        private void tooglePageControls(Boolean enable)
        {
            txtPage.Enabled = enable;
            btnNextPage.Enabled = enable;
            btnPreviousPage.Enabled = enable;
        }
        private void updatePageControls()
        {
            btnNextPage.Enabled = true;
            btnPreviousPage.Enabled = true;

            if(currentPage >= numberOfPages)
                btnNextPage.Enabled = false;
            else if (currentPage == 1)
                btnPreviousPage.Enabled = false;
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            Boolean isNext = true;
            browseFile(isNext);
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            Boolean isNext = false;
            browseFile(isNext);
        }

        private void browseFile(Boolean isNext)
        {
            int nextPage;
            if(isNext)
                nextPage = currentPage + 1;
            else
                nextPage = currentPage - 1;
            goToPage(nextPage);
        }

        private void goToPage(int pageNumber)
        {
            if (pageNumber <= numberOfPages)
            {
                String page = FileUtil.readLines(filePath, pageNumber, pageSize);
                if (page != null && !"".Equals(page))
                {
                    updatePage(page, pageNumber);
                    txtPage.Enabled = true;
                    updatePageControls();
                }
            }
            else
            {
                showErrorInfoWindow("Error");
            }
        }


        private void tsiOpenMenu_Click(object sender, EventArgs e)
        {
            String validationMsg = "";
            openFileDialog.Filter = "XML Files|*.xml";
            openFileDialog.Title = "Select a XML File";
            DialogResult result = openFileDialog.ShowDialog();
            if ("OK".Equals(result.ToString()))
            {
                filePath = openFileDialog.FileName.ToString();
                if (XMLFileUtil.IsValidXML(filePath, out validationMsg)) 
                { 
                    lblFilePath.Text = filePath;
                    lines = FileUtil.countLines(filePath);
                    numberOfPages = FileUtil.countPages(lines, pageSize);
                    lblNumberOfPages.Text = numberOfPages.ToString() + " Pages";
                    int pageNumber = 1;
                    String page = FileUtil.readLines(filePath, pageNumber, pageSize);
                    if (page != null && !"".Equals(page))
                    {
                        updatePage(page, pageNumber);
                        if (numberOfPages > currentPage)
                        {
                            txtPage.Enabled = true;
                            updatePageControls();
                        }
                    }
                    tsiTables.Enabled = true;
                }
                else
                {
                    showErrorInfoWindow("Invalid XML file. " + validationMsg);
                }
            }
           
            openFileDialog.Dispose();
        }

        private void tsiOptions_Click(object sender, EventArgs e)
        {
            OptionsDialogForm options = new OptionsDialogForm(pageSize);
            DialogResult dr = options.ShowDialog();
            if (!"Cancel".Equals(dr.ToString()))
            {
                pageSize = options.getLinesPerPage();
                numberOfPages = FileUtil.countPages(lines, pageSize);
                lblNumberOfPages.Text = numberOfPages.ToString() + " Pages";
                goToPage(1);
            }
        }

        private void showErrorInfoWindow(String msg)
        {
            InfoErrorDialogForm error = new InfoErrorDialogForm(true, msg);
            error.ShowDialog();
            error.Dispose();
        }

        private void tsiTables_Click(object sender, EventArgs e)
        {
            //TablesForm tablesForm = new TablesForm(XMLFileUtil.getTablesFromXMLFile(filePath).ElementAt(0));
           // tablesForm.ShowDialog();
           // tablesForm.Dispose();
        }
    }
}
