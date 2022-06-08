using MDSystem.Data;
using MDSystem.Objects;
using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDSystem.Forms
{
    public partial class ReportEditForm : Form
    {
        private Report report { get; set; }

        public ReportEditForm(Report _report, bool isNewRecord = true)
        {
            InitializeComponent();

            if (isNewRecord)
                this.Text = "Новый отчет";

            report = _report;
            ShowReport();
        }

        private void ShowReport()
        {
            StringBuilder reportsList = new StringBuilder();            
            StringBuilder sb = new StringBuilder("ФИО оператора: " + report.OperatorFullName);
            sb.AppendLine();
            sb.AppendLine("Сценарий: " + report.ScriptName);
            sb.AppendLine("Время запуска теста: " + report.StartDate.ToString());
            sb.AppendLine("Список действий: ");

            //report.Actions = (DataTransfer.GetDataObjects<ActionMD>(new GetDataFilterActionMD { ParentId = report.Id })).ConvertAll(it => (ActionMD)it);

            if (report.Actions != null)
            {
                foreach (var action in report.Actions)
                {
                    sb.AppendLine(action.ToString());
                }
            }

            sb.AppendLine("Количество выполненных оператором действий: " + report.ActionsAmount);
            sb.AppendLine("Суммарное время выполнения оператором действий: " + report.TimeExecutionAmount.ToString());

            //if (!string.IsNullOrWhiteSpace(report.Description))
            //    sb.AppendLine("Комментарий: " + report.Description);

            sb.AppendLine();
            reportsList.Append(sb);  
            txtReportList.Text = reportsList.ToString();
            txtDescription.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string result;

            if (IsValidData(out result))
            {
                bool isSuccess = false;

                if (SaveReport())
                {
                    if (!report.Actions.Any())
                    {
                        isSuccess = true;
                    }
                    else
                    {
                        foreach (var actionMD in report.Actions)
                        {
                            actionMD.ParentId = report.Id;
                            isSuccess = actionMD.Save(CommandAttribute.INSERT);
                        }
                    }
                }

                if (isSuccess)
                    MessageBox.Show("Отчет сохранен");
                else
                    MessageBox.Show("Ошибка сохранения действий");
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

            if (string.IsNullOrWhiteSpace(txtReportList.Text))
                result += "Нет данных для сохранения отчета\r\n";
            if (report == null)
                result += "Не выбран отчет для сохранения\r\n";

            if (!string.IsNullOrWhiteSpace(result))
                return false;

            return true;
        }

        private bool SaveReport()
        {
            report.Description = txtDescription.Text;
            return report.Save(CommandAttribute.INSERT);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
