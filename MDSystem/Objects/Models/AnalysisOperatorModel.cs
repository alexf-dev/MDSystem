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
            string reportCount)
        {
            UserId = userId;
            OperatorName = operatorName;
            ScriptId = scriptId;
            ScriptName = scriptName;
            ReportCount = reportCount;
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
        public string ReportCount { get; set; }
    }
}
