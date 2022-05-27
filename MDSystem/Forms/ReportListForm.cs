using MDSystem.Data;
using MDSystem.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDSystem.Forms
{
    public partial class ReportListForm : Form
    {
        private List<Report> _reports = new List<Report>();
        private List<User> _operatorUsers = new List<User>();

        private User selectedOperatorsUser { get { return (User)cmbOperatorUsers.SelectedItem; } }

        public ReportListForm()
        {
            InitializeComponent();

            _operatorUsers = DataTransfer.GetDataObjects<User>(new GetDataFilterUser() { AllObjects = true }).ConvertAll(it => (User)it);
            cmbOperatorUsers.Items.AddRange(_operatorUsers.ToArray());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            if (selectedOperatorsUser == null)
                return;

            _reports = (DataTransfer.GetDataObjects<Report>(new GetDataFilterReport {  OperatorFullName = selectedOperatorsUser.FullName })).ConvertAll(it => (Report)it);

            ShowReports(_reports);
        }

        private void ShowReports(List<Report> reports)
        {
            StringBuilder reportsList = new StringBuilder();

            int order = 1;
            foreach (var report in reports.OrderBy(it => it.RecDate))
            {
                StringBuilder sb = new StringBuilder("Отчет №" + order);
                sb.AppendLine();
                sb.AppendLine("Сценарий: " + report.ScriptName);
                sb.AppendLine("Время запуска теста: " + report.StartDate.ToString());
                sb.AppendLine("Список действий: ");

                report.Actions = (DataTransfer.GetDataObjects<ActionMD>(new GetDataFilterActionMD { ParentId = report.Id })).ConvertAll(it => (ActionMD)it);

                if (report.Actions != null)
                {
                    foreach (var action in report.Actions)
                    {
                        sb.AppendLine(action.ToString());
                    }
                }
                
                sb.AppendLine("Количество выполненных оператором действий: " + report.ActionsAmount);
                sb.AppendLine("Суммарное время выполнения оператором действий: " + report.TimeExecutionAmount.ToString());

                if (!string.IsNullOrWhiteSpace(report.Description))
                    sb.AppendLine("Комментарий: " + report.Description);

                sb.AppendLine();
                reportsList.Append(sb);

                order++;
            }

            txtReportList.Text = reportsList.ToString();
        }

        private void cmbOperatorUsers_SelectedValueChanged(object sender, EventArgs e)
        {
            btnReports.Enabled = selectedOperatorsUser != null;
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
