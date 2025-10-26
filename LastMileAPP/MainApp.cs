using ClosedXML.Excel;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using LastMileAPP;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LastMileAPP
{
    public partial class MainApp : Form
    {

        private DataTable fullDataTable;
        private DataTable basketTable;

        private FiltersController filtersController;

        bool isCollapsed = true;
        int slideWidth;


        public MainApp()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

        }
        private void LoadDatabase()
        {
            try
            {
                string sql = @"
            SELECT p.*, c.hlavna_kategoria, c.nazov_tabulky
            FROM produkty p
            LEFT JOIN produkt_class pc ON p.id = pc.produkt_id
            LEFT JOIN class c ON pc.class_id = c.id;
        ";

                fullDataTable = DatabaseCon.RunQuery(sql);
                dataGridDatabase.DataSource = fullDataTable;
                dataGridDatabase.RowHeadersVisible = false;

                dataGridDatabase.ReadOnly = true;
                dataGridDatabase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridDatabase.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                dataGridDatabase.Columns["id"].Visible = false;
                dataGridDatabase.Columns["product_type_id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error:\n" + ex.Message);
            }
        }



        private void MainApp_Load(object sender, EventArgs e)
        {
            LoadDatabase();
            treeViewCategories.ShowPlusMinus = false;

            var categoriesTable = DatabaseCon.GetCategories();
            FiltersTree.Build(treeViewCategories, categoriesTable);

            
            filtersController = new FiltersController(treeViewCategories, dataGridDatabase, fullDataTable);





            basketTable = BasketFunctions.InitializeBasketTable(fullDataTable);
            dataGridBasket.DataSource = basketTable;
            dataGridBasket.RowHeadersVisible = false;

            if (dataGridBasket.Columns.Contains("id"))
                dataGridBasket.Columns["id"].Visible = false;
            if (dataGridBasket.Columns.Contains("product_type_id"))
                dataGridBasket.Columns["product_type_id"].Visible = false;
            foreach (DataGridViewColumn col in dataGridBasket.Columns)
                col.ReadOnly = true;


            slideWidth = panel3.Width;
            panel3.Width = 0;

            // Enable editing only for specific columns
            string[] editableCols = { "quantity", "koeficient_prace", "cena_prace", "koeficient_material", "nakup_materialu" };

            foreach (string name in editableCols)
            {
                if (dataGridBasket.Columns.Contains(name))
                    dataGridBasket.Columns[name].ReadOnly = false;
            }
            string[] computedCols = { "material_spolu", "praca_spolu", "spolu" };
            foreach (string name in computedCols)
            {
                if (dataGridBasket.Columns.Contains(name))
                    dataGridBasket.Columns[name].ReadOnly = true;
            }
            dataGridBasket.CellValueChanged += dataGridBasket_CellValueChanged;
            dataGridBasket.CurrentCellDirtyStateChanged += (s, eArgs) =>
            {
                if (dataGridBasket.IsCurrentCellDirty)
                    dataGridBasket.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
            dataGridBasket.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        private void dataGridBasket_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = ((DataRowView)dataGridBasket.Rows[e.RowIndex].DataBoundItem).Row;
            BasketFunctions.RecalculateRow(row);
        }



        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }



        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (fullDataTable == null) return;

            string filterText = txtSearch.Text.Trim().Replace("'", "''");

            if (string.IsNullOrEmpty(filterText))
            {
                dataGridDatabase.DataSource = fullDataTable;
            }
            else
            {
                DataView dv = new DataView(fullDataTable);
                dv.RowFilter = $"produkt LIKE '%{filterText}%'";
                dataGridDatabase.DataSource = dv;
            }
        }

        private void dataGridDatabase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // header clicked

            // Get ID of selected product
            int id = Convert.ToInt32(dataGridDatabase.Rows[e.RowIndex].Cells["id"].Value);

            // Check if already in basket
            DataRow existing = basketTable.Rows.Cast<DataRow>().FirstOrDefault(r => Convert.ToInt32(r["id"]) == id);

            if (existing != null)
            {
                existing["quantity"] = Convert.ToInt32(existing["quantity"]) + 1;
                BasketFunctions.RecalculateRow(existing);

            }
            else
            {
                // Add new row
                DataRow newRow = basketTable.NewRow();
                foreach (DataColumn col in fullDataTable.Columns)
                    newRow[col.ColumnName] = dataGridDatabase.Rows[e.RowIndex].Cells[col.ColumnName].Value;
                newRow["quantity"] = 1;
                basketTable.Rows.Add(newRow);
                BasketFunctions.RecalculateRow(newRow);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportCP.ExportBasketToExcel(basketTable);

        }

        private void sliderTimer_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panel3.Width += 25; // slide open
                if (panel3.Width >= slideWidth)
                {
                    sliderTimer.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                panel3.Width -= 25; // slide closed
                if (panel3.Width <= 0)
                {
                    sliderTimer.Stop();
                    isCollapsed = true;
                }
            }
        }

        private void btnToggleSlide_Click(object sender, EventArgs e)
        {
            sliderTimer.Start();
        }

        private void treeViewCategories_AfterCheck(object sender, TreeViewEventArgs e)
        {
            
            // prevent infinite loop when checking children programmatically
            treeViewCategories.AfterCheck -= treeViewCategories_AfterCheck;

            if (e.Node.Nodes.Count > 0) // it's a parent
            {
                if (e.Node.Checked)
                    e.Node.Expand();
                else
                    e.Node.Collapse();
            }

            // also check/uncheck all children automatically if you want
            foreach (TreeNode child in e.Node.Nodes)
            {
                child.Checked = e.Node.Checked;
            }

            // reattach event
            treeViewCategories.AfterCheck += treeViewCategories_AfterCheck;
        }
    }
}
