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

        private List<bestHelper> bestCountReportsUsers = new List<bestHelper>();
        private List<bestHelper> notSuccesfulReportsCount = new List<bestHelper>();
        private List<bestHelper> zeroCountReports = new List<bestHelper>();

        public AnalysisOperatorsDiagram()
        {
            InitializeComponent();
        }

        private void AnalysisOperatorsDiagram_Load(object sender, EventArgs e)
        {
            _bdScripts = (DataTransfer.GetDataObjects<ScriptMD>(new GetDataFilterScriptMD { AllObjects = true })).ConvertAll(it => (ScriptMD)it);
            _bdUsers = (DataTransfer.GetDataObjects<User>(new GetDataFilterUser { AllObjects = true })).ConvertAll(it => (User)it);
            _reports = (DataTransfer.GetDataObjects<Report>(new GetDataFilterReport { AllObjects = true })).ConvertAll(it => (Report)it);

            FillOperatorModels();
            FillDataGridView();
            FillOperatorsAnanlysis();
        }       

        private void FillDataGridView()
        {
            dgvOperatorReports.RowCount = _bdUsers.Count + 1;
            dgvOperatorReports.ColumnCount = _bdScripts.Count + 1;
            dgvOperatorReports.Rows[0].Cells[0].Value = "ФИО";
                        
            var cl = 1;
            foreach (var script in _bdScripts)
            {
                dgvOperatorReports.Rows[0].Cells[cl].Value = script.Name;
                cl++;
            }

            int i = 1;
            foreach (var reportModel in _reportsModel)
            {
                if (reportModel.Value != null && reportModel.Value.Any())
                {
                    dgvOperatorReports.Rows[i].Cells[0].Value = reportModel.Key.FullName;

                    int c = 1;
                    foreach (var model in reportModel.Value)
                    {
                        dgvOperatorReports.Rows[i].Cells[c].Value = new helper() { OperatorId = model.UserId, ScriptId = model.ScriptId, CountReport = model.ReportCount };// model.ReportCount;
                        c++;                        
                    }
                }

                i++;
            }

            //foreach (var user in _bdUsers)
            //{
            //    var reportModel = _reportsModel.FirstOrDefault(x => x.Key.Id == user.Id);
            //    if (reportModel.Value != null && reportModel.Value.Any())
            //    {
            //        dgvOperatorReports.Rows[i].Cells[0].Value = reportModel.Key.FullName;

            //        int c = 1;
            //        foreach (var script in _bdScripts)
            //        {
            //            var model = reportModel.Value.FirstOrDefault(x => x.ScriptId == script.Id);
            //            if (model != null)
            //            {
            //                dgvOperatorReports.Rows[i].Cells[c].Value = new helper() { OperatorId = model.UserId, ScriptId = model.ScriptId, CountReport = model.ReportCount.ToString() };// model.ReportCount;
            //            }
            //            else
            //            {
            //                dgvOperatorReports.Rows[i].Cells[c].Value = 0;
            //            }
            //            c++;
            //        }
            //    }

            //    i++;
            //}

            dgvOperatorReports.Columns[0].MinimumWidth = 200;
        }

        private void FillOperatorModels()
        {
            foreach (var user in _bdUsers)
            {
                var userReports = _reports.Where(x => x.OperatorID == user.Id);
                var operatorModels = new List<AnalysisOperatorModel>();

                foreach (var script in _bdScripts)
                {
                    var scriptReports = userReports.Where(x => x.ScriptId == script.Id).ToList();
                    operatorModels.Add(new AnalysisOperatorModel
                                                        (
                                                            user.Id,
                                                            user.FullName,
                                                            script.Id,
                                                            script.Name,
                                                            scriptReports.Count(),
                                                            scriptReports.Where(it => it.Successful).Count(),
                                                            scriptReports.Where(it => !it.Successful).Count(),
                                                            scriptReports.Where(it => it.ActionsAmount == 0).Count()
                                                        ));
                }

                _reportsModel.Add(user, operatorModels);
            }
        }

        private void FillOperatorsAnanlysis()
        {     
            var userReports = new List<bestHelper>();

            foreach (var user in _bdUsers)
            {
                var reportModel = _reportsModel.FirstOrDefault(it => it.Key.Id == user.Id);
                if (!reportModel.Value.Any())
                {
                    zeroCountReports.Add(new bestHelper()
                    {
                        OperatorId = user.Id,
                        Name = user.FullName,
                        ReportsCount = 0,
                        SuccessfulReportsCount = 0
                    });
                    continue;
                }

                var zeroReports = reportModel.Value.Any(x => x.ReportCount == 0);
                if (zeroReports)
                {
                    zeroCountReports.Add(new bestHelper()
                    {
                        OperatorId = user.Id,
                        Name = user.FullName,
                        ReportsCount = 0,
                        SuccessfulReportsCount = 0                        
                    });
                    continue;
                }

                var reports = _reports.Where(x => x.OperatorID == user.Id && x.ActionsAmount > 0).ToList();

                var bestReports = reportModel.Value.Sum(x => x.SuccessfulReports);
                var badReports = reportModel.Value.Sum(x => x.NotSuccessfulReports);
               
                userReports.Add(new bestHelper()
                {
                    OperatorId = user.Id,
                    Name = user.FullName,
                    ReportsCount = reports.Count,
                    SuccessfulReportsCount = bestReports,
                    NotSuccessfulReportsCount = badReports,
                    SuccessfulReportsRank = (double)bestReports /reports.Count 
                });                
            }

            bestCountReportsUsers = userReports.OrderByDescending(x => x.SuccessfulReportsRank).ToList();
            notSuccesfulReportsCount = userReports.OrderByDescending(x => x.NotSuccessfulReportsCount).ToList();

            notSuccesfulReportsCount = notSuccesfulReportsCount.Except(bestCountReportsUsers).ToList();

            var bestResult = "Наиболее подходящие кандидаты: " + Environment.NewLine;

            int i = 1;
            foreach (var user in bestCountReportsUsers.Take(2))
            {
                bestResult += $"{i}) {user.Name}" + Environment.NewLine;
                i++;
            }

            textBox1.Text = bestResult;

            var badResult = "Не рекомендуются: " + Environment.NewLine;
            i = 1;

            if (zeroCountReports.Any())
            {
                foreach (var user in zeroCountReports)
                {
                    badResult += $"{i}) {user.Name}" + Environment.NewLine;
                    i++;
                }
            }
            else
            {
                foreach (var user in notSuccesfulReportsCount.Take(2))
                {
                    badResult += $"{i}) {user.Name}" + Environment.NewLine;
                    i++;
                }
            }

            textBox2.Text = badResult;
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

        class helper
        {
            public Guid OperatorId { get; set; }

            public Guid ScriptId { get; set; }

            public int CountReport { get; set; }

            public override string ToString()
            {
                return CountReport.ToString();
            }
        }

        class bestHelper
        {
            public Guid OperatorId { get; set; }

            public string Name { get; set; }

            public int ReportsCount { get; set; }

            public int SuccessfulReportsCount { get; set; }

            public int NotSuccessfulReportsCount { get; set; }

            public double SuccessfulReportsRank { get; set; }
        }
    }
}
