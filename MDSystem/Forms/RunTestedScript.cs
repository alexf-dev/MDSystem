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

        private TimeSpan operatorTime = new TimeSpan();
        private TimeSpan selectedDBTime = new TimeSpan();

        private ScriptMD _selectedBDScript = null;
        private ScriptMD _operatorScript = null;
        private User _operatorsUser = null;

        private string _firstName = "";
        private string _lastName = "";
        private string _middleName = "";
        private DateTime _startDate;

        public RunTestedScript()
        {
            InitializeComponent();

            btnRunTest.Enabled = false;

            //_bdScripts = GetBDScripts();
        }

        private List<ScriptMD> GetBDScripts()
        {
            List<ScriptMD> bdScripts = new List<ScriptMD>();

            //string fileName = Environment.CurrentDirectory + @"\" + "BDScripts.txt";
            //string scriptData = "";

            //// Получаем информацию о сценариях из BDScripts.txt
            //try
            //{
            //    using (StreamReader sr = new StreamReader(fileName, System.Text.Encoding.UTF8))
            //    {
            //        scriptData = sr.ReadToEnd();
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //// Каждая запись о скрипте в текстовом файле заканчивается символом *
            //// получаем массив строк, в каждой информация о конкретном скрипте
            //string[] sp = scriptData.Split(new char[] { '*'}, StringSplitOptions.RemoveEmptyEntries);

            //char[] trimChars = new char[] { '\\', 'r', 'n'};

            //foreach (var item in sp)
            //{
            //    // item - строка данных одного сценария
            //    if (item.Contains("script"))    // каждая строка сценария содержит слово script в начале строки, т.е. здесь мы избавляемся от пустых строк
            //    {
            //        List<string> items = item.Trim(trimChars).Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(it => it.Trim(trimChars)).ToList();
            //        if (items[0].Contains("script"))
            //            items.RemoveAt(0);

            //        ScriptMD script = new ScriptMD();
            //        script.Name = items[0];
            //        items.RemoveAt(0);
            //        script.Code = items[0];
            //        items.RemoveAt(0);

            //        // если в строке сценария отсутствуют действия - пропускаем эту строку, сценарий не учитывается
            //        if (items.Count > 0)
            //            script.Actions = new List<ActionMD>();
            //        else
            //            continue;

            //        // оставшиеся в items строки - действия по сценарию
            //        foreach (var data in items)
            //        {
            //            ActionMD actionMD = new ActionMD();

            //            // делим каждое действие на данные - номер по порядку, наименование, время выполнения
            //            List<string> dataList = data.Trim().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            //            // получаем индекс первого вхождения символа '.' - до этого символа это порядковый номер действия
            //            int orderValueIndex = dataList[0].IndexOf('.');
            //            string orderValueStr = dataList[0].Substring(0, orderValueIndex);

            //            actionMD.OrderValue = int.Parse(orderValueStr);
            //            actionMD.Name = dataList[0].Substring(orderValueIndex + 1).Trim();
            //            actionMD.TimeExecution = TimeSpan.Parse(dataList[1].Trim());

            //            script.Actions.Add(actionMD);
            //        }

            //        bdScripts.Add(script);
            //    }
            //}
            
            return bdScripts;
        }

        private void btnRunTest_Click(object sender, EventArgs e)
        {
            btnMakeStatus.Enabled = btnSaveReport.Enabled = false;

            _startDate = DateTime.Now;
            _operatorScript = GetOperatorScript();
            MakeReportData();
        }

        private void MakeReportData()
        {
            TimeSpan zeroTime = new TimeSpan(0, 0, 0);

            operatorTime = new TimeSpan();
            foreach (var action in _operatorScript.Actions)
                operatorTime += action.TimeExecution;

            selectedDBTime = new TimeSpan();
            foreach (var action in _selectedBDScript.Actions)
                selectedDBTime += action.TimeExecution;

            TimeSpan result = selectedDBTime - operatorTime;

            string timeResult = "";
            timeResult += "Время выполнения сценария в БД: " + selectedDBTime.ToString() + Environment.NewLine;
            timeResult += "Время выполнения сценария пользователем: " + operatorTime.ToString() + Environment.NewLine;
            timeResult += "Разница времени выполнения: " + result.ToString() + Environment.NewLine;

            txtTimeControl.Text = timeResult;
            btnMakeStatus.Enabled = btnSaveReport.Enabled = true;
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
                ActionMD actionMD = new ActionMD();

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

            List<int> orderList = new List<int>();

            foreach (var act in operatorScript.Actions)
                orderList.Add(act.OrderValue);

            operatorScript.ActionsOrderList = orderList.ToArray();

            //foreach (var act in operatorScript.Actions)
            //    operatorScript.ActionsOrderList.Add(act.OrderValue);

            return operatorScript;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _actionsDate = "";
            _selectedBDScript = null;
            txtBDActionsList.Text = "";

            if (string.IsNullOrWhiteSpace(txtScriptName.Text))
                return;

            _selectedBDScript = (ScriptMD)(DataTransfer.GetDataObject<ScriptMD>(new GetDataFilterScriptMD { Name = txtScriptName.Text }));
            //_bdScripts.FirstOrDefault(it => it.Name.Equals(txtScriptName.Text));

            if (_selectedBDScript != null)
            {
                _selectedBDScript.Actions = (DataTransfer.GetDataObjects<ActionMD>(new GetDataFilterActionMD { ParentId = _selectedBDScript.Id })).ConvertAll(it => (ActionMD)it);

                foreach (var ac in _selectedBDScript.Actions)                
                    _actionsDate += ac.OrderValue.ToString() + " " + ac.Name + " " + ac.TimeExecution.ToString() + Environment.NewLine;                

                txtBDActionsList.Text = _actionsDate;
                btnRunTest.Enabled = true;
            }
            else
            {
                MessageBox.Show("Сценарий " + "\"" + txtScriptName.Text + "\"" + " отсутствует в БД.");
                return;
            }            
        }

        private User GetOperatorsUser()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
                return null;

            MakeOperatorsFullName();

            return (User)(DataTransfer.GetDataObject<User>(new GetDataFilterUser { FirstName = _firstName, LastName = _lastName, MiddleName = _middleName }));
        }

        private void MakeOperatorsFullName()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
                return;

            string[] fullNameArray = txtFullName.Text.Split(new char[] { ' ' });

            _firstName = fullNameArray.Length > 0 ? fullNameArray[0].Trim() : "";
            _lastName = fullNameArray.Length > 1 ? fullNameArray[1].Trim() : "";
            _middleName = fullNameArray.Length > 2 ? fullNameArray[2].Trim() : "";
        }

        private void btnSaveReport_Click(object sender, EventArgs e)
        {
            Report report = MakeNewReport();

            if (report.Save(CommandAttribute.INSERT))
                MessageBox.Show("Отчет сохранен");
            else
                MessageBox.Show("Ошибка сохранения");
        }

        private Report MakeNewReport()
        {
            _operatorsUser = GetOperatorsUser();

            Report report = new Report();
            report.Id = Guid.NewGuid();
            report.ScriptId = _selectedBDScript.Id;
            report.ScriptName = _selectedBDScript.Name;
            report.UserID = ApplicationData.CurrentUser.Id;
            report.OperatorFullName = _operatorsUser.FullName;
            report.ActionsAmount = _operatorScript.Actions.Count;
            report.TimeExecutionAmount = operatorTime;
            report.Actions = _operatorScript.Actions;
            report.ActionsOrderList = _operatorScript.ActionsOrderList;
            report.Description = "";
            report.StartDate = _startDate;

            return report;
        }
    }
}
