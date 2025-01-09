using System;

namespace Pet_Manager.Views
{
    public interface IMainview
    {
        event EventHandler ShowClientView;
        event EventHandler ShowPetView;
        event EventHandler ShowEmployeeView;
        event EventHandler ShowUserView;
    }
}
