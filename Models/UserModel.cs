using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Manager.Models
{
    public class UserModel
    {
        private int id;
        private string username;
        private byte[] passwordHash;
        private byte[] passwordSalt;
        private int employee_id;

        // Properties and Validations
        [DisplayName("User ID")]
        public int Id { get => id; set => id = value; }

        [DisplayName("Username")]
        [Required(ErrorMessage = "Username is Required")]
        public string Username { get => username; set => username = value; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is Required")]
        public byte[] PasswordHash { get => passwordHash; set => passwordHash = value; }
        
        [DisplayName("Password Salt")]
        [Required]
        public byte[] PasswordSalt { get => passwordSalt; set => passwordSalt = value; }

        [DisplayName("Employee ID")]
        [Required(ErrorMessage = "Employee ID is Required")]
        public int Employee_id { get => employee_id; set => employee_id = value; }
    }
}
