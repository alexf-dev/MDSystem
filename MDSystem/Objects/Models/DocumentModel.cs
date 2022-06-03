using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDSystem.Objects.Models
{
    public class DocumentModel
    {
        public DocumentModel(Guid id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        public Guid Id { get; set; }

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
