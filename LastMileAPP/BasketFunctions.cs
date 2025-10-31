using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;






namespace LastMileAPP
{
    public static class BasketFunctions
    {
        public static DataTable InitializeBasketTable(DataTable fullDataTable)
        {
            if (fullDataTable == null)
                throw new Exception("fullDataTable is null — load database first.");

            DataTable basketTable = fullDataTable.Clone();

            if (!basketTable.Columns.Contains("quantity"))
                basketTable.Columns.Add("quantity", typeof(int));

            if (!basketTable.Columns.Contains("material_spolu"))
                basketTable.Columns.Add("material_spolu", typeof(double));

            if (!basketTable.Columns.Contains("praca_spolu"))
                basketTable.Columns.Add("praca_spolu", typeof(double));

            if (!basketTable.Columns.Contains("spolu"))
                basketTable.Columns.Add("spolu", typeof(double));

            return basketTable;
        }

        public static void RecalculateRow(DataRow row)
        {
            if (row == null)
                throw new ArgumentNullException(nameof(row));

            double nakup = GetNumericValue(row, "nakup_materialu");
            double kMat = GetNumericValue(row, "koeficient_material");
            double cenaPrace = GetNumericValue(row, "cena_prace");
            double kPrace = GetNumericValue(row, "koeficient_prace");
            int qty = (int)Math.Round(GetNumericValue(row, "quantity"));

            double materialSpolu = nakup * kMat * qty;
            double pracaSpolu = cenaPrace * kPrace * qty;
            double spolu = materialSpolu + pracaSpolu;

            row["material_spolu"] = materialSpolu;
            row["praca_spolu"] = pracaSpolu;
            row["spolu"] = spolu;
        }
        private static double GetNumericValue(DataRow row, string columnName)
        {
            if (!row.Table.Columns.Contains(columnName))
                throw new ArgumentException($"Column '{columnName}' was not found in the provided row.", nameof(columnName));

            object value = row[columnName];

            if (value == null || value == DBNull.Value)
                return 0d;

            try
            {
                return Convert.ToDouble(value);
            }
            catch (FormatException ex)
            {
                throw new FormatException($"Unable to convert value '{value}' in column '{columnName}' to a number.", ex);
            }
            catch (InvalidCastException ex)
            {
                throw new InvalidCastException($"Value in column '{columnName}' cannot be cast to a numeric type.", ex);
            }
        }

        public static void HideColumns(DataGridView dataGridBasket)
        {

            if (dataGridBasket.Columns.Contains("id"))
                dataGridBasket.Columns["id"].Visible = false;

            if (dataGridBasket.Columns.Contains("product_type_id"))
                dataGridBasket.Columns["product_type_id"].Visible = false;

            // ---- add these ----
            if (dataGridBasket.Columns.Contains("hlavna_kategoria"))
                dataGridBasket.Columns["hlavna_kategoria"].Visible = false;

            if (dataGridBasket.Columns.Contains("spolu"))
                dataGridBasket.Columns["spolu"].Visible = false;
        }
    }

    
}

