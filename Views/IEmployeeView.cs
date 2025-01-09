using System;
using System.Windows.Forms;

namespace Pet_Manager.Views
{
    public interface IEmployeeView
    {
        // Properties
        int Id { get; set; }
        string First_name { get; set; }
        string Last_name { get; set; }
        string Employee_role { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
        string Active { get; set; }

        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessfull { get; set; }
        string Message { get; set; }

        // Events
        event EventHandler SearchEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        // Methods
        void SetEmployeeBindingSource(BindingSource employeeList);
        void Show();



    }
}
