using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDSystem.Objects
{
    /// <summary>
    /// Подразделение
    /// </summary>
    public class Department : BaseObject
    {
        /// <summary>
        /// Идентификатор родительского объекта (вышестоящее подразделение)
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// Наименование 
        /// </summary>
        public string Name { get; set; }
    }
}
