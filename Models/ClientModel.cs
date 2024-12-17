using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pet_Manager.Models
{
    public class ClientModel
    {
        // Fields
        private int id;
        private string first_name;
        private string last_name;
        private string phone;
        private string email;
        private string client_address;
        private DateTime registration_date;

        // Properties -- Validations
        [DisplayName("Client ID")]
        public int Id { get => id; set => id = value; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is Required")]
        public string First_name { get => first_name; set => first_name = value; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is Required")]
        public string Last_name { get => last_name; set => last_name = value; }

        [DisplayName("Phone")]
        [Required(ErrorMessage = "Phone is Required")]
        public string Phone { get => phone; set => phone = value; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get => email; set => email = value; }

        [DisplayName("Address")]
        [Required(ErrorMessage = "Address is Required")]
        public string Client_address { get => client_address; set => client_address = value; }

        [DisplayName("Registratio Date")]
        [Required(ErrorMessage = "Registration date is Required")]
        public DateTime Registration_date { get => registration_date; set => registration_date = value; }
    }
}
