using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDSystem.Objects
{
    /// <summary>
    /// Запись лога
    /// </summary>
    public class Report : BaseObject, ISaveObject
    {        
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
        /// Id пользователя, проводившего тестированиеы
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// ФИО оператора, который проходил этот тест
        /// </summary>
        public string OperatorFullName { get; set; }

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
        /// Комментарии к отчету
        /// </summary>
        public string Description { get; set; }
    }
}
