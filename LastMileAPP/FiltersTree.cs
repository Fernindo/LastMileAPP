using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace LastMileAPP
{
    internal class FiltersTree
    {
        public static void Build(TreeView tree, DataTable categoryTable)
        {
            tree.Nodes.Clear();

            var groups = categoryTable.AsEnumerable()
                .GroupBy(r => r.Field<string>("hlavna_kategoria"))
                .OrderBy(g => g.Key);

            foreach (var g in groups)
            {
                TreeNode parent = new TreeNode(g.Key) { Checked = false };

                foreach (var r in g)
                {
                    if (!r.IsNull("nazov_tabulky"))
                        parent.Nodes.Add(new TreeNode(r.Field<string>("nazov_tabulky")) { Checked = false });
                }

                tree.Nodes.Add(parent);
            }            
        }

        public static List<string> GetCheckedCategories(TreeView tree)
        {
            var list = new List<string>();

            foreach (TreeNode parent in tree.Nodes)
            {
                foreach (TreeNode child in parent.Nodes)
                {
                    if (child.Checked)
                        list.Add(child.Text);
                }
            }
            return list;
        }
        
    }
}
