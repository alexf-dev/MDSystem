using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDSystem.Forms
{
    public partial class ScriptEdit : Form
    {
        public ScriptEdit()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveScript();
        }

        private void SaveScript()
        {
            string fileName = Environment.CurrentDirectory + @"\" + "BDScripts.txt";
            string scriptData = "";
            scriptData += "script" + ";";// + Environment.NewLine;
            scriptData += txtScriptName.Text + ";";// + Environment.NewLine;
            scriptData += txtScriptCode.Text + ";";// + Environment.NewLine;
            scriptData += txtActionsList.Text;// + Environment.NewLine;
            scriptData += Environment.NewLine;

            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, true, System.Text.Encoding.UTF8))
                {
                    sw.Write(scriptData);
                }

                MessageBox.Show("Запись " + fileName + " выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }            
        }
    }
}
