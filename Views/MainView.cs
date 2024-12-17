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
    public partial class MainView : Form, IMainview
    {
        public MainView()
        {
            InitializeComponent();
            BtnClients.Click += delegate { ShowClientView?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler ShowClientView;
    }
}
