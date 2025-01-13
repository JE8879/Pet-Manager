using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Pet_Manager.Models
{
    public class PetModel
    {
        private int pet_id;
        private int client_id;
        private string pet_name;
        private string species;
        private string gender;
        private DateTime birth_date;
        private float pet_weight;
        private string color;

        // Properties -- Validations
        [DisplayName("Pet ID")]

        public int Pet_id { get => pet_id; set => pet_id = value; }

        [DisplayName("Client ID")]
        [Required(ErrorMessage ="Client ID is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Client ID must be greater than 0")]
        public int Client_id { get => client_id; set => client_id = value; }

        [DisplayName("Pet Name")]
        [Required(ErrorMessage = "Pet Name is Required")]
        public string Pet_name { get => pet_name; set => pet_name = value; }

        [DisplayName("Species")]
        [Required(ErrorMessage = "Species is Required")]
        public string Species { get => species; set => species = value; }

        [DisplayName("Gender")]
        [Required(ErrorMessage = "Gender is Required")]
        public string Gender { get => gender; set => gender = value; }

        [DisplayName("BirthDate")]
        [Required(ErrorMessage = "BirthDate is Required")]
        public DateTime Birth_date { get => birth_date; set => birth_date = value; }

        [DisplayName("Pet Weight")]
        [Required(ErrorMessage = "Pet Weight is Required")]
        [Range(1, float.MaxValue, ErrorMessage = "Pet Weight must be greater than 0")]
        public float Pet_weight { get => pet_weight; set => pet_weight = value; }

        [DisplayName("Color")]
        [Required(ErrorMessage = "Pet Color is Required")]
        public string Color { get => color; set => color = value; }

    }
}
