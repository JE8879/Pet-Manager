using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pet_Manager.Views.Form_Helps
{
    public interface IEmployeeUserView
    {
        // Properties
        int Id { get; set; }
        string First_name { get; set; }

        // Events
        event EventHandler GetSelectedRow;
        event EventHandler CancelEvent;

        // Methods
        void SetEmployeeUserBindingSource(BindingSource employeeUserList);
        void Show();
        void Close();
    }
}
