using System;
using Pet_Manager.Views;
using Pet_Manager.Models;
using Pet_Manager.Repositories;

namespace Pet_Manager.Presenters
{
    public class MainPresenter
    {
        private readonly IMainview mainview;
        private readonly string sqlConnectionString;

        public MainPresenter(IMainview mainview, string sqlConnectionString)
        {
            this.mainview = mainview ?? throw new ArgumentNullException(nameof(mainview));
            this.sqlConnectionString = sqlConnectionString ?? throw new ArgumentNullException(nameof(sqlConnectionString));
            this.mainview.ShowClientView += ShowClientsView;
            this.mainview.ShowPetView += ShowPetsView;
        }

        /// <summary>
        /// Handles the event to show the client view.
        /// </summary>
        private void ShowClientsView(object sender, EventArgs e)
        {
            var clientView = ClientView.GetInstance((MainView)mainview);
            var repository = new ClientRepository(sqlConnectionString);
            new ClientPresenter(clientView, repository);
        }

        /// <summary>
        /// Handles the event to show the pet view.
        /// </summary>
        private void ShowPetsView(object sender, EventArgs e)
        {
            var petView = PetView.GetInstance((MainView)mainview);
            var repository = new PetRepository(sqlConnectionString);
            new PetPresenter(petView, repository, sqlConnectionString);
        }
    }
}
