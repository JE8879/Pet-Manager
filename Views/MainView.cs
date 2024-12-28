using System;
using System.Windows.Forms;

namespace Pet_Manager.Views
{
    public partial class MainView : Form, IMainview
    {
        public MainView()
        {
            InitializeComponent();
            BtnClients.Click += delegate { ShowClientView?.Invoke(this, EventArgs.Empty); };
            BtnPets.Click += delegate { ShowPetView?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler ShowClientView;
        public event EventHandler ShowPetView;
    }
}
