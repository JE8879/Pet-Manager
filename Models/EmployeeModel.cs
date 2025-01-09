using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pet_Manager.Models
{
    public class EmployeeModel
    {
        private int id;
        private string first_name;
        private string last_name;
        private string employee_role;
        private string phone;
        private string email;
        private string active;

        // Properties -- Validations
        [DisplayName("Employee ID")]
        public int Id { get => id; set => id = value; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is Required")]
        public string First_name { get => first_name; set => first_name = value; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is Required")]
        public string Last_name { get => last_name; set => last_name = value; }

        [DisplayName("Employee Role")]
        [Required(ErrorMessage = "Employee Role is Required")]
        public string Employee_role { get => employee_role; set => employee_role = value; }

        [DisplayName("Phone")]
        [Required(ErrorMessage = "Phone is Required")]
        public string Phone { get => phone; set => phone = value; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get => email; set => email = value; }

        [DisplayName("Active")]
        [Required(ErrorMessage = "Active is Required")]
        public string Active { get => active; set => active = value; }
    }
}
