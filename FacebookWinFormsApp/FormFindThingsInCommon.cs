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

namespace BasicFacebookFeatures
{
    public partial class FormFindThingsInCommon : FormObjectCollection<User>
    {
        private AllInCommonThingsWithFriend m_AllInCommonThingsWithFriend;
        private User m_LoggedInUser;

        public FormFindThingsInCommon(FacebookObjectCollection<User> i_UserCollection, User i_LoggedInUser)
                    : base(i_UserCollection)
        {
            InitializeComponent();
            m_LoggedInUser = i_LoggedInUser;
        }

        protected override void listBoxCollectionItemsNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            base.listBoxCollectionItemsNames_SelectedIndexChanged(sender, e);
            m_AllInCommonThingsWithFriend = new AllInCommonThingsWithFriend(m_LoggedInUser, base.SelectedItemList);
            initCommonThingsComponents();
        }

        private void initCommonThingsComponents()
        {
            initialListBoxComponent<User>(listBoxFriends, m_AllInCommonThingsWithFriend.CommonFriends);
            initialListBoxComponent<Group>(listBoxGroups, m_AllInCommonThingsWithFriend.CommonGroups);
            initialListBoxComponent<Event>(listBoxEvents, m_AllInCommonThingsWithFriend.CommoEvents);
            initialListBoxComponent<Page>(listBoxPages, m_AllInCommonThingsWithFriend.CommonPages);
        }

        private void initialListBoxComponent<T>(ListBox i_ListBoxCollection, List<T> i_CommonCollection)
        {
            PropertyInfo nameProperty = typeof(T).GetProperty("Name");
            if (i_CommonCollection != null)
            {
                foreach (T item in i_CommonCollection)
                {
                    string name = nameProperty.GetValue(item) is string ?
                        nameProperty.GetValue(item) as string :
                        m_AllInCommonThingsWithFriend.NoNameForItem<T>();
                    i_ListBoxCollection.Items.Add(name);
                }

                if (i_CommonCollection.Count == 0)
                {
                    i_ListBoxCollection.Items.Add(m_AllInCommonThingsWithFriend.NoNameForItem<T>());
                    i_ListBoxCollection.Enabled = false;
                }
            }

        }

        private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            initialPhotoByListBoxIndex<User>(roundPictureBoxListBoxFriendsPick, listBoxFriends, m_AllInCommonThingsWithFriend.CommonFriends);
        }
        private void initialPhotoByListBoxIndex<T>(RoundPictureBox i_RoundPictureBox, ListBox i_ListBox, List<T> i_CommonCollection)
        {
            PropertyInfo pictureProperty = typeof(T).GetProperty("PictureNormalURL");

            if (pictureProperty != null)
            {
                i_RoundPictureBox.LoadAsync(
                    pictureProperty.GetValue(i_CommonCollection[i_ListBox.SelectedIndex]) as string);
            }
        }

        private void listBoxEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            initialPhotoByListBoxIndex<Event>(roundPictureBoxCommonEvents, listBoxEvents, m_AllInCommonThingsWithFriend.CommoEvents);
        }

        private void listBoxPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            initialPhotoByListBoxIndex<Page>(roundPictureBoxCommonPages, listBoxPages, m_AllInCommonThingsWithFriend.CommonPages);
        }

        private void listBoxGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            initialPhotoByListBoxIndex<Group>(roundPictureBoxCommonGroups, listBoxGroups, m_AllInCommonThingsWithFriend.CommonGroups);
        }
    }
    
}
