using System;
using System.Windows.Forms;

namespace Pet_Manager.Views
{
    public partial class UserView : Form, IUserView
    {
        private string message;
        private bool isEdit;
        private bool isSuccessfull;

        public UserView()
        {
            InitializeComponent();
            HandleViewEvents();
        }

        private void HandleViewEvents()
        {
            BtnCreateUser.Click += delegate
            {
                try
                {
                    SaveEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);                  
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
        }

        #region Properties
        public int User_id { 
            get => Convert.ToInt32(textUserId.Text); 
            set => textUserId.Text = value.ToString();
        }

        public string Username { 
            get => textUsername.Text; 
            set => textUsername.Text = value;
        }

        public string Password { 
            get => textPassword.Text;
            set => textPassword.Text = value;
        }

        public byte[] PasswordSalt { get; set; }

        public int Employee_id { 
            get => Convert.ToInt32(LblEmployeeId.Text); 
            set => LblEmployeeId.Text = value.ToString();
        }

        public string SearchValue { 
            get => textSearchValue.Text; 
            set => textSearchValue.Text = value; 
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

        private static UserView instance;
        public static UserView GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new UserView();
            }
            else
            {
                instance.BringToFront();
            }
            return instance;
        }
    }
}
