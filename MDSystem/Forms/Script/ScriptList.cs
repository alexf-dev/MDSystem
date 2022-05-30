using MDSystem.Data;
using MDSystem.Objects;
using MDSystem.Objects.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDSystem.Forms.Script
{
    public partial class ScriptList : Form
    {
        private string _actionsDate = "";

        private List<ScriptMD> _bdScripts = new List<ScriptMD>();
        private List<ModelScriptMD> _bdScriptModels = new List<ModelScriptMD>();

        private ScriptMD _selectedBDScript = null;

        public ScriptList()
        {
            InitializeComponent();
        }

        private void ScriptList_Load(object sender, EventArgs e)
        {
            _bdScripts = (DataTransfer.GetDataObjects<ScriptMD>(new GetDataFilterScriptMD { AllObjects = true })).ConvertAll(it => (ScriptMD)it);            

            if (_bdScripts != null)
            {
                _bdScriptModels = _bdScripts.OrderBy(it => it.RegDate).Select(it => new ModelScriptMD(it.Id, it.Name)).ToList();

                foreach (ModelScriptMD script in _bdScriptModels)
                {
                    listScripts.Items.Add(script);
                }
            }
        }

        private void listScripts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var script = listScripts.SelectedItem as ModelScriptMD;

            if (script != null)
            {
                _actionsDate = "";
                _selectedBDScript = null;
                textScript.Text = "";

                if (string.IsNullOrWhiteSpace(listScripts.SelectedItem.ToString()))
                    return;

                _selectedBDScript = (ScriptMD)(DataTransfer.GetDataObject<ScriptMD>(new GetDataFilterScriptMD { Id = script.Id }));

                if (_selectedBDScript != null)
                {
                    _selectedBDScript.Actions = (DataTransfer.GetDataObjects<ActionMD>(new GetDataFilterActionMD { ParentId = _selectedBDScript.Id })).ConvertAll(it => (ActionMD)it);

                    var selectedDBTime = new TimeSpan();

                    foreach (var action in _selectedBDScript.Actions)
                    {
                        _actionsDate += action.ToString() + Environment.NewLine;
                        selectedDBTime += action.TimeExecution;
                    }

                    _actionsDate += Environment.NewLine;
                    _actionsDate += "Общая норма времени выполнения: " + selectedDBTime.ToString();

                    textScript.Text = _actionsDate;
                }
                else
                {
                    MessageBox.Show("Сценарий " + "\"" + script.Name + "\"" + " отсутствует в БД.");
                    return;
                }
            }
        }
    }
}
