using System;

namespace MDSystem.Objects
{
    /// <summary>
    /// Действие системы
    /// </summary>
    public class ActionMD : BaseObject
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Номер действия
        /// </summary>
        public int OrderValue { get; set; }

        /// <summary>
        /// Среднее время фиксации
        /// </summary>
        public TimeSpan TimeExecution { get; set; }

        /// <summary>
        /// Дополнительная информация
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Тип действия
        /// </summary>
        public ActionMDType ActionType { get; set; }
    }
}
