using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDSystem.Objects
{
    public class DocumentMD : BaseObject, ISaveObject
    {
        /// <summary>
        /// Идентификатор родительского объекта
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// Наименовние документа
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Содержание документа
        /// </summary>
        public string Description { get; set; }
    }
}
