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
        private static User admin = new User { UserName = "Admin", Password = "root", AccessLevelValue = 3 };
        public static bool IsAuthorizedUser { get; set; }
        public static User Admin { get { return admin; } }
        public static User CurrentUser { get; set; }

        public static List<Workplace> Workplaces = new List<Workplace>()
        {
            new Workplace{ Id = new Guid("10000000-1000-1000-1000-100000000001"), Name = "Космонавт", DelRec = false, ParentId = Guid.Empty},
            new Workplace{ Id = new Guid("10000000-1000-1000-1000-100000000002"), Name = "Испытатель", DelRec = false, ParentId = Guid.Empty},
            new Workplace{ Id = new Guid("10000000-1000-1000-1000-100000000003"), Name = "Эксперт", DelRec = false, ParentId = Guid.Empty},
            new Workplace{ Id = new Guid("10000000-1000-1000-1000-100000000004"), Name = "Аналитик", DelRec = false, ParentId = Guid.Empty},
            new Workplace{ Id = new Guid("10000000-1000-1000-1000-100000000005"), Name = "Конструктор", DelRec = false, ParentId = Guid.Empty},
            new Workplace{ Id = new Guid("10000000-1000-1000-1000-100000000006"), Name = "Инженер", DelRec = false, ParentId = Guid.Empty},
            new Workplace{ Id = new Guid("10000000-1000-1000-1000-100000000007"), Name = "Разработчик", DelRec = false, ParentId = Guid.Empty}

        };

        public static List<Department> Departments = new List<Department>()
        {
            new Department{ Id = new Guid("10000000-1000-1000-1000-200000000001"), Name = "Отдел тестирования", DelRec = false, ParentId = Guid.Empty},
            new Department{ Id = new Guid("10000000-1000-1000-1000-200000000002"), Name = "Отдел разработки", DelRec = false, ParentId = Guid.Empty},
            new Department{ Id = new Guid("10000000-1000-1000-1000-200000000003"), Name = "Отдел подготовки космонавтов", DelRec = false, ParentId = Guid.Empty},
            new Department{ Id = new Guid("10000000-1000-1000-1000-200000000004"), Name = "Отдел аналитики", DelRec = false, ParentId = Guid.Empty},
            new Department{ Id = new Guid("10000000-1000-1000-1000-200000000005"), Name = "Отдел конструирования", DelRec = false, ParentId = Guid.Empty},

        };

        public static List<AccessLevel> AcessLevels = new List<AccessLevel>()
        {
            new AccessLevel { Value = 1, Name = "Выполнение тестов" },
            new AccessLevel { Value = 2, Name = "Выполнение тестов и вывод отчётов" },
            new AccessLevel { Value = 3, Name = "Администратор" }
        };
    }
}
