using System;
using System.Security.Cryptography;
using Pet_Manager.Models;
using Pet_Manager.Presenters.Common;
using Pet_Manager.Views;

namespace Pet_Manager.Presenters
{
    public class UserPresenter
    {
        // Fields
        private IUserView userView;
        private IUserRepository userRepository;

        // Constructor
        public UserPresenter(IUserView userView, IUserRepository userRepository)
        {
            this.userView = userView;
            this.userRepository = userRepository;

            // Subscribe event handler methods to view events
            this.userView.SaveEvent += SaveEvent;

            // Show View
            this.userView.Show();
        }

        private void SaveEvent(object sender, EventArgs e)
        {
            UserModel userModel = new UserModel();

            // Generate salt and hash for the password
            var salt = GenerateSalt();
            var hash = HashPassword(userView.Password, salt);

            userModel.Id = this.userView.User_id;
            userModel.Username = this.userView.Username;
            userModel.PasswordHash = hash;
            userModel.PasswordSalt = salt;
            userModel.Employee_id = this.userView.Employee_id;

            try
            {
                new ModelDataValidation().Validate(userModel);
                userRepository.CreateUser(userModel);

                // Set success status
                userView.IsSuccessfull = true;
                // Set message status
                userView.Message = "User added successfully";
            }
            catch (Exception ex)
            {
                userView.IsSuccessfull = false;
                userView.Message = ex.Message;
            }
        }

        private byte[] GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var salt = new byte[128];
                rng.GetBytes(salt);
                return salt;
            }
        }

        private byte[] HashPassword(string password, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                return pbkdf2.GetBytes(64); // Obtener un hash de 64 bytes
            }
        }
    }
}
