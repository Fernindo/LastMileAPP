using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LastMileAPP
{
    internal static class SectionDividerHelper
    {
        public const int DividerId = -1;
        private static readonly Color DividerColor = Color.FromArgb(216, 245, 255);
        private const string DividerPrefix = "-- ";
        private const string DividerSuffix = " --";

        public static string ResolveCategoryColumn(DataTable table)
        {
            string[] preferred = { "Produkt", "produkt", "nazov_tabulky", "hlavna_kategoria" };
            return preferred.FirstOrDefault(table.Columns.Contains);
        }

        public static DataTable BuildWithDividers(DataTable source, string categoryColumn)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (string.IsNullOrWhiteSpace(categoryColumn) || !source.Columns.Contains(categoryColumn))
                return source.Copy();

            var result = source.Clone();
            string lastCategory = null;

            foreach (DataRow row in source.Rows)
            {
                string category = row[categoryColumn]?.ToString() ?? string.Empty;
                if (!string.Equals(category, lastCategory, StringComparison.OrdinalIgnoreCase))
                {
                    AddDividerRow(result, categoryColumn, category);
                    lastCategory = category;
                }

                var newRow = result.NewRow();
                newRow.ItemArray = row.ItemArray.Clone() as object[] ?? Array.Empty<object>();
                result.Rows.Add(newRow);
            }

            return result;
        }

        public static void AddDividerRow(DataTable table, string categoryColumn, string categoryTitle)
        {
            var divider = table.NewRow();
            if (table.Columns.Contains("id")) divider["id"] = DividerId;
            if (table.Columns.Contains("product_type_id")) divider["product_type_id"] = DividerId;

            string title = string.IsNullOrWhiteSpace(categoryTitle)
                ? string.Empty
                : $"{DividerPrefix}{categoryTitle}{DividerSuffix}";

            divider[categoryColumn] = title;
            table.Rows.Add(divider);
        }

        public static bool IsDividerRow(DataRow row)
        {
            return row.Table.Columns.Contains("id")
                && int.TryParse(row["id"].ToString(), out int id)
                && id == DividerId;
        }

        public static bool IsDividerRow(DataGridViewRow row)
        {
            var cell = row.Cells.Cast<DataGridViewCell>().FirstOrDefault(c => string.Equals(c.OwningColumn.Name, "id", StringComparison.OrdinalIgnoreCase));
            return cell != null && int.TryParse(cell.Value?.ToString(), out int id) && id == DividerId;
        }

        public static void ApplyDividerStyles(DataGridView grid, string categoryColumn)
        {
            if (grid == null || grid.Columns.Count == 0 || string.IsNullOrWhiteSpace(categoryColumn) || !grid.Columns.Contains(categoryColumn)) return;
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (!IsDividerRow(row)) continue;

                row.DefaultCellStyle.BackColor = DividerColor;
                row.DefaultCellStyle.SelectionBackColor = DividerColor;
                row.DefaultCellStyle.Font = new Font(grid.Font, FontStyle.Bold);
                row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                row.ReadOnly = true;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Value = row.Cells[categoryColumn]?.Value;
                }
            }
        }
    }
}
