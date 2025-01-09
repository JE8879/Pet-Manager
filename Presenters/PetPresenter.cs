using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Pet_Manager.Presenters.Common;
using Pet_Manager.Views;
using Pet_Manager.Models;
using Pet_Manager.Repositories;

namespace Pet_Manager.Presenters
{
    public class PetPresenter
    {
        // Fields
        private IPetView petView;
        private IPetRepository petRepository;
        private BindingSource petBindingSource;
        private readonly string sqlConnectionString;
        private IEnumerable<PetModel> petList;

        public PetPresenter(IPetView petView, IPetRepository petRepository, string sqlConnectionString)
        {
            this.petView = petView;
            this.petRepository = petRepository;
            this.petBindingSource = new BindingSource();

            // Subscribe event handler methods to view events
            this.petView.SearchEvent += SearchPet;
            this.petView.SaveEvent += SavePet;
            this.petView.EditEvent += EditPet;
            this.petView.DeleteEvent += DeletePet;
            this.petView.CancelEvent += CancelAction;
            this.petView.OpenClientEvent += OpenClient;
            this.petView.SetPetBindingSource(petBindingSource);

            // Load Pets
            LoadAllPets();
            // Show View
            this.petView.Show();
            this.sqlConnectionString = sqlConnectionString;
        }

        private void LoadAllPets()
        {
            petList = petRepository.GetAll();
            petBindingSource.DataSource = petList;
        }

        private void SearchPet(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.petView.SearchValue);
            if (emptyValue == false)
                petList = petRepository.GetByValue(this.petView.SearchValue);
            else petList = petRepository.GetAll();
            petBindingSource.DataSource = petList;
        }

        private void SavePet(object sender, EventArgs e)
        {
            PetModel petModel = new PetModel();
            petModel.Pet_id = petView.pet_id;
            petModel.Client_id = petView.client_id;
            petModel.Pet_name = petView.pet_name;
            petModel.Species = petView.species;
            petModel.Gender = petView.geneder;
            petModel.Birth_date = petView.birth_date;
            petModel.Pet_weight = petView.pet_weight;
            petModel.Color = petView.color;


            try
            {
                new ModelDataValidation().Validate(petModel);
                if (this.petView.IsEdit)
                {
                    petRepository.Edit(petModel);
                    petView.Message = "Pet edited successfully";
                }
                else
                {
                    petRepository.Add(petModel);
                    petView.Message = "Pet added successfully";
                }
                petView.IsSuccessfull = true;
                LoadAllPets();
                ClearFileds();
            }
            catch (Exception ex)
            {
                petView.IsSuccessfull = false;
                petView.Message = ex.Message;
            }
        }

        private void EditPet(object sender, EventArgs e)
        {
            PetModel currentPet = (PetModel)petBindingSource.Current;
            petView.pet_id = currentPet.Pet_id;
            petView.client_id = currentPet.Client_id;
            petView.pet_name = currentPet.Pet_name;
            petView.species = currentPet.Species;
            petView.geneder = currentPet.Gender;
            petView.birth_date = currentPet.Birth_date;
            petView.pet_weight = currentPet.Pet_weight;
            petView.color = currentPet.Color;
            petView.IsEdit = true;

        }

        private void DeletePet(object sender, EventArgs e)
        {
            try
            {
                PetModel currentPet = (PetModel)petBindingSource.Current;
                petRepository.Delete(currentPet.Pet_id);
                petView.Message = "Pet deleted successfully";
                LoadAllPets();
            }
            catch (Exception ex)
            {
                petView.IsSuccessfull = false;
                petView.Message = ex.Message;
            }
        }

        private void CancelAction(object sender, EventArgs e)
        {
            ClearFileds();
            petView.IsEdit = false;
        }

        private void OpenClient(object sender, EventArgs e)
        {
            var petClientView = PetClientView.GetInstance();
            var petClientRepository = new PetClientRepository(sqlConnectionString);
            new PetClientPresenter(petClientView, petClientRepository);
        }

        private void ClearFileds()
        {
            petView.pet_id = 0;
            petView.client_id = 0;
            petView.pet_name = string.Empty;
            petView.species = string.Empty;
            petView.geneder = string.Empty;
            petView.birth_date = DateTime.Now;
            petView.pet_weight = 0;
            petView.color = string.Empty;
        }
    }
}
