using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Manager.Models
{
    public interface IEmployeeRepository
    {
        void Add(EmployeeModel employee);
        void Edit(EmployeeModel employee);
        void Remove(int Id);
        IEnumerable<EmployeeModel> GetEmployees();
        IEnumerable<EmployeeModel> GetEmployeeByValue(string searchValue);
        IEnumerable<dynamic> GetBasicEmployeeInfo();
    }
}
