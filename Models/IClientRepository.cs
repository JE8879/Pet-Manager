using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Manager.Models
{
    public interface IClientRepository
    {
        void Add(ClientModel clientModel);
        void Edit(ClientModel clientModel);
        void Delete(int  id);
        IEnumerable<ClientModel> GetAll();
        IEnumerable<ClientModel> GetByValue(string value);
    }
}
