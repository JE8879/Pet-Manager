namespace Pet_Manager.Views
{
    partial class PetClientView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridClients = new System.Windows.Forms.DataGridView();
            this.BtnGetPet = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClients)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridClients
            // 
            this.dataGridClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridClients.Location = new System.Drawing.Point(12, 58);
            this.dataGridClients.Name = "dataGridClients";
            this.dataGridClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridClients.Size = new System.Drawing.Size(368, 222);
            this.dataGridClients.TabIndex = 0;
            // 
            // BtnGetPet
            // 
            this.BtnGetPet.Location = new System.Drawing.Point(12, 303);
            this.BtnGetPet.Name = "BtnGetPet";
            this.BtnGetPet.Size = new System.Drawing.Size(150, 23);
            this.BtnGetPet.TabIndex = 1;
            this.BtnGetPet.Text = "Select";
            this.BtnGetPet.UseVisualStyleBackColor = true;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(230, 303);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(150, 23);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // PetClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 338);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnGetPet);
            this.Controls.Add(this.dataGridClients);
            this.MaximizeBox = false;
            this.Name = "PetClientView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PetClientView";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridClients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridClients;
        private System.Windows.Forms.Button BtnGetPet;
        private System.Windows.Forms.Button BtnCancel;
    }
}