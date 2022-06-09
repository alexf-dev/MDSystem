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
using System.Windows.Forms.DataVisualization.Charting;

namespace MDSystem.Forms.Analysis
{
    public partial class OperatorReportsDiagram : Form
    {
        private readonly Guid _operatorId;
        private readonly Guid _scriptId;
        private ScriptMD _bdScript;
        private List<Report> _bdReports = new List<Report>();
        private List<ActionMD> _bdActions = new List<ActionMD>();
        private List<ReportModel> _bdReportModels = new List<ReportModel>();

        public OperatorReportsDiagram()
        {
            InitializeComponent();
        }

        public OperatorReportsDiagram(Guid operatorId, Guid scriptId)
        {
            InitializeComponent();

            _operatorId = operatorId;
            _scriptId = scriptId;
        }

        private void OperatorReportsDiagram_Load(object sender, EventArgs e)
        {
            _bdActions = (DataTransfer.GetDataObjects<ActionMD>(new GetDataFilterActionMD { ParentId = _scriptId })).ConvertAll(it => (ActionMD)it);
            _bdReports = (DataTransfer.GetDataObjects<Report>(new GetDataFilterReport {  OperatorID = _operatorId, ScriptID = _scriptId })).ConvertAll(it => (Report)it);

            if (_bdReports != null && _bdReports.Any())
            {
                _bdReportModels = _bdReports.OrderBy(it => it.RecDate)
                    .Select(it => new ReportModel(
                        it.StartDate,
                        it.ScriptId,
                        it.ScriptName,
                        it.OperatorID,
                        it.ActionsAmount,
                        it.TimeExecutionAmount,
                        it.Successful, 
                        it.ActionsOrderList))
                    .ToList();

                FillReportsDiagram(_bdReportModels);
                FillOperatorResult(_bdReportModels);
                FillOperatorAnalysis(_bdReportModels);
            }
            else
            {
                MessageBox.Show("Список выполненных сценариев пуст", "Внимание!");
                Close();
            }
        }

        private void FillReportsDiagram(List<ReportModel> values)
        {
            if (values != null && values.Any())
            {
                var selectedDBTime = new TimeSpan();
                foreach (var action in _bdActions)
                {
                    selectedDBTime += action.TimeExecution;
                }

                double lineHeight = selectedDBTime.TotalMinutes;

                var maxTotalMinutes = _bdReportModels.Max(x => x.TimeExecutionAmount.TotalMinutes);
                chart1.ChartAreas[0].AxisY.Maximum = lineHeight > maxTotalMinutes ? lineHeight + 2 : maxTotalMinutes + 2;

                int i = 0;
                foreach (var item in _bdReportModels)
                {                   
                    chart1.Series["Series1"].Points.AddXY(item.StartDate.ToShortDateString(), item.TimeExecutionAmount.TotalMinutes);
                    i++;
                }

                HorizontalLineAnnotation ann = new HorizontalLineAnnotation();
                ann.AxisX = chart1.ChartAreas[0].AxisX;
                ann.AxisY = chart1.ChartAreas[0].AxisY;
                ann.IsSizeAlwaysRelative = false;
                ann.AnchorY = lineHeight;
                ann.IsInfinitive = true;
                ann.ClipToChartArea = chart1.ChartAreas[0].Name;
                ann.LineColor = Color.Blue;
                ann.LineWidth = 2;
                ann.LineDashStyle = ChartDashStyle.Dash;
                chart1.Annotations.Add(ann);
            }            
        }

        private void FillOperatorResult(List<ReportModel> values)
        {
            var operatorFullName = _bdReports[0].OperatorFullName;
            var result = $"Прогресс оператора {operatorFullName}" + Environment.NewLine;
            result += Environment.NewLine;

            foreach (var item in values)
            {
                var success = item.Successful ? "допуск" : (item.ActionsAmount == 0 ? "не выполнен" : "требуется доработка");
                result += $"{item.ScriptName}  |   {item.TimeExecutionAmount}  |  {success}";
                result += Environment.NewLine;
            }

            txtOperatorResult.Text = result;
        }

        private void FillOperatorAnalysis(List<ReportModel> values)
        {
            var result = "";

            if (values.Any(x => x.ActionsAmount == 0))
            {
                result += $" - показатели пользователя все еще неэффективны для работы с реальными ситуациями";
            }
            else
            {
                if (values.All(x => x.Successful))
                {
                    if (values.Count > 1)
                    {
                        result += $" - пользователь стабильно прогрессирует";
                    }
                    else
                    {
                        result += $" - пользователь показывает положительные результаты";
                    }
                }
                else
                {
                    if (!values.Any(x => x.Successful))
                    {
                        var success = true;
                        var timeResult = values[0].TimeExecutionAmount;
                        foreach (var item in values)
                        {
                            success = item.TimeExecutionAmount >= timeResult;
                            timeResult = item.TimeExecutionAmount;
                        }

                        if (success)
                        {
                            result += $" - пользователь стабильно прогрессирует, но показатели пользователя все еще неэффективны для работы с реальными ситуациями";
                        }
                        else
                        {
                            result += $" - показатели пользователя все еще неэффективны для работы с реальными ситуациями";
                        }
                    }
                    else
                    {
                        var succesCount = values.Count(x => x.Successful);
                        var notSuccesCount = values.Count(x => !x.Successful);

                        var balance = ((double)notSuccesCount / values.Count) * 100;
                        if (balance < 30)
                        {
                            result += $" - пользователь стабильно прогрессирует";
                        }
                        else
                        {
                            result += $" - показатели пользователя все еще неэффективны для работы с реальными ситуациями";
                        }
                    }                    
                }
            }
            
            txtOperatorAnalysis.Text = result;
        }
    }
}
