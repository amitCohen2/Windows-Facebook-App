using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using FacebookLogic;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private static readonly string rs_LikesLabelString = "Likes: {0}";
        private readonly string[] rs_CoverPhotoes = new string[2] { "COVER PHOTOS", "תמונות נושא" };
        private bool m_RememberUser;
        private LoginResult m_LoginResult;
        private User m_LoggedInUser;
        public bool IsLoggoutPressed { get; set; }

        public FormMain(LoginResult i_LoginResult, bool i_RememberUser)
        {
            InitializeComponent();
            FacebookService.s_CollectionLimit = 100;
            m_LoginResult = i_LoginResult;
            m_LoggedInUser = m_LoginResult.LoggedInUser;
            m_RememberUser = i_RememberUser;
        }

        private void fetchItems<T>(IEnumerable<T> items, ListBox listBox, Func<T, string> displayFunc)
        {
            foreach (T item in items)
            {
                if (displayFunc(item) != null)
                {
                    listBox.Items.Add(displayFunc(item));
                }
            }
        }

        public void fetchUserInfo()
        {
            roundPictureBoxProfile.LoadAsync(m_LoggedInUser.PictureNormalURL);
            fetchAbout();
            fetchPages();
            fetchEvents();
            fetchAlbums();
            fetchCoverPhoto();
            fetchFriendsList();
            fetchPosts();
            fetchGroups();

        }

        private void fetchCoverPhoto()
        {
            Album coverAlbum = m_LoggedInUser.Albums.Find(isCoverAlbum);

            if (coverAlbum != null)
            {
                pictureBoxCover.LoadAsync(coverAlbum.PictureAlbumURL);
            }
        }

        private bool isCoverAlbum(Album i_album)
        {
            return i_album.Name.ToUpper().Equals(rs_CoverPhotoes[1]) ||
                i_album.Name.Equals(rs_CoverPhotoes[0]);
        }

        private void fetchPosts()
        {
            fetchItems(m_LoggedInUser.Posts.Where(post => post.Message != null),
                   listBoxPosts,
                   post => $"{post.CreatedTime}: {post.Message}");
        }

        private void fetchFriendsList()
        {
            int numOfFriendsToShow = Math.Min(2, m_LoggedInUser.Friends.Count);
            fetchItems(m_LoggedInUser.Friends.Take(numOfFriendsToShow),
                       listBoxFriends,
                       friend => friend.ToString());
        }

        private void fetchPages()
        {
            Random rand = new Random();
            int numOfPagesToShow = Math.Min(10, m_LoggedInUser.LikedPages.Count);
            fetchItems(Enumerable.Range(0, numOfPagesToShow),
                       listBoxPages,
                       empty => m_LoggedInUser.LikedPages[rand.Next(0, m_LoggedInUser.LikedPages.Count)].Name);
        }

        private void fetchEvents()
        {
            if (m_LoggedInUser.Events.Count == 0)
            {
                listBoxEvents.Items.Add("You don't have any upcoming events");
                buttonShowMyEvents.Enabled = false;
                buttonShowMyEvents.ForeColor = Color.FromKnownColor(KnownColor.AppWorkspace);
            }
            else
            {
                fetchItems(m_LoggedInUser.Events.Where(evnt => evnt.Name != null),
                       listBoxEvents,
                       evnt => $"{evnt.Name}: {evnt.Description}");
            }
        }

        private void fetchAlbums()
        {
            if (m_LoggedInUser.Albums.Count == 0)
            {
                listBoxAlbums.Items.Add("You don't have albums");
                buttonShowMyAlbums.Enabled = false;
                buttonShowMyAlbums.ForeColor = Color.FromKnownColor(KnownColor.AppWorkspace);
            }
            else
            {
                fetchItems(m_LoggedInUser.Albums.Where(album => album.Name != null),
                    listBoxAlbums,
                    album => $"{album.Name}: {album.Description}");
            }
        }

        private void fetchAbout()
        {
            fetchItems(new[]
            {
            m_LoggedInUser.Name != null ? $"Profile Name: {m_LoggedInUser.Name}" : null,
            m_LoggedInUser.Gender != null ? $"Gender: {m_LoggedInUser.Gender}" : null,
            m_LoggedInUser.Email != null ? $"Email: {m_LoggedInUser.Email}" : null,
            m_LoggedInUser.Birthday != null ? $"Birthday: {m_LoggedInUser.Birthday}" : null,
            m_LoggedInUser.Hometown != null ? $"Hometown: {m_LoggedInUser.Hometown}" : null,
            m_LoggedInUser.Location != null ? $"Current location: {m_LoggedInUser.Location}" : null,
            }.Where(item => item != null),
                       listBoxAbout,
                       item => item);
        }


        private void fetchGroups()
        {
            if (m_LoggedInUser.Groups.Count == 0)
            {
                listBoxGroups.Items.Add("You don't belong to any group");
                buttonShowMyGroups.Enabled = false;
                buttonShowMyGroups.ForeColor = Color.FromKnownColor(KnownColor.AppWorkspace);
            }
            else
            {
                fetchItems(m_LoggedInUser.Groups,
                       listBoxGroups,
                       group => group.Name);
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            m_RememberUser = false;
            IsLoggoutPressed = true;
            Close();
        }

        public void Connect()
        {
            Text = $"{m_LoggedInUser.Name}'s Profile";
            fetchUserInfo();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            UserDetails.UserDetailsInstance.UserToken = m_RememberUser ? m_LoginResult.AccessToken : null;
            UserDetails.UserDetailsInstance.SaveToFile();
        }

        private void listBoxPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Post selected = m_LoggedInUser.Posts[listBoxPosts.SelectedIndex];

            labelCurrentPostLikes.Text = string.Format(rs_LikesLabelString, 1);
            listBoxPostComments.DisplayMember = "Message";
            listBoxPostComments.DataSource = selected.Comments;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void labelCurrentPostLikes_Click(object sender, EventArgs e)
        {
            new FormObjectCollection<Post>(m_LoggedInUser.Posts).ShowDialog();
        }


        private void buttonShowMyFriends_Click(object sender, EventArgs e)
        {
            new FormObjectCollection<User>(m_LoggedInUser.Friends).ShowDialog();
        }

        private void buttonShowMyAlbums_Click(object sender, EventArgs e)
        {
            new FormObjectCollection<Album>(m_LoggedInUser.Albums).ShowDialog();

        }

        private void buttonShowAllPages_Click(object sender, EventArgs e)
        {
            new FormObjectCollection<Page>(m_LoggedInUser.LikedPages).ShowDialog();

        }

        private void buttonShowAllGroups_Click(object sender, EventArgs e)
        {
            new FormObjectCollection<Group>(m_LoggedInUser.Groups).ShowDialog();

        }

        private void buttonShowAllEvents_Click(object sender, EventArgs e)
        {
            new FormObjectCollection<Event>(m_LoggedInUser.Events).ShowDialog();
        }

        private void buttonShowComments_Click(object sender, EventArgs e)
        {
            //new FormObjectCollection<Comment>(m_LoggedInUser.Comments).ShowDialog();
        }


        private void buttonFindMatch_Click(object sender, EventArgs e)
        {
            new FormFindMatchSettings(m_LoggedInUser).ShowDialog();
        }

        private void buttonFindThingsInCommon_Click(object sender, EventArgs e)
        {
            new FormFindThingsInCommon(m_LoggedInUser.Friends, m_LoggedInUser).ShowDialog();
        }
    }
}
