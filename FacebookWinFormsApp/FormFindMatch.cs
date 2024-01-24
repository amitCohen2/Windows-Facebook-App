using FacebookLogic;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static FacebookWrapper.ObjectModel.User;

namespace BasicFacebookFeatures
{
    public partial class FormFindMatch : Form
    {
        private User m_LoggedInUser;
        private List<User> m_PrefferedFriends;
        private PrefferedUsersDetails m_PrefferedUsersDetails;
        public FormFindMatch(User i_LoggedInUser, PrefferedUsersDetails i_PrefferedUsersDetails)
        {
            InitializeComponent();
            m_LoggedInUser = i_LoggedInUser;
            m_PrefferedUsersDetails = i_PrefferedUsersDetails;
            initialComponent();
        }

        public void initialComponent()
        {
            PropertyInfo nameProperty = typeof(User).GetProperty("Name");
            string name = null;
            m_PrefferedFriends = new List<User>();
            foreach (User friend in m_LoggedInUser.Friends)
            {
                if (isMatchFit(friend))
                {
                    name = nameProperty.GetValue(friend) is string ?
                            nameProperty.GetValue(friend) as string :
                            nothingToShow();
                    listBoxMatchFriendsNames.Items.Add(name);
                    m_PrefferedFriends.Add(friend);
                }
            }

            if (m_LoggedInUser.Friends.Count == 0 || m_PrefferedFriends.Count == 0)
            {
                listBoxMatchFriendsNames.Items.Add(nothingToShow());
                setAllComponentsDisable();
            }

        }
        private string nothingToShow()
        {
            return $"No Match Friends to show";
        }

        private void setAllComponentsDisable()
        {
            listBoxAbout.Enabled = false;
            listBoxMatchFriendsNames.Enabled = false;
            roundPictureBox.Enabled = false;
        }

        private bool isMatchFit(User i_User)
        {
            return isGenderFit(i_User) && isAgesFit(i_User) && isRelationshipStatusFit(i_User);
        }

        private bool isRelationshipStatusFit(User i_User)
        {
            eRelationshipStatus currStatus = i_User.RelationshipStatus.Value;
            return !currStatus.Equals(eRelationshipStatus.InARelationship) &&
                !currStatus.Equals(eRelationshipStatus.Enagaged) &&
                !currStatus.Equals(eRelationshipStatus.Married);
        }

        private bool isAgesFit(User i_User)
        {
            int age = calculateAge(i_User.Birthday);
            return age <= m_PrefferedUsersDetails.MaxAge && age >= m_PrefferedUsersDetails.MinAge; 
        }

        private int calculateAge(string i_Bitrhdat)
        {
            if (DateTime.TryParse(i_Bitrhdat, out DateTime birthdate))
            {
                DateTime today = DateTime.Today;
                int age = today.Year - birthdate.Year;

                if (birthdate > today.AddYears(-age))
                {
                    age--;
                }

                return age;
            }
            else
            {
                // Handle invalid birthday format
                return -1; // or throw an exception or handle it as appropriate for your case
            }
        }

        private bool isGenderFit(User i_User)
        {
            return (i_User.Gender == User.eGender.male && m_PrefferedUsersDetails.IsAttractInMale) ||
                (i_User.Gender == User.eGender.female && m_PrefferedUsersDetails.IsAttractInFemale);
        }


        private void listBoxCollectionItemsNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            initalMainPictureValue(listBoxMatchFriendsNames.SelectedIndex);
            initialDescriptionValue(listBoxMatchFriendsNames.SelectedIndex);
        }

        private void initalMainPictureValue(int i_SelectedIndex)
        {
            string profilePhoto = m_PrefferedFriends[listBoxMatchFriendsNames.SelectedIndex].PictureNormalURL;

            if (profilePhoto != null)
            {
                roundPictureBox.LoadAsync(profilePhoto);
            }
        }

        private void initialDescriptionValue(int i_indexInList)
        {
            listBoxAbout.Items.Clear();
            User currUser = m_PrefferedFriends[i_indexInList];

            if (currUser.Name != null)
            {
                listBoxAbout.Items.Add($"Name: {currUser.Name}");
            }
            if (currUser.Gender != null)
            {
                listBoxAbout.Items.Add($"Gender: {currUser.Gender}");
            }
            if (currUser.Email != null)
            {
                listBoxAbout.Items.Add($"Email: {currUser.Email}");
            }
            if (currUser.Birthday != null)
            {
                listBoxAbout.Items.Add($"Birthday:  {currUser.Birthday}");
            }
            if (currUser.Hometown != null)
            {
                listBoxAbout.Items.Add($"Hometown: { currUser.Hometown}");
            }
            if (currUser.Location != null)
            {
                listBoxAbout.Items.Add($"Current location: {currUser.Location}");
            }
        }


    }
}
