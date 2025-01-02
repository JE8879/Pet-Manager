using System;
using System.Windows.Forms;

namespace Pet_Manager.Views
{
    public interface IPetClientView
    {
        // Properties
        int Id { get; set; }
        string FirstName { get; set; }

        // Events
        event EventHandler CloseForm;
        event EventHandler RowSelected;

        // Methods
        void SetPetClientBindingSource(BindingSource petClientList);
        void Show();
        void Close();
    }
}
