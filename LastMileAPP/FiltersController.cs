using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LastMileAPP
{
    internal class FiltersController
    {
        private readonly TreeView tree;
        private readonly DataGridView grid;
        private readonly DataTable sourceTable;

        public FiltersController(TreeView treeView, DataGridView gridView, DataTable data)
        {
            tree = treeView;
            grid = gridView;
            sourceTable = data;

            tree.AfterCheck += Tree_AfterCheck;
        }

        private void Tree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            tree.AfterCheck -= Tree_AfterCheck;

            // expand/collapse
            if (e.Node.Nodes.Count > 0)
            {
                foreach (TreeNode child in e.Node.Nodes)
                    child.Checked = e.Node.Checked;

                if (e.Node.Checked) e.Node.Expand();
                else e.Node.Collapse();
            }

            tree.AfterCheck += Tree_AfterCheck;
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            var selected = GetCheckedCategories();

            if (!selected.Any())
            {
                grid.DataSource = SectionDividerHelper.BuildWithDividers(sourceTable, SectionDividerHelper.ResolveCategoryColumn(sourceTable));
                HideTechnicalColumns();
                SectionDividerHelper.ApplyDividerStyles(grid, SectionDividerHelper.ResolveCategoryColumn(sourceTable));
                return;
            }

            string filter = string.Join("','", selected);
            DataView dv = new DataView(sourceTable);
            dv.RowFilter = $"nazov_tabulky IN ('{filter}')";
            var filtered = dv.ToTable();
            grid.DataSource = SectionDividerHelper.BuildWithDividers(filtered, SectionDividerHelper.ResolveCategoryColumn(filtered));
            HideTechnicalColumns();
            SectionDividerHelper.ApplyDividerStyles(grid, SectionDividerHelper.ResolveCategoryColumn(filtered));
        }

        private void HideTechnicalColumns()
        {
            if (grid.Columns.Contains("id"))
                grid.Columns["id"].Visible = false;
            if (grid.Columns.Contains("product_type_id"))
                grid.Columns["product_type_id"].Visible = false;
        }

        private List<string> GetCheckedCategories()
        {
            var list = new List<string>();

            foreach (TreeNode parent in tree.Nodes)
            {
                foreach (TreeNode child in parent.Nodes)
                    if (child.Checked)
                        list.Add(child.Text);
            }
            return list;
        }
    }
}
