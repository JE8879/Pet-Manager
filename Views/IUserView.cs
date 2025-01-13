using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pet_Manager.Views
{
    public interface IUserView
    {
        // Properties
        int User_id { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        byte[] PasswordSalt { get; set; }
        int Employee_id { get; set; }

        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessfull { get; set; }
        string Message { get; set; }

        // Events
        event EventHandler SearchEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler OpenEmployee;

        // Methods
        void Show();
    }
}
