using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrightIdeasSoftware;


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



        // ============================================
        // === OBJECTLISTVIEW (GROUPED BASKET VIEW) ===
        // ============================================

        private static ObjectListView _basketView;

        /// <summary>
        /// Initializes a grouped ObjectListView inside a given container (e.g. a Panel).
        /// </summary>
        public static ObjectListView InitializeGroupedView(Control parent)
        {
            _basketView = new ObjectListView
            {
                Dock = DockStyle.Fill,
                FullRowSelect = true,
                UseAlternatingBackColors = true,
                GridLines = true,
                ShowGroups = true,
                HideSelection = false,
                HeaderStyle = ColumnHeaderStyle.Nonclickable
            };

            // Define columns
            _basketView.Columns.Add(new OLVColumn("Produkt", "produkt") { Width = 250 });
            _basketView.Columns.Add(new OLVColumn("Jednotky", "jednotky") { Width = 70 });
            _basketView.Columns.Add(new OLVColumn("Dodávateľ", "dodavatel") { Width = 120 });
            _basketView.Columns.Add(new OLVColumn("Počet", "quantity") { Width = 60 });
            _basketView.Columns.Add(new OLVColumn("Koef. mat", "koeficient_material") { Width = 80 });
            _basketView.Columns.Add(new OLVColumn("Nákup", "nakup_materialu") { Width = 80 });
            _basketView.Columns.Add(new OLVColumn("Predaj", "predaj_materialu") { Width = 80 });
            _basketView.Columns.Add(new OLVColumn("Zisk", "zisk_material") { Width = 80 });
            _basketView.Columns.Add(new OLVColumn("Marža %", "marza_material") { Width = 80 });

            // Grouping by main category (hlavna_kategoria)
            _basketView.GroupKeyGetter = obj => ((DataRowView)obj)["hlavna_kategoria"];
            _basketView.GroupFormatter = (group, args) =>
            {
                group.Subtitle = $"Položky: {args.Group.Count:N0}";
                group.Collapsible = true; // enable collapse/expand
            };

            parent.Controls.Clear();
            parent.Controls.Add(_basketView);

            return _basketView;
        }

        /// <summary>
        /// Populates or refreshes the grouped ObjectListView from the current basket table.
        /// </summary>
        public static void PopulateGroupedView(DataTable basketTable)
        {
            if (_basketView == null || basketTable == null) return;

            // Convert DataTable to a list of DataRowViews (ObjectListView understands these)
            var dataObjects = basketTable.AsEnumerable()
                .Select(r => basketTable.DefaultView[basketTable.Rows.IndexOf(r)])
                .ToList();

            _basketView.SetObjects(dataObjects);
        }

        /// <summary>
        /// Enables automatic subtotals under each group.
        /// </summary>
        public static void EnableGroupSubtotals(string columnName = "predaj_materialu")
        {
            if (_basketView == null) return;

            _basketView.UseGroupFormatters = true;
            _basketView.GroupFormatter = (group, args) =>
            {
                decimal sum = 0;
                try
                {
                    sum = group.Items.Cast<OLVListItem>()
                        .Select(i => Convert.ToDecimal(((DataRowView)i.RowObject)[columnName]))
                        .Sum();
                }
                catch { }

                group.Subtitle = $"Súčet: {sum:F2} €";
                group.Collapsible = true;
            };
        }

        /// <summary>
        /// Refreshes the grouped ObjectListView (use after editing values).
        /// </summary>
        public static void RefreshGroupedView()
        {
            _basketView?.BuildList(true);
        }
    }

    
}

