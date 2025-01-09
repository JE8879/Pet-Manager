using System;
using System.Windows.Forms;

namespace Pet_Manager.Views
{
    public partial class EmployeeView : Form, IEmployeeView
    {
        private string message;
        private bool isEdit;
        private bool isSuccessfull;

        public EmployeeView()
        {
            InitializeComponent();
            HandleViewEvents();
        }

        private void HandleViewEvents()
        {
            // Set Focus on First Name
            textFirstName.Focus();

            BtnSearchEmployee.Click += delegate
            {
                SearchEvent?.Invoke(this, EventArgs.Empty);
            };

            textSearchEmployee.KeyDown += (s, e) =>
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

                    MessageBox.Show(Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            BtnUpdate.Click += delegate
            {
                var result = MessageBox.Show("¿Está seguro de que desea editar el empleado seleccionado?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        EditEvent?.Invoke(this, EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al editar el empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            BtnDelete.Click += delegate
            {
                var result = MessageBox.Show("¿Está seguro de que desea eliminar el empleado seleccionado?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        DeleteEvent?.Invoke(this, EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            BtnCancel.Click += delegate
            {
                var result = MessageBox.Show("¿Está seguro de que desea cancelar la operación?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        CancelEvent?.Invoke(this, EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cancelar la operación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };
        }

        #region Properties
        public int Id { 
            get => Convert.ToInt32(textEmployeeId.Text);
            set => textEmployeeId.Text = value.ToString();
        }
        public string First_name { 
            get => textFirstName.Text; 
            set => textFirstName.Text = value; 
        }
        public string Last_name { 
            get => textLastName.Text; 
            set => textLastName.Text = value; 
        }
        public string Employee_role { 
            get => CboEmployeeRole.Text; 
            set => CboEmployeeRole.Text = value;
        }
        public string Phone { 
            get => textPhone.Text; 
            set => textPhone.Text = value; 
        }
        public string Email { 
            get => textEmail.Text; 
            set => textEmail.Text = value; 
        }
        public string Active { 
            get => CboActive.Text;
            set => CboActive.Text = value;
        }
        public string SearchValue { 
            get => textSearchEmployee.Text; 
            set => textSearchEmployee.Text = value; 
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

        public void SetEmployeeBindingSource(BindingSource employeeList)
        {
            dataGridEmployees.DataSource = employeeList;
        }

        private static EmployeeView instance;
        public static EmployeeView GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new EmployeeView();
                //instance = new EmployeeView
                //{
                //    MdiParent = parentContainer,
                //    FormBorderStyle = FormBorderStyle.None,
                //    Dock = DockStyle.Fill
                //};
            }
            else
            {
                if(instance.WindowState == FormWindowState.Minimized)
                {
                    instance.WindowState = FormWindowState.Normal;
                }
                instance.BringToFront();
            }
            return instance;
        }
    }
}
