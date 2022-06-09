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
    public partial class AnalysisDocumentsDiagram : Form
    {
        private List<ScriptMD> _bdScripts = new List<ScriptMD>();
        private List<DocumentMD> _bdDocuments = new List<DocumentMD>();
        private List<AnalysisDocModel> _analysisDocs = new List<AnalysisDocModel>();

        public AnalysisDocumentsDiagram()
        {
            InitializeComponent();
        }

        private void AnalysisDiagram_Load(object sender, EventArgs e)
        {
            _bdScripts = (DataTransfer.GetDataObjects<ScriptMD>(new GetDataFilterScriptMD { AllObjects = true })).ConvertAll(it => (ScriptMD)it);
            _bdDocuments = (DataTransfer.GetDataObjects<DocumentMD>(new GetDataFilterDocumentMD { AllObjects = true })).ConvertAll(it => (DocumentMD)it);

            foreach (var doc in _bdScripts)
            {
                _analysisDocs.Add(new AnalysisDocModel()
                {
                    Id = doc.Id,
                    Name = doc.Name,
                    RecDate = doc.RecDate,
                    ChangeCount = doc.ChangeCount
                });
            }

            foreach (var doc in _bdDocuments)
            {
                _analysisDocs.Add(new AnalysisDocModel()
                {
                    Id = doc.Id,
                    Name = doc.Name,
                    RecDate = doc.RecDate,
                    ChangeCount = doc.ChangeCount
                });
            }

            FillAnalysisDiagram(_analysisDocs);
            FillAnalysisActualDocuments(_analysisDocs); 
        }

        private void FillAnalysisDiagram(List<AnalysisDocModel> documents)
        {
            var maxXValue = documents.Max(x => x.ChangeCount);
            var maxYValue = documents.Max(y => y.RecDate);
            var minXValue = documents.Min(x => x.ChangeCount);
            var minYValue = documents.Min(x => x.RecDate);

            if (documents != null && documents.Any())
            {
                chart1.Series["SeriesLine"].Points.AddXY(0, maxYValue);
                chart1.Series["SeriesLine"].Points.AddXY(maxXValue, minYValue);

                int i = 0;
                foreach (var doc in documents)
                {
                    chart1.Series["SeriesPoints"].Points.AddXY(doc.ChangeCount, doc.RecDate);
                    chart1.Series["SeriesPoints"].Points[i].MarkerStyle = MarkerStyle.Circle;
                    chart1.Series["SeriesPoints"].Points[i].MarkerSize = 8;
                    chart1.Series["SeriesPoints"].Points[i].Label = doc.Name;
                    i++;
                }
            }            
        }

        private void FillAnalysisActualDocuments(List<AnalysisDocModel> documents)
        {
            var lowSortRecDateDocuments = documents.OrderBy(x => x.RecDate).Take(3);
            var highSortRecDateDocuments = documents.OrderByDescending(x => x.RecDate).Take(3);

            var lowSortChangeCountDocuments = documents.OrderBy(x => x.ChangeCount).Take(3);
            var highSortChangeCountDocuments = documents.OrderByDescending(x => x.ChangeCount).Take(3);

            var lowSorts = new List<AnalysisDocModel> { lowSortRecDateDocuments.First(), lowSortChangeCountDocuments.First() };
            var highSorts = new List<AnalysisDocModel> { highSortRecDateDocuments.First(), highSortChangeCountDocuments.First()};

            var lowSortDocuments = (((lowSortRecDateDocuments.Union(lowSortChangeCountDocuments)).Except(highSortRecDateDocuments)).Except(highSortChangeCountDocuments)).Take(3);
            var highSortDocuments = (((highSortRecDateDocuments.Union(highSortChangeCountDocuments)).Except(lowSortRecDateDocuments)).Except(lowSortChangeCountDocuments)).Take(3);

            lowSortDocuments = lowSorts.Union(lowSortDocuments).Take(3);
            highSortDocuments = highSorts.Union(highSortDocuments).Take(3);

            foreach (var document in lowSortDocuments)
            {
                txtLowDocuments.Text += document.Name + Environment.NewLine;
            }

            foreach (var document in highSortDocuments)
            {
                txtBestDocuments.Text += document.Name + Environment.NewLine;
            }
        }
    }
}
