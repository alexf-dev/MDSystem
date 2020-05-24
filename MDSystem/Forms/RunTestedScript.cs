using MDSystem.Objects;
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
    public partial class RunTestedScript : Form
    {
        private string _fullName = "";
        private string _scriptName = "";
        private string _actionsDate = "";


        private List<ScriptMD> _scripts = new List<ScriptMD>();

        public RunTestedScript()
        {
            InitializeComponent();

            btnRunTest.Enabled = false;

            GetScripts();
        }

        private void GetScripts()
        {
            //_scriptName = txtScriptName.Text;
            
            string fileName = Environment.CurrentDirectory + @"\" + "Scripts.txt";
            string scriptData = "";

            try
            {
                using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.UTF8))
                {
                    scriptData = sr.ReadToEnd();
                }

                //MessageBox.Show("Запись " + fileName + " выполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            string[] sp = scriptData.Split(new char[] { '*'}, StringSplitOptions.RemoveEmptyEntries);

            char[] trimChars = new char[] { '\\', 'r', 'n'};

            foreach (var item in sp)
            {
                if (item.Contains("script"))
                {
                    List<string> items = item.Trim(trimChars).Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(it => it.Trim(trimChars)).ToList();
                    if (items[0].Contains("script"))
                        items.RemoveAt(0);

                    ScriptMD script = new ScriptMD();
                    script.Name = items[0];
                    items.RemoveAt(0);
                    script.Code = items[0];
                    items.RemoveAt(0);

                    if (items.Count > 0)
                        script.Actions = new List<ActionMD>();
                    else
                        continue;

                    foreach (var data in items)
                    {
                        ActionMD actionMD = new ActionMD();

                        List<string> dataList = data.Trim().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                        List<string> dataAction = dataList[0].Split(new char[] { '.' }).ToList();

                        actionMD.OrderValue = int.Parse(dataAction[0]);
                        actionMD.Name = dataAction[1].Trim();

                        actionMD.TimeSpan = TimeSpan.Parse(dataList[1].Trim());

                        script.Actions.Add(actionMD);
                    }

                    _scripts.Add(script);
                }
            }

            //foreach (var scr in _scripts)
            //{
            //    foreach (var ac in scr.Actions)
            //    {
            //        _actionsDate += ac.OrderValue.ToString() + " " + ac.Name + " " + ac.TimeSpan.ToString() + Environment.NewLine;
            //    }
            //    _actionsDate += Environment.NewLine;
            //}

            //txtBDActionsList.Text = _actionsDate;

            btnRunTest.Enabled = true;
        }

        private void btnRunTest_Click(object sender, EventArgs e)
        {
            txtBDActionsList.Text = "";

            if (string.IsNullOrWhiteSpace(txtScriptName.Text))
                return;

            ScriptMD sc = _scripts.FirstOrDefault(it => it.Name.Equals(txtScriptName.Text));

            if (sc != null)
            {
                foreach (var ac in sc.Actions)
                {
                    _actionsDate += ac.OrderValue.ToString() + " " + ac.Name + " " + ac.TimeSpan.ToString() + Environment.NewLine;
                }

                txtBDActionsList.Text = _actionsDate;
            }
            else
            {
                MessageBox.Show("Сценарий " + "\"" + txtScriptName.Text + "\"" + " отсутствует в БД.");
                return;
            }
        }
    }
}
