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

        public string SearchValue {
            get => textSearch.Text; 
            set => textSearch.Text = value; 
        }

        private void AssociateAndRaiseViewEvents()
        {
            textSearch.KeyDown += delegate (object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SearchEvent?.Invoke(this, EventArgs.Empty);
                }
            };

            BtnSearch.Click += delegate
            {
                SearchEvent?.Invoke(this, EventArgs.Empty);
            };

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
        public event EventHandler SearchEvent;

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
