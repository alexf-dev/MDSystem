using MDSystem.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDSystem.Data
{
    public static class ApplicationData
    {
        public static List<Workplace> Workplaces = new List<Workplace>()
        {
            new Workplace{ Id = new Guid("10000000-1000-1000-1000-100000000001"), Name = "Космонавт", AccessLevel = AccessLevel.all_level, DelRec = false, ParentId = Guid.Empty},
            new Workplace{ Id = new Guid("10000000-1000-1000-1000-100000000002"), Name = "Испытатель", AccessLevel = AccessLevel.all_level, DelRec = false, ParentId = Guid.Empty},
            new Workplace{ Id = new Guid("10000000-1000-1000-1000-100000000003"), Name = "Эксперт", AccessLevel = AccessLevel.all_level, DelRec = false, ParentId = Guid.Empty},
            new Workplace{ Id = new Guid("10000000-1000-1000-1000-100000000004"), Name = "Аналитик", AccessLevel = AccessLevel.all_level, DelRec = false, ParentId = Guid.Empty},
            new Workplace{ Id = new Guid("10000000-1000-1000-1000-100000000005"), Name = "Конструктор", AccessLevel = AccessLevel.all_level, DelRec = false, ParentId = Guid.Empty},
            new Workplace{ Id = new Guid("10000000-1000-1000-1000-100000000006"), Name = "Инженер", AccessLevel = AccessLevel.all_level, DelRec = false, ParentId = Guid.Empty},
            new Workplace{ Id = new Guid("10000000-1000-1000-1000-100000000007"), Name = "Разработчик", AccessLevel = AccessLevel.all_level, DelRec = false, ParentId = Guid.Empty}

        };

        public static List<Department> Departments = new List<Department>()
        {
            new Department{ Id = new Guid("10000000-1000-1000-1000-200000000001"), Name = "Отдел тестирования", DelRec = false, ParentId = Guid.Empty},
            new Department{ Id = new Guid("10000000-1000-1000-1000-200000000002"), Name = "Отдел разработки", DelRec = false, ParentId = Guid.Empty},
            new Department{ Id = new Guid("10000000-1000-1000-1000-200000000003"), Name = "Отдел подготовки космонавтов", DelRec = false, ParentId = Guid.Empty},
            new Department{ Id = new Guid("10000000-1000-1000-1000-200000000004"), Name = "Отдел аналитики", DelRec = false, ParentId = Guid.Empty},
            new Department{ Id = new Guid("10000000-1000-1000-1000-200000000005"), Name = "Отдел конструирования", DelRec = false, ParentId = Guid.Empty},

        };


    }
}
