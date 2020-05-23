using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDSystem.Objects
{
    /// <summary>
    /// Интерфейс базового класса
    /// </summary>
    public interface IBaseObject
    {
        Guid Id { get; set; }
        bool DelRec { get; set; }
    }
}
