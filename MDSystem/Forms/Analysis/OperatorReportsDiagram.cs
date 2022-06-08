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
                        it.ActionsOrderList))
                    .ToList();
            }

            FillReportsDiagram(_bdReportModels);
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

                int i = 0;
                foreach (var item in _bdReportModels)
                {
                    chart1.Series["Series1"].Points.AddXY(item.StartDate.ToShortDateString(), item.TimeExecutionAmount.TotalMinutes);
                    i++;
                }
            }            
        }
    }
}
