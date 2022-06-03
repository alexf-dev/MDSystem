using MDSystem.Data;
using MDSystem.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            string result;

            if (IsValidData(out result))
            {
                ScriptMD sc = (ScriptMD)DataTransfer.GetDataObject<ScriptMD>(new GetDataFilterScriptMD { Name = txtScriptName.Text });

                if (sc != null)
                {
                    if (MessageBox.Show(string.Format("Сценарий '{0}' уже присутствует в БД, заменить данные?", txtScriptName.Text), "Внимание!", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                        return;
                    else
                    {
                        if (UpdateScript(sc))
                            MessageBox.Show("Сценарий обновлен");
                        else
                            MessageBox.Show("Ошибка сохранения");
                    }
                }
                else
                {
                    if (SaveScript())
                        MessageBox.Show("Сценарий сохранен");
                    else
                        MessageBox.Show("Ошибка сохранения");
                }
            }
            else
            {
                MessageBox.Show(result, "Внимание!");
                return;
            }
        }        

        private bool IsValidData(out string result)
        {
            result = "";

            if (string.IsNullOrWhiteSpace(txtScriptName.Text))
                result += "Не указано наименование сценария\r\n";

            if (string.IsNullOrWhiteSpace(txtActionsList.Text))
                result += "Не заполнен список действий\r\n";

            if (!string.IsNullOrWhiteSpace(result))
                return false;

            return true;
        }

        private bool SaveScript()
        {
            ScriptMD script = new ScriptMD();
            script.Id = Guid.NewGuid();
            script.Name = txtScriptName.Text;
            script.ScriptType = ScriptMDType.Тестовый;
            script.Actions = GetScriptActions();
            script.ChangeCount = 1;


            List<int> orderList = new List<int>();

            foreach (var act in script.Actions)
                orderList.Add(act.OrderValue);

            script.ActionsOrderList = orderList.ToArray();

            bool isSuccess = false;

            if (script.Save(CommandAttribute.INSERT))
            {
                foreach (var actionMD in script.Actions)
                {
                    actionMD.ParentId = script.Id;
                    isSuccess = actionMD.Save(CommandAttribute.INSERT);
                }
            }

            return isSuccess;
        }

        private bool UpdateScript(ScriptMD script)
        {
            List<ActionMD> oldActions = DataTransfer.GetDataObjects<ActionMD>(new GetDataFilterActionMD() { ParentId = script.Id }).ConvertAll(it => (ActionMD)it);
            script.Actions = GetScriptActions();

            List<int> orderList = new List<int>();

            foreach (var act in script.Actions)
                orderList.Add(act.OrderValue);

            script.ActionsOrderList = orderList.ToArray();

            bool isSuccess = true;

            foreach (var action in oldActions)
            {
                isSuccess = action.Save(CommandAttribute.DELETE);
            }

            script.ChangeCount += script.ChangeCount;
            if (isSuccess && script.Save(CommandAttribute.UPDATE))
            {
                foreach (var actionMD in script.Actions)
                {
                    actionMD.ParentId = script.Id;
                    isSuccess = actionMD.Save(CommandAttribute.INSERT);
                }
            }

            return isSuccess;
        }

        private List<ActionMD> GetScriptActions()
        {
            string actionsData = txtActionsList.Text;
            string[] sp = actionsData.Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
            char[] trimChars = new char[] { '\\', 'r', 'n' };

            List<ActionMD> actions = new List<ActionMD>();   

            foreach (var item in sp)
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
                actionMD.ActionType = ActionMDType.Вычисление;

                actions.Add(actionMD);
            }

            return actions;
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
