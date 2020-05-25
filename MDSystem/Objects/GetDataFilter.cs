using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDSystem.Objects
{
    /// <summary>
    /// Параметры получения данных
    /// </summary>
    public class GetDataFilter
    {
        public Guid? Id { get; set; }
        public List<Guid> Ids { get; set; }
        public Guid? ParentId { get; set; }
        public List<Guid> ParentIds { get; set; }
        public string Name { get; set; }

        public GetDataFilter()
        {
            Id = null;
            Ids = null;
            ParentId = null;
            ParentIds = null;
            Name = null;
        }
    }
}
