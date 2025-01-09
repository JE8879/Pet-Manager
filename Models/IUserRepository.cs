using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Manager.Models
{
    public interface IUserRepository
    {
        void CreateUser(UserModel userModel);
        void UpdateUser(UserModel userModel);
        void DeleteUser(int Id);
        IEnumerable<UserModel> GetUsers();
        IEnumerable<UserModel> GetUsersByValue(string value);
    }
}
