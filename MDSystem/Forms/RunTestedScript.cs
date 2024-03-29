﻿using MDSystem.Data;
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

        private TimeSpan operatorTime = new TimeSpan();
        private TimeSpan selectedDBTime = new TimeSpan();

        private ScriptMD _selectedBDScript = null;
        private ScriptMD _operatorScript = null;
        private User selectedOperatorsUser { get { return (User)cmbOperators.SelectedItem; } }

        private DateTime _startDate;

        public RunTestedScript()
        {
            InitializeComponent();

            btnRunTest.Enabled = btnMakeStatus.Enabled = false;

            _operatorUsers = DataTransfer.GetDataObjects<User>(new GetDataFilterUser() { AllObjects = true }).ConvertAll(it => (User)it);
            cmbOperators.Items.AddRange(_operatorUsers.ToArray());
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
            if (selectedOperatorsUser == null)
            {
                MessageBox.Show("Не выбран оператор", "Внимание!");
                return;
            }

            btnMakeStatus.Enabled = btnSaveReport.Enabled = false;

            _startDate = DateTime.Now;
            _operatorScript = GetOperatorScript();

            if (_operatorScript.Actions.Count < _selectedBDScript.Actions.Count)
            {
                MessageBox.Show("Не все действия сценария выполнены", "Внимание!");
                return;
            }
            if (!_operatorScript.ActionsOrderList.SequenceEqual(_selectedBDScript.ActionsOrderList))
            {
                MessageBox.Show("Неверный порядок действий оператора", "Внимание!");
                return;
            }
            MakeReportData();
        }

        private void MakeReportData()
        {            
            operatorTime = new TimeSpan();
            foreach (var action in _operatorScript.Actions)
                operatorTime += action.TimeExecution;

            selectedDBTime = new TimeSpan();
            foreach (var action in _selectedBDScript.Actions)
                selectedDBTime += action.TimeExecution;

            TimeSpan result = operatorTime - selectedDBTime; // положительное время оператора лучше, отрицательное - время оператора хуже
            TimeSpan minuteTime = new TimeSpan(0, 1, 0);
            TimeSpan zero = new TimeSpan(0, 0, 0);


            string timeResult = "";
            timeResult += "Время выполнения сценария в БД: " + selectedDBTime.ToString() + Environment.NewLine;
            timeResult += "Время выполнения сценария пользователем: " + operatorTime.ToString() + Environment.NewLine;
            timeResult += "Разница времени выполнения: " + result.ToString() + Environment.NewLine;
            if (result > minuteTime)
                timeResult += "Тест не пройден: превышен временной интервал";
            else 
                timeResult += "Тест пройден";

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
            _actionsDate = "";
            _selectedBDScript = null;
            txtBDActionsList.Text = "";

            if (string.IsNullOrWhiteSpace(txtScriptName.Text))
                return;

            _selectedBDScript = (ScriptMD)(DataTransfer.GetDataObject<ScriptMD>(new GetDataFilterScriptMD { Name = txtScriptName.Text }));

            if (_selectedBDScript != null)
            {
                _selectedBDScript.Actions = (DataTransfer.GetDataObjects<ActionMD>(new GetDataFilterActionMD { ParentId = _selectedBDScript.Id })).ConvertAll(it => (ActionMD)it);

                foreach (var ac in _selectedBDScript.Actions)                
                    _actionsDate += ac.ToString() + Environment.NewLine;                

                txtBDActionsList.Text = _actionsDate;
                btnRunTest.Enabled = true;
            }
            else
            {
                MessageBox.Show("Сценарий " + "\"" + txtScriptName.Text + "\"" + " отсутствует в БД.");
                return;
            }            
        }
                
        private void btnSaveReport_Click(object sender, EventArgs e)
        {
            Report report = MakeNewReport();

            ReportEditForm re = new ReportEditForm(report);
            re.Show();
            //bool isSuccess = false;

            //if (report.Save(CommandAttribute.INSERT))
            //{
            //    foreach (var actionMD in report.Actions)
            //    {
            //        actionMD.ParentId = report.Id;
            //        isSuccess = actionMD.Save(CommandAttribute.INSERT);
            //    }
            //}

            //if (isSuccess)
            //    MessageBox.Show("Отчет сохранен");            
            //else
            //    MessageBox.Show("Ошибка сохранения");
        }

        private Report MakeNewReport()
        {
            Report report = new Report();
            report.Id = Guid.NewGuid();
            report.ScriptId = _selectedBDScript.Id;
            report.ScriptName = _selectedBDScript.Name;
            report.UserID = ApplicationData.CurrentUser.Id;
            report.OperatorFullName = selectedOperatorsUser.FullName;
            report.ActionsAmount = _operatorScript.Actions.Count;
            report.TimeExecutionAmount = operatorTime;
            report.Actions = _operatorScript.Actions;
            report.ActionsOrderList = _operatorScript.ActionsOrderList;
            report.Description = "";
            report.StartDate = _startDate;

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
    }
}
