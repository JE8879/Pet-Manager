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
        }

        public int id { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }
        public string first_name { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }

        public void SetPetClientBindingSource(BindingSource petClientList)
        {
            dataGridClients.DataSource = petClientList; 
        }

        private static PetClientView instance;
        public static PetClientView GetInstance()
        {
            if(instance == null || instance.IsDisposed)
            {
                instance = new PetClientView();
            }
            return instance;
        }
    }
}
