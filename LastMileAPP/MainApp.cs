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
        public MainApp()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

        }



        private void MainApp_Load(object sender, EventArgs e)
        {
            LoadDatabase();
            basketTable = BasketFunctions.InitializeBasketTable(fullDataTable);
            dataGridBasket.DataSource = basketTable;
            dataGridBasket.RowHeadersVisible = false;
            if (dataGridBasket.Columns.Contains("id"))
                dataGridBasket.Columns["id"].Visible = false;
            if (dataGridBasket.Columns.Contains("product_type_id"))
                dataGridBasket.Columns["product_type_id"].Visible = false;
            foreach (DataGridViewColumn col in dataGridBasket.Columns)
                col.ReadOnly = true;

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
        private void LoadDatabase()
        {
            try
            {
                fullDataTable = DatabaseCon.RunQuery("SELECT * FROM produkty");
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
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string templatePath = @"C:\Users\slaso\source\repos\LastMileAPP\LastMileAPP\CPINT.xlsx";
            string savePath = Path.Combine(desktopPath, "Export_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx");

            using (var wb = new XLWorkbook(templatePath))
            {
                var ws = wb.Worksheet(1); // Sheet1
                int startRow = 15;
                int counter = 1;

                foreach (DataRow row in basketTable.Rows)
                {
                    int excelRow = startRow++;

                    // B & C
                    ws.Cell(excelRow, 2).Value = counter++;           // counter
                    WriteCell(ws.Cell(excelRow, 3), row["produkt"]);  // product name

                    // Remaining columns from D onward
                    int col = 4;
                    foreach (DataColumn c in basketTable.Columns)
                    {
                        if (c.ColumnName == "produkt" || c.ColumnName == "id" || c.ColumnName == "product_type_id")
                            continue;

                        WriteCell(ws.Cell(excelRow, col++), row[c.ColumnName]);
                    }
                }

                wb.SaveAs(savePath);
            }

            MessageBox.Show("Export done:\n" + savePath);
        }

        /// <summary>
        /// Safely writes a DataRow value into a ClosedXML cell with the correct type.
        /// Avoids CS0266 (object -> XLCellValue).
        /// </summary>
        private static void WriteCell(IXLCell cell, object value)
        {
            if (value == null || value == DBNull.Value)
            {
                cell.Value = string.Empty;
                return;
            }

            switch (value)
            {
                case int i: cell.Value = i; break;
                case long l: cell.Value = l; break;
                case short s: cell.Value = s; break;
                case byte b8: cell.Value = b8; break;
                case decimal m: cell.Value = m; break;
                case double d: cell.Value = d; break;
                case float f: cell.Value = (double)f; break; // XL uses double for floats
                case bool b: cell.Value = b; break;
                case DateTime dt: cell.Value = dt; break;
                case TimeSpan ts: cell.Value = ts; break;
                case string str: cell.Value = str; break;
                default: cell.Value = value.ToString(); break;
            }
        }



    }
}
