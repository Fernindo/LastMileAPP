using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LastMileAPP
{
    public partial class Settings : Form
    {
        private readonly MainApp _main;
        public Settings(MainApp _main)
        {
            InitializeComponent();
            this._main = _main;
        }

        private void Settings_Load(object sender, EventArgs e)
        {
           
            
        }
    }
}
