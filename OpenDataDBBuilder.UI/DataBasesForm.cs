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
using OpenDataDBBuilder.Business.DB;

namespace OpenDataDBBuilder.UI
{
    public partial class DataBasesForm : Form
    {
        String db = "";
        List<String> dataBases = new List<String>();

        public DataBasesForm(String db)
        {
            this.db = db;            
            InitializeComponent();
            dataBases = listDataBases();
            foreach(String s in dataBases)
            {
                this.lbxDatabases.Items.Add(s);
            }
        }

        private void btnAddDataBase_Click(object sender, EventArgs e)
        {
            if (!lbxDatabases.Items.Contains(txbDataBase.Text))
            {
                addDatabase(txbDataBase.Text);
            }
            else
            {
                showErrorInfoWindow("Database já existe");
            }
        }

        private void addDatabase(String database)
        {
            DatabaseChooser dbChooser = new DatabaseChooser();            
            dbChooser.getDataBaseDAO(db).addDatabase(database);
            updateListBoxDatabases();
        }

         private void updateListBoxDatabases()
        {
            dataBases = listDataBases();
            this.lbxDatabases.Items.Clear();
            foreach (String s in dataBases)
            {
                this.lbxDatabases.Items.Add(s);
            }
        }

        private List<String> listDataBases()
        {
            DatabaseChooser dbChooser = new DatabaseChooser();
            return dbChooser.getDataBaseDAO(db).selectDataBases();
        }

        private String readDBConfigFile()
        {
            String appPath = Application.StartupPath;
            String dbConfigPath = appPath + "/DBConfig" + db + ".config";
            List<String> file = FileUtil.openFile(dbConfigPath);
            String config = "";

            foreach (String s in file)
            {
                config += s+";";
            }
            return config;
        }

        private void showErrorInfoWindow(String msg)
        {
            InfoErrorDialogForm error = new InfoErrorDialogForm(true, msg);
            error.ShowDialog();
            error.Dispose();
        }
    }
}
