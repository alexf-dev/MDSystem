using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MDSystem.Forms
{
    public partial class ProgramReferenceDataForm : Form
    {
        public ProgramReferenceDataForm()
        {
            InitializeComponent();         

            txtAuthor.Text = MDSystem.Properties.Settings.Default.Author;
            txtVersion.Text = MDSystem.Properties.Settings.Default.Version;
            txtDescription.Text = MDSystem.Properties.Settings.Default.MoreInfo;

            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo("Instruction.txt");
            p.Start();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
