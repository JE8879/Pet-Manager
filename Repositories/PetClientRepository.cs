using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Pet_Manager.DTOs;


namespace Pet_Manager.Repositories
{
    public class PetClientRepository : BaseRepository, IPetClientRepository
    {
        public PetClientRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<PetClientModel> GetAll()
        {
            var petClientList = new List<PetClientModel>();
            using(var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Client";
                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var petClientModel = new PetClientModel();
                        petClientModel.Id = (int)reader[0];
                        petClientModel.First_name = (string)reader[1];
                        petClientList.Add(petClientModel);
                    }
                }
            }
            return petClientList;
        }

        public IEnumerable<PetClientModel> SelectByValue(string value)
        {
            var clientList = new List<PetClientModel>();
            int clientId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string clientName = value;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Client WHERE client_id=@client_id OR first_name like @name+'%' ORDER BY client_id DESC";
                command.Parameters.Add("@client_id", SqlDbType.Int).Value = clientId;
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = clientName;

                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        var petClientModel = new PetClientModel();
                        petClientModel.Id = (int)reader[0];
                        petClientModel.First_name = (string)reader[1];
                        clientList.Add(petClientModel);
                    }
                }
            }
            return clientList;
        }
    }
}
