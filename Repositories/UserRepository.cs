using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Pet_Manager.Models;

namespace Pet_Manager.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void CreateUser(UserModel userModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO UserLogin VALUES(@username,@password_hash,@password_salt,@employee_id)";
                command.Parameters.Add("@username", SqlDbType.VarChar).Value = userModel.Username;
                command.Parameters.Add("@password_hash", SqlDbType.VarBinary).Value = userModel.PasswordHash;
                command.Parameters.Add("@password_salt", SqlDbType.VarBinary).Value = userModel.PasswordSalt;
                command.Parameters.Add("@employee_id", SqlDbType.Int).Value = userModel.Employee_id;
                command.ExecuteNonQuery();
            }
        }

        public void UpdateUser(UserModel userModel)
        {
           throw new NotImplementedException();
        }

        public void DeleteUser(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetUsers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetUsersByValue(string value)
        {
            throw new NotImplementedException();
        }

        
    }
}
