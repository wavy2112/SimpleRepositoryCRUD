using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRepositoryCRUD.Domain
{
    public interface IEmployee
    {
        int EmployeeID { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
        int Age { get; set; }
    }
}
