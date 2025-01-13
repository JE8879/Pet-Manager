using System;
using System.Windows.Forms;

namespace Pet_Manager.Views
{
    public interface IPetView
    {
        // Properties
        int pet_id { get; set; }
        int client_id { get; set; }
        string pet_name { get; set; }
        string species { get; set; }
        string geneder { get; set; }
        DateTime birth_date { get; set; }
        float pet_weight { get; set; }          
        string color { get; set; }

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
        event EventHandler OpenClientEvent;
        event EventHandler CloseEvent;

        // Methods
        void SetPetBindingSource(BindingSource petList);
        void Show();
        void Close();

    }
}
