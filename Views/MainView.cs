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
            AssociateMenuItemsEvents();
        }

        public event EventHandler ShowClientView;
        public event EventHandler ShowPetView;
        public event EventHandler ShowEmployeeView;
        public event EventHandler ShowUserView;

        public void AssociateMenuItemsEvents()
        {
            if (mainMenu.Items["fileToolStripMenuItem"] is ToolStripMenuItem fileMenuItem)
            {
                // Access and assign events to the submenus
                if (fileMenuItem.DropDownItems["registerClientToolStripMenuItem"] is ToolStripMenuItem registerClient)
                {
                    registerClient.Click += delegate { ShowClientView?.Invoke(this, EventArgs.Empty); };
                }
                if (fileMenuItem.DropDownItems["registerPetToolStripMenuItem"] is ToolStripMenuItem registerPet)
                {
                    registerPet.Click += delegate { ShowPetView?.Invoke(this, EventArgs.Empty); };
                }
                if (fileMenuItem.DropDownItems["exitToolStripMenuItem"] is ToolStripMenuItem exit)
                {
                    exit.Click += delegate { Close(); };
                }
            }

            if (mainMenu.Items["toolsToolStripMenuItem"] is ToolStripMenuItem toolStripMenu)
            {
                // Access and assign events to the submenus
                if (toolStripMenu.DropDownItems["addNewEmployeeToolStripMenuItem"] is ToolStripMenuItem registerEmployee)
                {
                    registerEmployee.Click += delegate { ShowEmployeeView?.Invoke(this, EventArgs.Empty); };
                }

                if (toolStripMenu.DropDownItems["addNewUserToolStripMenuItem"] is ToolStripMenuItem registerUser)
                {
                    registerUser.Click += delegate { ShowUserView?.Invoke(this, EventArgs.Empty); };
                }
            }
        }
    }
}
