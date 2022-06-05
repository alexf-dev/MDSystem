using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDSystem.Forms
{
    public partial class Processes : Form
    {
        public Processes()
        {
            InitializeComponent();
        }

        private void Processes_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            dataGridView1.Rows.Add(5, 8, 3);
            dataGridView1.Rows.Add(6, 7, 8);
            dataGridView1.Rows.Add(4, 7, 5);
            dataGridView1.Rows.Add(6, 4, 4);
            dataGridView1.Rows.Add(5, 6, 7);


            var text = new StringBuilder("  Оптимальный путь");
            text.AppendLine();
            text.AppendLine("  1-й блок: 3,5,");
            text.AppendLine("  2-й блок: 2,");
            text.AppendLine("  3-й блок: 1,4,");

            textBox1.Text = text.ToString();
        }
    }
}
