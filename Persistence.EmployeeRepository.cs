using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleRepositoryCRUD.Domain;

namespace SimpleRepositoryCRUD.Persistence
{
    static class EmployeeRepository
    {
        private class EmployeeFactory : IEmployeeFactory
        {
            public IEmployee CreateNewEmployee()
            {
                return new Employee();
            }
        }

        public static IEmployee GetNewEmployee() {
            EmployeeFactory employeeFactory = new EmployeeFactory();
            return employeeFactory.CreateNewEmployee();
        }

        public static List<IEmployee> GetAllEmployees() {
            ADODataAccess dataAccess = new ADODataAccess(new EmployeeFactory());
            return dataAccess.GetAllEmployees();
        }

        public static void AddNewEmployee(string email, string phone, int age) {
            ADODataAccess dataAccess = new ADODataAccess(new EmployeeFactory());
            dataAccess.AddEmployee(email, phone, age);
        }

        public static void UpdateEmployee(int employeeID, string email, string phone, int age)
        {
            ADODataAccess dataAccess = new ADODataAccess(new EmployeeFactory());
            dataAccess.UpdateEmployee(employeeID, email, phone, age);
        }

        public static void DeleteEmployee(int employeeID){
            ADODataAccess dataAccess = new ADODataAccess(new EmployeeFactory());
            dataAccess.DeleteEmployee(employeeID);
        }
    }
}
