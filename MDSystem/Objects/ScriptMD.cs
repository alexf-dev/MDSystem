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
    public class ScriptMD : BaseObject, ISaveObject
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
        /// Описание 
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Тип сценария
        /// </summary>
        public ScriptMDType ScriptType { get; set; }

        /// <summary>
        /// Список действий
        /// </summary>
        public List<ActionMD> Actions { get; set; }

        /// <summary>
        /// Порядок выполненных действий
        /// </summary>
        public int[] ActionsOrderList { get; set; }       

        public int ChangeCount { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
