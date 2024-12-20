using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Pet_Manager.Models;

namespace Pet_Manager.Repositories
{
    public class PetRepository : BaseRepository, IPetRepository
    {
        public PetRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(PetModel petModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.CommandText = "INSERT INTO Pet VALUES(@client_id,@pet_name,@species,@gender,@birth_date,@pet_weight,@color)";
                command.Parameters.Add("@client_id", SqlDbType.Int);
                command.Parameters.Add("@pet_name", SqlDbType.VarChar);
                command.Parameters.Add("@species", SqlDbType.VarChar);
                command.Parameters.Add("@gender", SqlDbType.VarChar);
                command.Parameters.Add("@birth_date", SqlDbType.Date);
                command.Parameters.Add("@pet_weight", SqlDbType.Float);
                command.Parameters.Add("@color", SqlDbType.VarChar);
                command.ExecuteNonQuery();
            }
        }

        public void Edit(PetModel petModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.CommandText = "UPDATE Pet SET client_id=@client_id,pet_name=@pet_name,species=@species,gender=@gender,birth_date=@birth_date,pet_weight=@pet_weight,color=@color WHERE pet_id=@pet_id";
                command.Parameters.Add("@client_id", SqlDbType.Int);
                command.Parameters.Add("@pet_name", SqlDbType.VarChar);
                command.Parameters.Add("@species", SqlDbType.VarChar);
                command.Parameters.Add("@gender", SqlDbType.VarChar);
                command.Parameters.Add("@birth_date", SqlDbType.Date);
                command.Parameters.Add("@pet_weight", SqlDbType.Float);
                command.Parameters.Add("@color", SqlDbType.VarChar);
                command.Parameters.Add("@pet_id",SqlDbType.Int);
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
                command.CommandText = "DELETE FROM Pet WHERE pet_id=@pet_id";
                command.Parameters.Add("@pet_id", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<PetModel> GetAll()
        {
            var petList = new List<PetModel>();
            using(var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Pet ORDER BY pet_id";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var petModel = new PetModel();
                        petModel.Pet_id = (int)reader[0];
                        petModel.Client_id = (int)reader[1];
                        petModel.Pet_name = (string)reader[2];
                        petModel.Species = (string)reader[3];
                        petModel.Gender = (string)reader[4];
                        petModel.Birth_date = (DateTime)reader[5];
                        petModel.Pet_weight = (float)reader[6];
                        petModel.Color = (string)reader[7];
                        petList.Add(petModel);
                    }
                }
            }
            return petList;
        }

        public IEnumerable<PetModel> GetByValue(string value)
        {
            var petList = new List<PetModel> ();
            int petId = int.TryParse (value, out _) ? Convert.ToInt32(value) : 0;
            string petName = value;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Pet WHERE pet_id=@pet_id OR pet_name like @name+'%' ORDER BY pet_id DESC";

                command.Parameters.Add("@pet_id", SqlDbType.Int).Value = petId;
                command.Parameters.Add("@name", SqlDbType.VarChar).Value  = petName;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var petModel = new PetModel();
                        petModel.Pet_id = (int)reader[0];
                        petModel.Client_id = (int)reader[1];
                        petModel.Pet_name = (string)reader[2];
                        petModel.Species = (string)reader[3];
                        petModel.Gender = (string)reader[4];
                        petModel.Birth_date = (DateTime)reader[5];
                        petModel.Pet_weight = (float)reader[6];
                        petModel.Color = (string)reader[7];
                        petList.Add(petModel);
                    }
                }
            }
            return petList;
        }
    }
}
