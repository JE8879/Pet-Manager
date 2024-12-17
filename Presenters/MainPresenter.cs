using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pet_Manager.Views;
using Pet_Manager.Models;
using Pet_Manager.Repositories;
using System.Drawing.Printing;

namespace Pet_Manager.Presenters
{
    public class MainPresenter
    {
        private IMainview mainview;
        private readonly string sqlConnectionString;

        public MainPresenter(IMainview mainview, string sqlConnectionString)
        {
            this.mainview = mainview;
            this.sqlConnectionString = sqlConnectionString;
            this.mainview.ShowClientView += ShowClientsView;
        }

        private void ShowClientsView(object sender, EventArgs e)
        {
            IClientView clientView = ClientView.GetInstance((MainView)mainview);
            IClientRepository repository = new ClientRepository(sqlConnectionString);
            new ClientPresenter(clientView, repository);
        }
    }
}
