using System;
using System.Configuration;
using System.Windows.Forms;
using Pet_Manager.Presenters;
using Pet_Manager.Views;

namespace Pet_Manager
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string sqlConnectionString = ConfigurationManager.ConnectionStrings["Pet_Manager.Properties.Settings.connectionString"].ConnectionString;
            IMainview mainview = new MainView();

            new MainPresenter(mainview, sqlConnectionString);
            Application.Run((Form)mainview);
        }
    }
}
