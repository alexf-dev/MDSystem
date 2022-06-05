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
            var text = new StringBuilder("  Оптимальный путь");
            text.AppendLine();
            text.AppendLine("  1-й блок: 3,5,");
            text.AppendLine("  2-й блок: 2,");
            text.AppendLine("  3-й блок: 1,4,");

            textBox1.Text = text.ToString();
        }
    }
}
