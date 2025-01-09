using System;
using Pet_Manager.Views.Form_Helps;
using System.Windows.Forms;

namespace Pet_Manager.Views
{
    public partial class EmployeeUserView : Form, IEmployeeUserView
    {
        public EmployeeUserView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        // Properties
        public int Id { get; set; }
        public string First_name { get; set; }

        private void AssociateAndRaiseViewEvents()
        {
            BtnSelect.Click += delegate
            {
                GetSelectedRow?.Invoke(this, EventArgs.Empty);
            };
            BtnCancel.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        // Events
        public event EventHandler GetSelectedRow;
        public event EventHandler CancelEvent;

        // Methods
        public void SetEmployeeUserBindingSource(BindingSource employeeUserList)
        {
            dataGridEmployees.DataSource = employeeUserList;
        }

        private static EmployeeUserView _instance;
        public static EmployeeUserView GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new EmployeeUserView();
            }
            else
            {
                _instance.BringToFront();
            }
            return _instance;
        }
    }
}
