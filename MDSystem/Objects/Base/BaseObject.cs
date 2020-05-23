using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDSystem.Objects
{
    public abstract class BaseObject : IBaseObject
    {
        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Признак удаленной записи
        /// </summary>
        public bool DelRec { get; set; }
    }
}
