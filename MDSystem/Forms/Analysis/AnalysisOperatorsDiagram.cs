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

namespace MDSystem.Forms.Analysis
{
    public partial class AnalysisOperatorsDiagram : Form
    {
        private List<ScriptMD> _bdScripts = new List<ScriptMD>();
        private List<User> _bdUsers = new List<User>();
        private List<Report> _reports = new List<Report>();
        private Dictionary<User, List<AnalysisOperatorModel>> _reportsModel = new Dictionary<User, List<AnalysisOperatorModel>>();

        public AnalysisOperatorsDiagram()
        {
            InitializeComponent();
        }

        private void AnalysisOperatorsDiagram_Load(object sender, EventArgs e)
        {
            _bdScripts = (DataTransfer.GetDataObjects<ScriptMD>(new GetDataFilterScriptMD { AllObjects = true })).ConvertAll(it => (ScriptMD)it);
            _bdUsers = (DataTransfer.GetDataObjects<User>(new GetDataFilterUser { AllObjects = true })).ConvertAll(it => (User)it);
            _reports = (DataTransfer.GetDataObjects<Report>(new GetDataFilterReport { AllObjects = true })).ConvertAll(it => (Report)it);

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ФИО");
            foreach (var script in _bdScripts)
            {
                dataTable.Columns.Add("Script " + script.Name);
            }

            foreach (var user in _bdUsers)
            {
                var reports = _reports.Where(x => x.OperatorID == user.Id);
                var operatorModels = reports.Select(x => new AnalysisOperatorModel(user.Id, user.FullName, x.ScriptId, _bdScripts.First(it => it.Id == x.ScriptId).Name, _reports.Where(it => it.ScriptId == x.ScriptId).Count().ToString())).ToList();

                _reportsModel.Add(user, operatorModels);
            }

            dgvOperatorReports.RowCount = _bdUsers.Count + 1;
            dgvOperatorReports.ColumnCount = _bdScripts.Count + 1;
            dgvOperatorReports.Rows[0].Cells[0].Value = "ФИО";

            var sc = 0;
            var cl = 1;
            foreach (var script in _bdScripts)
            {
                dgvOperatorReports.Rows[0].Cells[cl].Value = script.Name;
                cl++;
            }

            foreach (var user in _bdUsers)
            {
                int i = 1;

                var reportModel = _reportsModel.FirstOrDefault(x => x.Key.Id == user.Id);
                if (reportModel.Value != null && reportModel.Value.Any())
                {
                    dgvOperatorReports.Rows[i].Cells[0].Value = reportModel.Key.FullName;

                    int c = 1;
                    foreach (var script in _bdScripts)
                    {
                        var model = reportModel.Value.FirstOrDefault(x => x.ScriptId == script.Id);
                        if (model != null)
                        {
                            dgvOperatorReports.Rows[i].Cells[c].Value = new helper() { OperatorId = model.UserId, ScriptId = model.ScriptId, CountReport = model.ReportCount };// model.ReportCount;
                        }
                        else
                        {
                            dgvOperatorReports.Rows[i].Cells[c].Value = 0;
                        }
                        c++;
                    }
                }

                i++;
            }

            dgvOperatorReports.Columns[0].MinimumWidth = 200;
        }

        class helper
        {
            public Guid OperatorId { get; set; }

            public Guid ScriptId { get; set; }

            public string CountReport { get; set; }

            public override string ToString()
            {
                return CountReport.ToString();
            }
        }

        private void dgvOperatorReports_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var value = dgvOperatorReports.SelectedCells[0].Value;
            if (value is helper)
            {
                OperatorReportsDiagram od = new OperatorReportsDiagram(((helper)value).OperatorId, ((helper)value).ScriptId);
                od.Show();
            }
        }
    }
}
