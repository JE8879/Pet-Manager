using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Manager.DTOs
{
    public interface IPetClientRepository
    {
        IEnumerable<PetClientModel> GetAll();
        IEnumerable<PetClientModel> SelectByValue(string value);
    }
}
