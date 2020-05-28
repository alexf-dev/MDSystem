using MDSystem.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            UserEdit userEdit = new UserEdit();
            userEdit.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScriptEdit se = new ScriptEdit();
            se.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RunTestedScript rts = new RunTestedScript();
            rts.Show();
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DepartmentEdit de = new DepartmentEdit();
            de.Show();
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            WorkplaceEdit we = new WorkplaceEdit();
            we.Show();
        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReportListForm rl = new ReportListForm();
            rl.Show();
        }

        private void ToolStripMenuItem22_Click(object sender, EventArgs e)
        {
            DepartmentWorkplacesEditForm dw = new DepartmentWorkplacesEditForm();
            dw.Show();
        }
    }
}
