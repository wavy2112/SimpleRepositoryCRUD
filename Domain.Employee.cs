using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRepositoryCRUD.Domain
{
    class Employee : IEmployee
    {
        public int Age
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public int EmployeeID
        {
            get; set;
        }

        public string Phone
        {
            get; set;
        }
    }
}
