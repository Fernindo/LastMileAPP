using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data;
using LastMileAPP;

namespace LastMileAPP
{
    public partial class MainApp : Form
    {
        public MainApp()
        {
            InitializeComponent();
        }
        

        private void MainApp_Load(object sender, EventArgs e)
        {
            LoadDatabase();
        }
        private void LoadDatabase()
        {
            try
            {
                dataGridDatabase.DataSource = DatabaseCon.RunQuery("SELECT * FROM produkty");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error:\n" + ex.Message);
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
