using System;
using System.Windows.Forms;

namespace Pet_Manager.Views
{
    public partial class PetView : Form, IPetView
    {
        private string message;
        private bool isEdit;
        private bool isSuccessfull;

        public PetView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            BtnSearchPet.Click += delegate
            {
                SearchEvent?.Invoke(this, EventArgs.Empty);
            };

            textSearchPet.KeyDown += (s, e) =>
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
                    MessageBox.Show($"Error al guardar la mascota: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            BtnUpdate.Click += delegate
            {
                var result = MessageBox.Show("¿Está seguro de que desea editar la mascota seleccionada?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        EditEvent?.Invoke(this, EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al editar la mascota: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            BtnDelete.Click += delegate
            {
                var result = MessageBox.Show("¿Está seguro de que desea eliminar la mascota seleccionada?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        DeleteEvent?.Invoke(this, EventArgs.Empty);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar la mascota: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            BtnCancel.Click += delegate
            {
                var result = MessageBox.Show("¿Está seguro de que desea cancelar la operación?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    CancelEvent?.Invoke(this, EventArgs.Empty);
                }
            };

            BtnSelectClient.Click += delegate
            {
                OpenClientEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        #region Properties
        public int pet_id { 
            get => Convert.ToInt32(textPetId.Text); 
            set => textPetId.Text = value.ToString(); 
        }
        public int client_id
        {
            get => Convert.ToInt32(textClientId.Text);
            set => textClientId.Text = value.ToString();
        }
        public string pet_name { 
            get => textPetName.Text; 
            set => textPetName.Text = value;
        }
        public string species { 
            get => textSpecies.Text; 
            set => textSpecies.Text = value; 
        }
        public string geneder { 
            get => CboGender.Text; 
            set => CboGender.Text = value;
        }
        public DateTime birth_date { 
            get => petBirthdate.Value; 
            set => petBirthdate.Value = value;
        }
        public float pet_weight
        {
            get => Convert.ToSingle(petWeight.Value);
            set => petWeight.Value = Convert.ToDecimal(value);
        }
        public string color { 
            get => textColor.Text; 
            set => textColor.Text = value;
        }
        public string SearchValue { 
            get => textSearchPet.Text; 
            set => textSearchPet.Text = value;
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
        public event EventHandler OpenClientEvent;

        public void SetPetBindingSource(BindingSource petList)
        {
            dataGridPets.DataSource = petList;
        }

        private static PetView instance;
        public static PetView GetInstance(Form parentContainer)
        {
            if(instance == null || instance.IsDisposed)
            {
                instance = new PetView
                {
                    MdiParent = parentContainer,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
            }
            else
            {
                instance.BringToFront();
            }
            return instance;
        }
    }
}
