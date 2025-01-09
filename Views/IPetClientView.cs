using System;
using System.Windows.Forms;

namespace Pet_Manager.Views
{
    public interface IPetClientView
    {
        // Properties
        int Id { get; set; }
        string FirstName { get; set; }
        string SearchValue { get; set; }

        // Events
        event EventHandler CloseForm;
        event EventHandler RowSelected;
        event EventHandler SearchEvent;

        // Methods
        void SetPetClientBindingSource(BindingSource petClientList);
        void Show();
        void Close();
    }
}
