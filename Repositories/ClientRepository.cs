using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Pet_Manager.Models;


namespace Pet_Manager.Repositories
{
    public class ClientRepository : BaseRepository, IClientRepository
    {
        public ClientRepository(string connectionString) 
        {
            this.connectionString = connectionString;
        }

        public void Add(ClientModel clientModel)
        {
            using (var connection  = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO Client VALUES(@first_name,@last_name,@phone,@email,@client_address,@registration_date)";
                command.Parameters.Add("@first_name", SqlDbType.VarChar).Value = clientModel.First_name;
                command.Parameters.Add("@last_name", SqlDbType.VarChar).Value = clientModel.Last_name;
                command.Parameters.Add("@phone", SqlDbType.VarChar).Value = clientModel.Phone;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = clientModel.Email;
                command.Parameters.Add("@client_address", SqlDbType.VarChar).Value = clientModel.Client_address;
                command.Parameters.Add("@registration_date", SqlDbType.Date).Value = clientModel.Registration_date;
                command.ExecuteNonQuery();
            }
        }

        public void Edit(ClientModel clientModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE Client SET first_name=@first_name, last_name=@last_name, phone=@phone, email=@email,client_address=@client_address,registration_date=@registration_date WHERE client_id=@client_id";
                command.Parameters.Add("@first_name", SqlDbType.VarChar).Value = clientModel.First_name;
                command.Parameters.Add("@last_name", SqlDbType.VarChar).Value = clientModel.Last_name;
                command.Parameters.Add("@phone", SqlDbType.VarChar).Value = clientModel.Phone;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = clientModel.Email;
                command.Parameters.Add("@client_address", SqlDbType.VarChar).Value = clientModel.Client_address;
                command.Parameters.Add("@registration_date", SqlDbType.Date).Value = clientModel.Registration_date;
                command.Parameters.Add("@client_id", SqlDbType.Int).Value = clientModel.Id;
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using(var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM Client WHERE client_id=@client_id";
                command.Parameters.Add("@client_id",SqlDbType.Int).Value=id;
                command.ExecuteNonQuery ();
            }
        }
        
        public IEnumerable<ClientModel> GetAll()
        {
            var clientList = new List<ClientModel>();
            using(var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Client ORDER BY client_id";
                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var clientModel = new ClientModel();
                        clientModel.Id = (int)reader[0];
                        clientModel.First_name = (string)reader[1];
                        clientModel.Last_name = (string)reader[2];
                        clientModel.Phone = (string)reader[3];
                        clientModel.Email = (string)reader[4];
                        clientModel.Client_address = (string)reader[5];
                        clientModel.Registration_date = (DateTime)reader[6];
                        clientList.Add(clientModel);
                    }
                }
            }
            return clientList;
        }

        public IEnumerable<ClientModel> GetByValue(string value)
        {
            var clientList = new List<ClientModel>();
            int clientId = int.TryParse(value, out _) ? Convert.ToInt32(value): 0;
            string clientName = value;

            using(var connection = new SqlConnection(connectionString))
            using(var command = new SqlCommand())
            {             
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Client Where client_id=@client_id or first_name like @name+'%' ORDER BY client_id DESC";
                
                command.Parameters.Add("@client_id", SqlDbType.Int).Value = clientId;
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = clientName;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var clientModel = new ClientModel();
                        clientModel.Id = (int)reader[0];
                        clientModel.First_name = (string)reader[1];
                        clientModel.Last_name = (string)reader[2];
                        clientModel.Phone = (string)reader[3];
                        clientModel.Email = (string)reader[4];
                        clientModel.Client_address = (string)reader[5];
                        clientModel.Registration_date = (DateTime)reader[6];
                        clientList.Add(clientModel);
                    }
                }
            }
            return clientList;
        }
    }
}
