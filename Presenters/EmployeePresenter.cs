using System;
using System.Collections.Generic;
using Pet_Manager.Models;
using Pet_Manager.Views;
using System.Windows.Forms;
using Pet_Manager.Presenters.Common;

namespace Pet_Manager.Presenters
{
    public class EmployeePresenter
    {
        private IEmployeeView employeeView;
        private IEmployeeRepository employeeRepository;
        private BindingSource employeeBindingSource;
        private IEnumerable<EmployeeModel> employeeList;

        public EmployeePresenter(IEmployeeView employeeView, IEmployeeRepository employeeRepository)
        {
            this.employeeView = employeeView;
            this.employeeRepository = employeeRepository;
            this.employeeBindingSource = new BindingSource();

            // Subscribe event handler methods to view events
            this.employeeView.SearchEvent += SearchEvent;
            this.employeeView.SaveEvent += SaveEvent;
            this.employeeView.EditEvent += EditEvent;
            this.employeeView.DeleteEvent += DeleteEvent;
            this.employeeView.CancelEvent += CancelEvent;
            this.employeeView.SetEmployeeBindingSource(employeeBindingSource);

            // Load Employees
            LoadAllEmployees();
            // Show View
            this.employeeView.Show();
        }

        private void LoadAllEmployees()
        {
            // Clear the binding source
            employeeBindingSource.Clear();
            // Get all employees from the repository
            employeeList = employeeRepository.GetEmployees();
            // Add the list to the binding source
            employeeBindingSource.DataSource = employeeList;
            // Reset the bindings
            employeeBindingSource.ResetBindings(false);
        }

        private void SearchEvent(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.employeeView.SearchValue);
            if (emptyValue == false)
            {
                employeeList = employeeRepository.GetEmployeeByValue(this.employeeView.SearchValue);
            }
            else
            {
                employeeList = employeeRepository.GetEmployees();
            }
        }

        private void SaveEvent(object sender, EventArgs e)
        {
            // Create a new EmployeeModel object and set its properties
            EmployeeModel employeeModel = new EmployeeModel();
            employeeModel.Id =  this.employeeView.Id;
            employeeModel.First_name = this.employeeView.First_name;
            employeeModel.Last_name = this.employeeView.Last_name;
            employeeModel.Employee_role = this.employeeView.Employee_role;
            employeeModel.Phone = this.employeeView.Phone;
            employeeModel.Email = this.employeeView.Email;
            employeeModel.Active = this.employeeView.Active;

            try
            {                
                // Validate the model
                ValidatorUtility.Validate(employeeModel);
                if(this.employeeView.IsEdit)
                {
                    employeeRepository.Edit(employeeModel);
                    employeeView.Message = "Employee edited successfully";                    
                }
                else
                {
                    employeeRepository.Add(employeeModel);
                    employeeView.Message = "Employee added successfully";                    
                }
                LoadAllEmployees();
                employeeView.IsSuccessfull = true;       
                ClearFields();
            }
            catch (Exception ex)
            {
                employeeView.IsSuccessfull = false;
                employeeView.Message = ex.Message;
            }
        }

        private void EditEvent(object sender, EventArgs e)
        {
            // Get the current employee from the binding source
            EmployeeModel currentEmployee = (EmployeeModel)employeeBindingSource.Current;
            employeeView.Id = currentEmployee.Id;
            employeeView.First_name = currentEmployee.First_name;
            employeeView.Last_name = currentEmployee.Last_name;
            employeeView.Employee_role = currentEmployee.Employee_role;
            employeeView.Phone = currentEmployee.Phone;
            employeeView.Email = currentEmployee.Email;
            employeeView.Active = currentEmployee.Active;
            employeeView.IsEdit = true;
        }

        private void DeleteEvent(object sender, EventArgs e)
        {
            try
            {
                EmployeeModel currentEmployee = (EmployeeModel)employeeBindingSource.Current;
                employeeRepository.Remove(currentEmployee.Id);
                employeeView.Message = "Employee deleted successfully";
                LoadAllEmployees();
            }
            catch (Exception ex)
            {
                employeeView.IsSuccessfull = false;
                employeeView.Message = ex.Message;
            }
        }

        private void CancelEvent(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            employeeView.Id = 0;
            employeeView.First_name = string.Empty;
            employeeView.Last_name = string.Empty;
            employeeView.Employee_role = string.Empty;
            employeeView.Phone = string.Empty;
            employeeView.Email = string.Empty;
            employeeView.Active = string.Empty;
            employeeView.IsEdit = false;
        }
    }
}
