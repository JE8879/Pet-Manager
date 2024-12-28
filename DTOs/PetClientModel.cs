using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Manager.DTOs
{
    public class PetClientModel
    {
        private int id;
        private string first_name;

        public int Id { get => id; set => id = value; }
        public string First_name { get => first_name; set => first_name = value; }
    }
}
