using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Pet_Manager.DTOs;
using Pet_Manager.Views;

namespace Pet_Manager.Presenters
{
    public class PetClientPresenter
    {
        // Fields
        private readonly IPetClientView petClientView;
        private readonly IPetClientRepository petClientRepository;
        private readonly BindingSource petClientBindingSource;
        private IEnumerable<PetClientModel> petClientList;

        public PetClientPresenter(IPetClientView petClientView, IPetClientRepository petClientRepository)
        {
            this.petClientView = petClientView ?? throw new ArgumentNullException(nameof(petClientView));
            this.petClientRepository = petClientRepository ?? throw new ArgumentNullException(nameof(petClientRepository));
            petClientBindingSource = new BindingSource();

            // Subscribe event handler methods to view events
            this.petClientView.RowSelected += GetSelectedRow;
            this.petClientView.CloseForm += CloseForm;
            this.petClientView.SetPetClientBindingSource(petClientBindingSource);

            // Load Clients
            LoadAllClients();
            // Show View
            this.petClientView.Show();
        }

        private void GetSelectedRow(object sender, EventArgs e)
        {
            try
            {
                if (petClientBindingSource.Current is PetClientModel currentRow)
                {
                    // Busca la instancia abierta de PetView
                    PetView petView = Application.OpenForms.OfType<PetView>().SingleOrDefault();

                    if (petView != null)
                    {
                        string clientInformation = $"{currentRow.Id} - {currentRow.First_name}";
                        petView.textClientId.Text = clientInformation;
                    }
                    this.petClientView.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar la fila: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CloseForm(object sender, EventArgs e)
        {
            petClientView.Close();
        }

        private void LoadAllClients()
        {
            try
            {
                petClientList = petClientRepository.GetAll();
                petClientBindingSource.DataSource = petClientList;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
