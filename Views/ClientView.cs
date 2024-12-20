using System;
using System.Windows.Forms;

namespace Pet_Manager.Views
{
    public partial class ClientView : Form, IClientView
    {
        private string message;
        private bool isEdit;
        private bool isSuccessfull;

        public ClientView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            BtnSearchClient.Click += delegate
            {
                SearchEvent.Invoke(this, EventArgs.Empty);
                textSearchClient.KeyDown +=(s,e) =>
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        SearchEvent.Invoke(e, EventArgs.Empty);
                    }
                };
            };

            BtnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                MessageBox.Show(message, "Atention",MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            BtnUpdate.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to edit the selectd Client", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    EditEvent?.Invoke(this, EventArgs.Empty);
                }
            };

            BtnDelete.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected Client", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                }
            };

            BtnCancel.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        #region Properties
        public int Id { 
            get => Convert.ToInt32(textClientId.Text); 
            set => textClientId.Text = value.ToString();
        }

        public string First_name { 
            get => textFirstName.Text; 
            set => textFirstName.Text = value; 
        }

        public string Last_name { 
            get => textLastName.Text; 
            set => textLastName.Text = value; 
        }

        public string Phone { 
            get => textPhone.Text; 
            set => textPhone.Text = value; 
        }

        public string Email { 
            get => textEmail.Text; 
            set => textEmail.Text = value; 
        }

        public string Client_address { 
            get => textAddress.Text; 
            set => textAddress.Text = value; 
        }

        public DateTime Registration_date { 
            get => registrationDate.Value; 
            set => registrationDate.Value = value; 
        }

        public string SearchValue { 
            get => textSearchClient.Text; 
            set => SearchValue = value; 
        }

        public bool IsEdit { 
            get => isEdit; 
            set => isEdit = value; 
        }

        public bool IsSuccessfull { 
            get => isSuccessfull; 
            set => isSuccessfull = value; 
        }

        public string Message { 
            get => message; 
            set => message = value; 
        }
        #endregion


        public event EventHandler SearchEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        public void SetClientBindingSource(BindingSource clientList)
        {
            dataGridClients.DataSource = clientList;
        }

        private static ClientView instance;
        public static ClientView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ClientView();
                instance.MdiParent = parentContainer;
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                {
                    instance.WindowState = FormWindowState.Normal;
                }
                instance.BringToFront();
            }
            return instance;
        }
    }
}
