using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastMileAPP
{
    public static class ExportCP
    {
        public static void Export(DataTable basketTable)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string templatePath = @"C:\Users\slaso\source\repos\LastMileAPP\LastMileAPP\CPINT.xlsx"; // or dynamic
            string savePath = Path.Combine(desktopPath, "Export_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx");

            using (var wb = new XLWorkbook(templatePath))
            {
                var ws = wb.Worksheet(1);

                int insertRow = 15;
                int counter = 1;

                foreach (DataRow row in basketTable.Rows)
                {
                    ws.Row(insertRow).InsertRowsAbove(1);

                    int excelRow = insertRow;

                    ws.Cell(excelRow, 2).Value = counter++;
                    ws.Cell(excelRow, 3).Value = row["produkt"];

                    int col = 4;
                    foreach (DataColumn c in basketTable.Columns)
                    {
                        if (c.ColumnName == "produkt" || c.ColumnName == "id" || c.ColumnName == "product_type_id")
                            continue;

                        object val = row[c.ColumnName] == DBNull.Value ? "" : row[c.ColumnName];
                        ws.Cell(excelRow, col++).Value = val;
                    }
                }

                wb.SaveAs(savePath);
            }

            System.Windows.Forms.MessageBox.Show("Export done:\n" + savePath);
        }
    }
}
