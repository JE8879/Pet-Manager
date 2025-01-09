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
                SearchEvent?.Invoke(this, EventArgs.Empty);
            };

            textSearchClient.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SearchEvent?.Invoke(this, EventArgs.Empty);
                }
            };

            BtnSave.Click += delegate
            {
                try
                {
                    SaveEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            BtnUpdate.Click += delegate
            {
                var result = MessageBox.Show("¿Está seguro de que desea editar el cliente seleccionado?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        EditEvent?.Invoke(this, EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al editar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            BtnDelete.Click += delegate
            {
                var result = MessageBox.Show("¿Está seguro de que desea eliminar el cliente seleccionado?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        DeleteEvent?.Invoke(this, EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            BtnCancel.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        #region Properties
        public int Id
        {
            get => Convert.ToInt32(textClientId.Text);
            set => textClientId.Text = value.ToString();
        }

        public string First_name
        {
            get => textFirstName.Text;
            set => textFirstName.Text = value;
        }

        public string Last_name
        {
            get => textLastName.Text;
            set => textLastName.Text = value;
        }

        public string Phone
        {
            get => textPhone.Text;
            set => textPhone.Text = value;
        }

        public string Email
        {
            get => textEmail.Text;
            set => textEmail.Text = value;
        }

        public string Client_address
        {
            get => textAddress.Text;
            set => textAddress.Text = value;
        }

        public DateTime Registration_date
        {
            get => registrationDate.Value;
            set => registrationDate.Value = value;
        }

        public string SearchValue
        {
            get => textSearchClient.Text;
            set => textSearchClient.Text = value;
        }

        public bool IsEdit
        {
            get => isEdit;
            set => isEdit = value;
        }

        public bool IsSuccessfull
        {
            get => isSuccessfull;
            set => isSuccessfull = value;
        }

        public string Message
        {
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
                instance = new ClientView
                {
                    MdiParent = parentContainer,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
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
