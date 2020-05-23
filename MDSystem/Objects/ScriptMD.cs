using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDSystem.Objects
{
    /// <summary>
    /// Сценарий действия
    /// </summary>
    public class ScriptMD : BaseObject
    {
        /// <summary>
        /// Наименование 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Индивидуальный код 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Дата создания (регистрации) 
        /// </summary>
        public DateTime RegDate { get; set; }

        /// <summary>
        /// Время запуска 
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Описание 
        /// </summary>
        public string Description { get; set; }
    }
}
