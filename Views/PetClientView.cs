using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pet_Manager.Views
{
    public partial class PetClientView : Form, IPetClientView
    {
        public PetClientView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }

        private void AssociateAndRaiseViewEvents()
        {
            BtnCancel.Click += delegate
            {
                CloseForm?.Invoke(this, EventArgs.Empty);
            };

            BtnGetPet.Click += delegate
            {
                RowSelected?.Invoke(this, EventArgs.Empty);
            };
        }


        public void SetPetClientBindingSource(BindingSource petClientList)
        {
            dataGridClients.DataSource = petClientList; 
        }

        public event EventHandler CloseForm;
        public event EventHandler RowSelected;

        private static PetClientView instance;
        public static PetClientView GetInstance()
        {
            if(instance == null || instance.IsDisposed)
            {
                instance = new PetClientView();
            }
            else
            {
                instance.BringToFront();
            }
            return instance;
        }
    }
}
