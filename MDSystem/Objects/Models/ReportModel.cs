using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDSystem.Objects.Models
{
    public class ReportModel
    {
        public ReportModel(
            DateTime startDate,
            Guid scriptId,
            string scriptName,
            Guid operatorID,
            int actionsAmount,
            TimeSpan timeExecutionAmount,
            bool succesful,
            int[] actionsOrderList
            )
        {
            StartDate = startDate;
            ScriptId = scriptId;
            ScriptName = scriptName;
            OperatorID = operatorID;
            ActionsAmount = actionsAmount;
            TimeExecutionAmount = timeExecutionAmount;
            Successful = succesful;
            ActionsOrderList = actionsOrderList;
        }

        /// <summary>
        /// Время запуска 
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Id сценария
        /// </summary>
        public Guid ScriptId { get; set; }

        /// <summary>
        /// Наименование сценария
        /// </summary>
        public string ScriptName { get; set; }

        /// <summary>
        /// Id оператора, который проходил этот тест
        /// </summary>
        public Guid OperatorID { get; set; }

        /// <summary>
        /// количество выполненных оператором действий
        /// </summary>
        public int ActionsAmount { get; set; }

        /// <summary>
        /// Суммарное время выполнения действий
        /// </summary>
        public TimeSpan TimeExecutionAmount { get; set; }

        /// <summary>
        /// Список действий
        /// </summary>
        public List<ActionMD> Actions { get; set; }

        /// <summary>
        /// Порядок выполненных действий
        /// </summary>
        public int[] ActionsOrderList { get; set; }

        /// <summary>
        /// Успешное/неуспешное прохождение теста
        /// </summary>
        public bool Successful { get; set; }
    }
}
