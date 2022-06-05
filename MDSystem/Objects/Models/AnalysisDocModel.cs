using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDSystem.Objects.Models
{
    public class AnalysisDocModel
    {
        /// <summary>
        /// Идентификатор объекта
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Наименование 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата изменения записи в БД
        /// </summary>
        public DateTime RecDate { get; set; }

        public int ChangeCount { get; set; }
    }
}
