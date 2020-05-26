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
    public class Department : BaseObject, ISaveObject
    {
        /// <summary>
        /// Идентификатор родительского объекта (вышестоящее подразделение)
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// Наименование 
        /// </summary>
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
