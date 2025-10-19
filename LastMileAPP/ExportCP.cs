using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace LastMileAPP
{
    public static class ExportCP
    {
        private const int START_ROW = 15;

        private static readonly string ImgBase =
            @"C:\Users\slaso\source\repos\LastMileAPP\LastMileAPP\Resources\Images\";

        public static void ExportBasketToExcel(DataTable basketTable)
        {
            if (basketTable == null || basketTable.Rows.Count == 0)
            {
                MessageBox.Show("Basket is empty.");
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Title = "Exportovať do Excelu",
                Filter = "Excel (*.xlsx)|*.xlsx",
                FileName = $"Export_{DateTime.Now:yyyyMMdd_HHmm}.xlsx"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;

            string template = @"C:\Users\slaso\source\repos\LastMileAPP\LastMileAPP\CPINT.xlsx";
            if (!File.Exists(template))
            {
                MessageBox.Show("Template not found:\n" + template);
                return;
            }

            using var wb = new XLWorkbook(template);
            var ws = wb.Worksheet(1);

            // Insert rows before start
            int count = basketTable.Rows.Count;
            ws.Row(START_ROW).InsertRowsAbove(count);

            // Copy style of template row
            var tempRow = ws.Row(START_ROW + count);
            double h = tempRow.Height;

            for (int i = 0; i < count; i++)
            {
                var r = ws.Row(START_ROW + i);
                r.Style = tempRow.Style;
                if (h > 0) r.Height = h;
                r.Style.Alignment.WrapText = false;
            }

            // Fill data
            int row = START_ROW;
            int counter = 1;
            

            foreach (DataRow dr in basketTable.Rows)
            {
                ws.Cell(row, 2).Value = counter++;
                ws.Cell(row, 3).Value = dr["produkt"]?.ToString();

                int c = 4;
                foreach (DataColumn dc in basketTable.Columns)
                {
                    if (dc.ColumnName is "produkt" or "id" or "product_type_id")
                        continue;

                    ws.Cell(row, c++).Value = dr[dc.ColumnName]?.ToString();
                }
                row++;
            }

            // ─────────────────────────────
            // INSERT IMAGES
            // ─────────────────────────────

            string file1 = Path.Combine(ImgBase, "LastMileLogo.png");
            string file2 = Path.Combine(ImgBase, "ChangeTheQuo.png");
            string file3 = Path.Combine(ImgBase, "GeneralInfo.png");

            if (File.Exists(file1))
                ws.AddPicture(file1)
                  .MoveTo(ws.Cell("B2"), 25, 8)
                  .Scale(0.64);

            if (File.Exists(file2))
                ws.AddPicture(file2)
                  .MoveTo(ws.Cell("G2"), -45, 35)
                  .Scale(0.64);

            int footerRow = 30;
            if (File.Exists(file3))
                ws.AddPicture(file3)
                  .MoveTo(ws.Cell($"B{footerRow}"))
                  .Scale(0.64);

            wb.SaveAs(sfd.FileName);
            MessageBox.Show("Export done:\n" + sfd.FileName);
        }
    }
}
