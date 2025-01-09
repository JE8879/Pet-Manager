using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pet_Manager.Models;
using Pet_Manager.Views;
using Pet_Manager.Views.Form_Helps;

namespace Pet_Manager.Presenters
{
    public class EmployeeUserPresenter
    {
        // Fields
        private readonly IEmployeeUserView employeeUserView;
        private readonly IEmployeeRepository employeeRepository;
        private readonly BindingSource employeeBindingSource;
        private IEnumerable<dynamic> employees;

        public EmployeeUserPresenter(IEmployeeUserView employeeUserView, IEmployeeRepository employeeRepository)
        {
            this.employeeUserView = employeeUserView;
            this.employeeRepository = employeeRepository;
            employeeBindingSource = new BindingSource();

            // Subscribe event handler methods to view events
            this.employeeUserView.GetSelectedRow += GetSelectedRow;
            this.employeeUserView.CancelEvent += CloseForm;
            this.employeeUserView.SetEmployeeUserBindingSource(employeeBindingSource);

            // Load Employees
            LoadAllEmployees();
        }

        private void GetSelectedRow(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LoadAllEmployees()
        {
            employees = employeeRepository.GetBasicEmployeeInfo();
            employeeBindingSource.DataSource = employees;
        }

        private void CloseForm(object sender, EventArgs e)
        {
            this.employeeUserView.Close();
        }
    }
}
