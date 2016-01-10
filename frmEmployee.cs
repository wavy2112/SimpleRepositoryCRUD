using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SimpleRepositoryCRUD.Domain;

namespace SimpleRepositoryCRUD
{
    public partial class frmEmployee : Form
    {
        public IEmployee Employee { get; set; }

        public bool WasCancelled { get; private set; }

        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            WasCancelled = false;
            if (this.Employee != null){
                lblEmployeeID.Text = "Employee ID: " + Employee.EmployeeID;
                txtEmail.Text = Employee.Email;
                txtPhone.Text = Employee.Phone;
                txtAge.Text = Employee.Age.ToString();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            WasCancelled = false;
            Employee.Email = txtEmail.Text;
            Employee.Phone = txtPhone.Text;
            Employee.Age = Int32.Parse(txtAge.Text);
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            WasCancelled = true;
            this.Hide();
        }
    }
}
