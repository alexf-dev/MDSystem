using MDSystem.Data;
using MDSystem.Forms;
using MDSystem.Forms.Analysis;
using MDSystem.Forms.Documentation;
using MDSystem.Forms.Script;
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
        string _testProperty = "Test property";
        public MainForm()
        {
            InitializeComponent();

            if (ApplicationData.CurrentUser.AccessLevelValue < 2)
                addScriptBtn.Visible = button3.Visible = false;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            UserEdit userEdit = new UserEdit();
            userEdit.Show();
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

        private void справкаОПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramReferenceDataForm pf = new ProgramReferenceDataForm();
            pf.Show();
        }

        private void addScriptButton_Click(object sender, EventArgs e)
        {
            ScriptEdit se = new ScriptEdit();
            se.Show();
        }

        private void btnScriptList_Click(object sender, EventArgs e)
        {
            ScriptList sl = new ScriptList();
            sl.Show();
        }

        private void btnAddDocument_Click(object sender, EventArgs e)
        {
            DocumentEdit de = new DocumentEdit();
            de.Show();
        }

        private void btnDocumentList_Click(object sender, EventArgs e)
        {
            DocumentList dl = new DocumentList();
            dl.Show();
        }

        private void btnUserList_Click(object sender, EventArgs e)
        {
            UserList ul = new UserList();
            ul.Show();
        }

        private void btnAnalysisDocuments_Click(object sender, EventArgs e)
        {
            AnalysisDocumentsDiagram da = new AnalysisDocumentsDiagram();
            da.Show();
        }

        private void btnRankOperators_Click(object sender, EventArgs e)
        {
            AnalysisOperatorsDiagram aod = new AnalysisOperatorsDiagram();
            aod.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Processes pr = new Processes();
            pr.Show();
        }
    }
}
