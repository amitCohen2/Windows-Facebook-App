using FacebookWrapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookLogic;

namespace BasicFacebookFeatures
{
    public partial class FormLogin : Form
    {

        public FormMain MainApp { get; set; }
        public FormLogin()
        {
            InitializeComponent();
            checkIfRememberLastUser();
        }

        public bool isUserConnected()
        {
            return MainApp != null;
        }
        
        private void checkIfRememberLastUser()
        {
            UserDetails.UserDetailsInstance.LoadFromFile();

            if (UserDetails.UserDetailsInstance.UserToken != null)
            {
                LoginResult loginResult = FacebookService.Connect(UserDetails.UserDetailsInstance.UserToken);
                checkBoxRememberMe.Checked = true;
                initMainApp(loginResult);
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            LoginResult loginResult = FacebookService.Login(
                    /// App ID
                    "315092548194623", 
                    /// requested permissions:
                    "email",
                    "public_profile",
                    "user_birthday",
                    "user_friends",
                    "user_events", 
                    "user_friends", 
                    "user_age_range",
                    "user_gender",
                    "user_hometown",
                    "user_likes",
                    "user_link",
                    "user_location",
                    "user_photos",
                    "user_posts",
                    "user_videos");

            if (string.IsNullOrEmpty(loginResult.AccessToken))
            {
                MessageBox.Show("An error occurred: " + loginResult.ErrorMessage,
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                initMainApp(loginResult);
            }
        }


        private void initMainApp(LoginResult i_LoginResult)
        {
            MainApp = new FormMain(i_LoginResult, checkBoxRememberMe.Checked);
            MainApp.fetchUserInfo();
            Close();
        }


    }
}
