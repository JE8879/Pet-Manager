using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Pet_Manager.Presenters.Common;
using Pet_Manager.Views;
using Pet_Manager.Models;

namespace Pet_Manager.Presenters
{
    public class ClientPresenter
    {
        // Fields
        private IClientView clientView;
        private IClientRepository clientRepository;
        private BindingSource clientBindingSource;
        private IEnumerable<ClientModel> clientList;

        public ClientPresenter(IClientView clientView, IClientRepository clientRepository)
        {
            this.clientView = clientView;
            this.clientRepository = clientRepository;
            this.clientBindingSource = new BindingSource();

            // Subscribe event handler methods to view events
            this.clientView.SearchEvent += SearchClient;
            this.clientView.SaveEvent += SaveClient;
            this.clientView.EditEvent += EditClient;
            this.clientView.DeleteEvent += DeleteClient;
            this.clientView.CancelEvent += CancelAction;
            this.clientView.SetClientBindingSource(clientBindingSource);

            // Load Clients
            LoadAllClients();
            // Show View
            this.clientView.Show();

        }

        private void LoadAllClients()
        {
            clientList = clientRepository.GetAll();
            clientBindingSource.DataSource = clientList;
        }

        private void CancelAction(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void DeleteClient(object sender, EventArgs e)
        {
            try
            {
                ClientModel clientModel = (ClientModel)clientBindingSource.Current;
                clientRepository.Delete(clientModel.Id);
                clientView.IsSuccessfull = true;
                clientView.Message = "Client deleted successfully";
                LoadAllClients();
            }
            catch (Exception ex)
            {
                clientView.IsSuccessfull = false;
                clientView.Message = ex.Message;
            }
           
        }

        private void EditClient(object sender, EventArgs e)
        {
            ClientModel currentClient = (ClientModel)clientBindingSource.Current;
            clientView.Id = currentClient.Id;
            clientView.First_name = currentClient.First_name;
            clientView.Last_name = currentClient.Last_name;
            clientView.Phone = currentClient.Phone;
            clientView.Email = currentClient.Email;
            clientView.Client_address = currentClient.Client_address;
            clientView.Registration_date = currentClient.Registration_date;
            clientView.IsEdit = true;
        }

        private void SaveClient(object sender, EventArgs e)
        {
            ClientModel clientModel = new ClientModel();
            clientModel.Id = Convert.ToInt32(clientView.Id);
            clientModel.First_name = clientView.First_name;
            clientModel.Last_name = clientView.Last_name;
            clientModel.Phone = clientView.Phone;
            clientModel.Email = clientView.Email;
            clientModel.Client_address = clientView.Client_address;
            clientModel.Registration_date = clientView.Registration_date;

            try
            {
                new ModelDataValidation().Validate(clientModel);
                if(this.clientView.IsEdit)
                {
                    clientRepository.Edit(clientModel);
                    clientView.Message = "Client updated successfully";
                }
                else
                {
                    clientRepository.Add(clientModel);
                    clientView.Message = "Client added successfully";
                }
                clientView.IsSuccessfull = true;
                LoadAllClients();
                ClearFields();
            }
            catch (Exception ex)
            {
                clientView.IsSuccessfull = false;
                clientView.Message = ex.Message;
            }

        }

        private void SearchClient(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.clientView.SearchValue);
            if (emptyValue == false)
                 clientList = clientRepository.GetByValue(this.clientView.SearchValue);
            else clientList = clientRepository.GetAll();
            
            clientBindingSource.DataSource = clientList;
        }

        private void ClearFields()
        {
            clientView.Id = 0;
            clientView.First_name = string.Empty;
            clientView.Last_name = string.Empty;
            clientView.Phone = string.Empty;
            clientView.Email = string.Empty;
            clientView.Client_address = string.Empty;
        }
    }
}
