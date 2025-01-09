using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Pet_Manager.Models;

namespace Pet_Manager.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        // Fields
        private List<EmployeeModel> employeeList = new List<EmployeeModel>();

        public EmployeeRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(EmployeeModel employee)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO Employee VALUES(@first_name,@last_name,@employee_role,@phone,@email,@active)";
                command.Parameters.Add("@first_name", SqlDbType.VarChar).Value = employee.First_name;
                command.Parameters.Add("@last_name", SqlDbType.VarChar).Value = employee.Last_name;
                command.Parameters.Add("@employee_role", SqlDbType.VarChar).Value = employee.Employee_role;
                command.Parameters.Add("@phone", SqlDbType.VarChar).Value = employee.Phone;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = employee.Email;
                command.Parameters.Add("@active", SqlDbType.VarChar).Value = employee.Active;
                command.ExecuteNonQuery();
            }
        }

        public void Edit(EmployeeModel employee)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE Employee SET first_name=@first_name, last_name=@last_name, employee_role=@employee_role, phone=@phone, email=@email, active=@active WHERE employee_id=@employee_id";
                command.Parameters.Add("@first_name", SqlDbType.VarChar).Value = employee.First_name;
                command.Parameters.Add("@last_name", SqlDbType.VarChar).Value = employee.Last_name;
                command.Parameters.Add("@employee_role", SqlDbType.VarChar).Value = employee.Employee_role;
                command.Parameters.Add("@phone", SqlDbType.VarChar).Value = employee.Phone;
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = employee.Email;
                command.Parameters.Add("@active", SqlDbType.VarChar).Value = employee.Active;
                command.Parameters.Add("@employee_id", SqlDbType.Int).Value = employee.Id;
                command.ExecuteNonQuery();
            }
        }

        public void Remove(int Id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM Employee WHERE employee_id=@employee_id";
                command.Parameters.Add("@employee_id", SqlDbType.Int).Value = Id;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<EmployeeModel> GetEmployees()
        {

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Employee";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var employee = new EmployeeModel();
                        employee.Id = (int)reader[0];
                        employee.First_name = (string)reader[1];
                        employee.Last_name = (string)reader[2];
                        employee.Employee_role = (string)reader[3];
                        employee.Phone = (string)reader[4];
                        employee.Email = (string)reader[5];
                        employee.Active = (string)reader[6];
                        employeeList.Add(employee);
                    }
                }
                return employeeList;
            }
        }

        public IEnumerable<EmployeeModel> GetEmployeeByValue(string searchValue)
        {
            var employeeList = new List<EmployeeModel>();
            int employeeId = int.TryParse(searchValue, out _) ? int.Parse(searchValue) : 0;
            string employeeName = searchValue;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Employee WHERE employee_id=@employee_id OR employee_name LIKE @name+'%' ORDER BY employee_id DESC";
                command.Parameters.Add("@employee_id", SqlDbType.Int).Value = employeeId;
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = employeeName;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var employeeModel = new EmployeeModel();
                        employeeModel.Id = (int)reader[0];
                        employeeModel.First_name = (string)reader[1];
                        employeeModel.Last_name = (string)reader[2];
                        employeeModel.Employee_role = (string)reader[3];
                        employeeModel.Phone = (string)reader[4];
                        employeeModel.Email = (string)reader[5];
                        employeeModel.Active = (string)reader[6];
                        employeeList.Add(employeeModel);
                    }
                }
            }
            return employeeList;
        }

        public IEnumerable<dynamic> GetBasicEmployeeInfo()
        {
            var getEmployees = GetEmployees();
            var basicEmployeeInfo = from employee in getEmployees
                                    select new
                                    {
                                        employee.Id,
                                        employee.First_name,
                                    };
            return basicEmployeeInfo;
        }
    }
}
