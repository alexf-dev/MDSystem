using MDSystem.Data;
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
        private string _actionsDate = "";

        private List<ScriptMD> _bdScripts = new List<ScriptMD>();
        private List<ScriptMD> _operatorScripts = new List<ScriptMD>();
        private List<User> _operatorUsers = new List<User>();
        private List<ScriptMD> _selectedBDScripts = new List<ScriptMD>();

        private TimeSpan operatorTime = new TimeSpan();
        private TimeSpan selectedDBTime = new TimeSpan();

        private ScriptMD _operatorScript = null;
        private User selectedOperatorsUser { get { return (User)cmbOperators.SelectedItem; } }
        private ScriptMD _selectedBDScript { get { return (ScriptMD)cmbScripts.SelectedItem; } }

        private DateTime _startDate;
        private bool _IsSuccessful = true;

        public RunTestedScript()
        {
            InitializeComponent();

            btnRunTest.Enabled = btnMakeStatus.Enabled = false;

            _operatorUsers = DataTransfer.GetDataObjects<User>(new GetDataFilterUser() { AllObjects = true }).ConvertAll(it => (User)it);
            _selectedBDScripts = DataTransfer.GetDataObjects<ScriptMD>(new GetDataFilterScriptMD { AllObjects = true }).ConvertAll(it => (ScriptMD)it);
            cmbOperators.Items.AddRange(_operatorUsers.ToArray());
            cmbScripts.Items.AddRange(_selectedBDScripts.ToArray());
        }

        private void btnRunTest_Click(object sender, EventArgs e)
        {
            if (selectedOperatorsUser == null)
            {
                MessageBox.Show("Не выбран оператор", "Внимание!");
                return;
            }

            btnMakeStatus.Enabled = btnSaveReport.Enabled = false;

            _startDate = DateTime.Now;
            _operatorScript = GetOperatorScript();

            var isValidActions = true;
            if (_operatorScript.Actions.Count < _selectedBDScript.Actions.Count)
            {
                MessageBox.Show("Не все действия сценария выполнены", "Внимание!");
                isValidActions = false;
            }
            else if (!_operatorScript.ActionsOrderList.SequenceEqual(_selectedBDScript.ActionsOrderList))
            {
                MessageBox.Show("Неверный порядок действий оператора", "Внимание!");
                isValidActions = false;
            }
            MakeReportData(isValidActions);
        }

        private void MakeReportData(bool isValidActions)
        {
            string timeResult = "";

            if (!isValidActions)
            {
                _operatorScript.Actions.Clear();

                operatorTime = new TimeSpan(0, 0, 0);
                selectedDBTime = new TimeSpan();
                foreach (var action in _selectedBDScript.Actions)
                    selectedDBTime += action.TimeExecution;
                
                timeResult += "Время выполнения сценария в БД: " + selectedDBTime.ToString() + Environment.NewLine;
                timeResult += "Время выполнения сценария пользователем: " + operatorTime.ToString() + Environment.NewLine;
                timeResult += "Разница времени выполнения: " + selectedDBTime.ToString() + Environment.NewLine;
                timeResult += "Тест не пройден: нарушение выполнения действий";

                _IsSuccessful = false;
            }
            else
            {
                operatorTime = new TimeSpan();
                foreach (var action in _operatorScript.Actions)
                    operatorTime += action.TimeExecution;

                selectedDBTime = new TimeSpan();
                foreach (var action in _selectedBDScript.Actions)
                    selectedDBTime += action.TimeExecution;

                TimeSpan result = operatorTime - selectedDBTime; 
                TimeSpan zero = new TimeSpan(0, 0, 0);

                timeResult += "Время выполнения сценария в БД: " + selectedDBTime.ToString() + Environment.NewLine;
                timeResult += "Время выполнения сценария пользователем: " + operatorTime.ToString() + Environment.NewLine;
                timeResult += "Разница времени выполнения: " + result.ToString() + Environment.NewLine;
                if (result > zero)
                {
                    timeResult += "Тест не пройден: превышен временной интервал";
                    _IsSuccessful = false;
                }
                else
                {
                    timeResult += "Тест пройден";
                    _IsSuccessful = true;
                }
            }

            txtTimeControl.Text = timeResult;
            btnMakeStatus.Enabled = ApplicationData.CurrentUser.AccessLevelValue > 1 ? true : false;
            btnSaveReport.Enabled = true;
        }

        private ScriptMD GetOperatorScript()
        {
            string actionsData = txtUserActionsList.Text;
            string[] sp = actionsData.Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
            char[] trimChars = new char[] { '\\', 'r', 'n' };

            ScriptMD operatorScript = new ScriptMD();
            operatorScript.Id = Guid.NewGuid();
            operatorScript.Name = _selectedBDScript.Name;
            operatorScript.Code = _selectedBDScript.Code;
            operatorScript.Actions = new List<ActionMD>();

            foreach (var item in sp)
            {
                if (!string.IsNullOrWhiteSpace(item) && item.Contains('|'))
                {
                    ActionMD actionMD = new ActionMD();
                    actionMD.Id = Guid.NewGuid();

                    // делим каждое действие на данные - номер по порядку, наименование, время выполнения
                    List<string> dataList = item.Trim().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                    // получаем индекс первого вхождения символа '.' - до этого символа это порядковый номер действия
                    int orderValueIndex = dataList[0].IndexOf('.');
                    string orderValueStr = dataList[0].Substring(0, orderValueIndex);

                    actionMD.OrderValue = int.Parse(orderValueStr);
                    actionMD.Name = dataList[0].Substring(orderValueIndex + 1).Trim();
                    actionMD.TimeExecution = TimeSpan.Parse(dataList[1].Trim());

                    operatorScript.Actions.Add(actionMD);
                }
            }

            List<int> orderList = new List<int>();

            foreach (var act in operatorScript.Actions)
                orderList.Add(act.OrderValue);

            operatorScript.ActionsOrderList = orderList.ToArray();

            return operatorScript;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //_actionsDate = "";
            //_selectedBDScript = null;
            //txtBDActionsList.Text = "";

            //if (string.IsNullOrWhiteSpace(txtScriptName.Text))
            //    return;

            //_selectedBDScript = (ScriptMD)(DataTransfer.GetDataObject<ScriptMD>(new GetDataFilterScriptMD { Name = txtScriptName.Text }));

            //if (_selectedBDScript != null)
            //{
            //    _selectedBDScript.Actions = (DataTransfer.GetDataObjects<ActionMD>(new GetDataFilterActionMD { ParentId = _selectedBDScript.Id })).ConvertAll(it => (ActionMD)it);

            //    foreach (var ac in _selectedBDScript.Actions)                
            //        _actionsDate += ac.ToString() + Environment.NewLine;                

            //    txtBDActionsList.Text = _actionsDate;
            //    btnRunTest.Enabled = true;
            //}
            //else
            //{
            //    MessageBox.Show("Сценарий " + "\"" + txtScriptName.Text + "\"" + " отсутствует в БД.");
            //    return;
            //}            
        }
                
        private void btnSaveReport_Click(object sender, EventArgs e)
        {
            Report report = MakeNewReport();

            ReportEditForm re = new ReportEditForm(report);
            re.Show();
        }

        private Report MakeNewReport()
        {
            Report report = new Report();
            report.Id = Guid.NewGuid();
            report.ScriptId = _selectedBDScript.Id;
            report.ScriptName = _selectedBDScript.Name;
            report.UserID = ApplicationData.CurrentUser.Id;
            report.OperatorID = selectedOperatorsUser.Id;
            report.OperatorFullName = selectedOperatorsUser.FullName;
            report.ActionsAmount = _operatorScript.Actions.Count;
            report.TimeExecutionAmount = operatorTime;
            report.Actions = _operatorScript.Actions;
            report.ActionsOrderList = _operatorScript.ActionsOrderList;
            report.Description = "";
            report.StartDate = _startDate;
            report.Successful = _IsSuccessful;

            return report;
        }

        private void btnMakeStatus_Click(object sender, EventArgs e)
        {
            if (selectedOperatorsUser != null)
            {
                UserStatusChangeForm sf = new UserStatusChangeForm(selectedOperatorsUser);
                sf.Show();
            }
            else
                MessageBox.Show("Не указаны данные оператора", "Внимание!");
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

        private void cmbScripts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbScripts.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                _actionsDate = "";
                txtBDActionsList.Text = "";

                if (_selectedBDScript != null)
                {
                    _selectedBDScript.Actions = (DataTransfer.GetDataObjects<ActionMD>(new GetDataFilterActionMD { ParentId = _selectedBDScript.Id })).ConvertAll(it => (ActionMD)it);

                    foreach (var ac in _selectedBDScript.Actions)
                        _actionsDate += ac.ToString() + Environment.NewLine;

                    txtBDActionsList.Text = _actionsDate;
                    btnRunTest.Enabled = true;
                }
            }
        }
    }
}
