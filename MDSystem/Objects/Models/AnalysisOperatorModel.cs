using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDSystem.Objects.Models
{
    public class AnalysisOperatorModel
    {
        public AnalysisOperatorModel(
            Guid userId,
            string operatorName,
            Guid scriptId,
            string scriptName,
            int reportCount,
            int successfulReports,
            int notSuccessfulReports,
            int zeroActionsAmountReports)
        {
            UserId = userId;
            OperatorName = operatorName;
            ScriptId = scriptId;
            ScriptName = scriptName;
            ReportCount = reportCount;
            SuccessfulReports = successfulReports;
            NotSuccessfulReports = notSuccessfulReports;
            ZeroActionsAmountReports = zeroActionsAmountReports;
        }

        /// <summary>
        /// Оператор
        /// </summary>
        public Guid UserId { get; set; }

        public string OperatorName { get; set; }

        /// <summary>
        /// Сценарий
        /// </summary>
        public Guid ScriptId { get; set; }

        public string ScriptName { get; set; }

        /// <summary>
        /// Оператор
        /// </summary>
        public int ReportCount { get; set; }

        public int SuccessfulReports { get; set; }

        public int NotSuccessfulReports { get; set; }

        public int ZeroActionsAmountReports { get; set; }
    }
}
