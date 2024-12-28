using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Pet_Manager.DTOs;
using Pet_Manager.Views;

namespace Pet_Manager.Presenters
{
    public class PetClientPresenter
    {
        // Fields
        private IPetClientView petClientView;
        private IPetClientRepository petClientRepository;
        private BindingSource petClientBindingSource;
        private IEnumerable<PetClientModel> petClientList;

        public PetClientPresenter(IPetClientView petClientView, IPetClientRepository petClientRepository)
        {
            this.petClientView = petClientView;
            this.petClientRepository = petClientRepository;
            this.petClientBindingSource = new BindingSource();

            // Load Clients
            LoadAllClients();
            // Show View
            this.petClientView.Show();
        }

        private void LoadAllClients()
        {
            petClientList = petClientRepository.GetAll();
            petClientBindingSource.DataSource = petClientList;
        }
    }
}
