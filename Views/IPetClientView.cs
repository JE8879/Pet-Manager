using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pet_Manager.Views
{
    public interface IPetClientView
    {
        // Properties
        int id { get; set; }
        string first_name { get; set; }

        // Methods
        void SetPetClientBindingSource(BindingSource petClientList);
        void Show();
    }
}
