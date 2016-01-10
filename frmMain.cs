using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SimpleRepositoryCRUD.Persistence;

namespace SimpleRepositoryCRUD
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEmployee fEmployee = new frmEmployee();
            fEmployee.Employee = EmployeeRepository.GetNewEmployee();
            fEmployee.ShowDialog();
            if (!fEmployee.WasCancelled) {
                EmployeeRepository.AddNewEmployee(fEmployee.Employee.Email, fEmployee.Employee.Phone, fEmployee.Employee.Age);
                RefreshDataGrid();
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (GetSelectedEmployeeID() > 0)
            {
                frmEmployee fEmployee = new frmEmployee();
                fEmployee.Employee = EmployeeRepository.GetAllEmployees()
                                        .Where(emp => emp.EmployeeID == GetSelectedEmployeeID())
                                        .FirstOrDefault();
                fEmployee.ShowDialog();
                if (!fEmployee.WasCancelled)
                {
                    EmployeeRepository.UpdateEmployee(fEmployee.Employee.EmployeeID, fEmployee.Employee.Email, fEmployee.Employee.Phone, fEmployee.Employee.Age);
                    RefreshDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Select an employee first.");
            }

        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (GetSelectedEmployeeID() > 0)
            {
                EmployeeRepository.DeleteEmployee(GetSelectedEmployeeID());
                RefreshDataGrid();
            }
            else {
                MessageBox.Show("Select an employee first.");
            }

        }

        private int GetSelectedEmployeeID() {
            int employeeID = 0;
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvEmployees.SelectedRows[0];
                employeeID = Int32.Parse(row.Cells[0].Value.ToString());
            }
            return employeeID;
        }

        private void RefreshDataGrid()
        {
            dgvEmployees.DataSource = EmployeeRepository.GetAllEmployees();
        }

    }
}
