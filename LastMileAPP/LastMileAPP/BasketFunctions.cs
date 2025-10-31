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

            basketTable.Columns.Add("quantity", typeof(int));
            basketTable.Columns.Add("material_spolu", typeof(double));
            basketTable.Columns.Add("praca_spolu", typeof(double));
            basketTable.Columns.Add("spolu", typeof(double));

            return basketTable;
        }

        public static void RecalculateRow(DataRow row)
        {
            double nakup = Convert.ToDouble(row["nakup_materialu"]);
            double kMat = Convert.ToDouble(row["koeficient_material"]);
            double cenaPrace = Convert.ToDouble(row["cena_prace"]);
            double kPrace = Convert.ToDouble(row["koeficient_prace"]);
            int qty = Convert.ToInt32(row["quantity"]);

            double materialSpolu = nakup * kMat * qty;
            double pracaSpolu = cenaPrace * kPrace * qty;
            double spolu = materialSpolu + pracaSpolu;

            row["material_spolu"] = materialSpolu;
            row["praca_spolu"] = pracaSpolu;
            row["spolu"] = spolu;
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

