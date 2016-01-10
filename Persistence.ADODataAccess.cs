using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

using SimpleRepositoryCRUD.Domain;

namespace SimpleRepositoryCRUD.Persistence
{
    class ADODataAccess
    {
        private static string CONN_STRING = "Data Source=localhost;Initial Catalog=AT_Employees;Integrated Security=True";
        private IEmployeeFactory _emloyeeFactory;

        private ADODataAccess() { }

        public ADODataAccess(IEmployeeFactory employeeFactory)
        {
            this._emloyeeFactory = employeeFactory;
        }

        public List<IEmployee> GetAllEmployees() {
            List<IEmployee> employeeList = new List<IEmployee>();

            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("select EmployeeID, Phone, Email, Age from Employees");

            using (SqlConnection conn = new SqlConnection(CONN_STRING)) {
                using (SqlCommand cmd = new SqlCommand(sbQuery.ToString(), conn)) {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            IEmployee employee = _emloyeeFactory.CreateNewEmployee();
                            employee.EmployeeID = reader.GetInt32(0);
                            employee.Phone = reader.GetString(1);
                            employee.Email = reader.GetString(2);
                            employee.Age = reader.GetInt32(3);
                            employeeList.Add(employee);
                        }
                    }
                }
            }

            return employeeList;
        }

        public void AddEmployee(string email, string phone, int age) {
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("insert into Employees (Email, Phone, Age) values (@email, @phone, @age)");

            using (SqlConnection conn = new SqlConnection(CONN_STRING)){
                using (SqlCommand cmd = new SqlCommand(sbQuery.ToString(), conn)) {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@age", age);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateEmployee(int employeeID, string email, string phone, int age)
        {
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("update Employees set Email=@email, Phone=@phone, Age=@age where EmployeeID=@employeeID");

            using (SqlConnection conn = new SqlConnection(CONN_STRING))
            {
                using (SqlCommand cmd = new SqlCommand(sbQuery.ToString(), conn))
                {
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@age", age);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEmployee(int employeeID) {
            StringBuilder sbQuery = new StringBuilder();
            sbQuery.Append("delete from Employees where EmployeeID=@employeeID");

            using (SqlConnection conn = new SqlConnection(CONN_STRING)) {
                using (SqlCommand cmd = new SqlCommand(sbQuery.ToString(), conn)) {
                    cmd.Parameters.AddWithValue("@employeeID", employeeID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }


    }
}
