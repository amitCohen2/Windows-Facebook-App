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

namespace BasicFacebookFeatures
{
    public partial class FormObjectCollection<T> : Form
    {
        private List<T> m_Items;
        private readonly FacebookObjectCollection<T> r_Collection;
        private readonly string r_Name;
        public T SelectedItemList 
        { 
            get 
            {
                int selectedIdx = listBoxCollectionItemsNames.SelectedIndex;
                if (selectedIdx != -1)
                {
                    return m_Items[selectedIdx];
                } 
                else
                {
                    return default(T);
                }
            } 
        }     
        public FormObjectCollection(FacebookObjectCollection<T> i_Collection)
        {
            r_Collection = i_Collection;
            m_Items = new List<T>(i_Collection.Count);
            r_Name = typeof(T).Name;
            InitializeComponent();
            initialComponent();
        }

        public FormObjectCollection()
        {
            InitializeComponent();
        }

        public void initialComponent()
        {
            Text = $"{r_Name}s list";
            PropertyInfo nameProperty = typeof(T).GetProperty("Name");

            foreach (T item in r_Collection)
            {
                string name = nameProperty.GetValue(item) is string ? 
                    nameProperty.GetValue(item) as string : 
                    noNameForItem();
                listBoxCollectionItemsNames.Items.Add(name);
                m_Items.Add(item);
            }

            if (r_Collection.Count == 0)
            {
                listBoxCollectionItemsNames.Items.Add(noNameForItem());
                setAllComponentsDisable();
            }

            buttonShowPictures.Visible = typeof(T) == typeof(Album);
        }

        private void setAllComponentsDisable()
        {
            textBoxSearchByName.Enabled = false;
            textBoxDescription.Enabled = false;
            listBoxCollectionItemsNames.Enabled = false;
            labelDescription.Enabled = false;
            roundPictureBox.Enabled = false;    
        }

        private string noNameForItem()
        {
            return $"No {r_Name}s to show";
        }

        protected virtual void listBoxCollectionItemsNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCollectionItemsNames.SelectedIndex != -1)
            {
                labelName.Text = typeof(T).GetProperty("Name").GetValue(m_Items[listBoxCollectionItemsNames.SelectedIndex]) as string;
                initalMainPictureValue(listBoxCollectionItemsNames.SelectedIndex);
                initialDescriptionValue(listBoxCollectionItemsNames.SelectedIndex);
            }
        }

        private void initalMainPictureValue(int i_SelectedIndex)
        {
            PropertyInfo pictureProperty = typeof(T).GetProperty("PictureNormalURL");

            if (pictureProperty != null)
            {
                roundPictureBox.LoadAsync(
                    pictureProperty.GetValue(m_Items[i_SelectedIndex]) as string);
            }
        }

        private void initialDescriptionValue(int i_indexInList)
        {
            PropertyInfo descriptionProperty = typeof(T).GetProperty("Description");

            if (descriptionProperty != null)
            {
                textBoxDescription.Text = descriptionProperty.GetValue(m_Items[i_indexInList]) as string;
            }
            else
            {
                textBoxDescription.Text = string.Empty;
            }
        }


        private void buttonShowPictures_Click(object sender, EventArgs e)
        {
            if (listBoxCollectionItemsNames.SelectedIndex != -1)
            {
                new FormObjectCollection<Photo>((m_Items[listBoxCollectionItemsNames.SelectedIndex] as Album).Photos).ShowDialog();
            }
        }

        private void textBoxSearchByName_TextChanged(object sender, EventArgs e)
        {
            TextBox textBoxSearch = sender as TextBox;

            if (textBoxSearch != null && textBoxSearch.Focused)
            {
                PropertyInfo nameProperty = typeof(T).GetProperty("Name");
                string currentName = null;

                listBoxCollectionItemsNames.Items.Clear();
                m_Items.Clear();
                foreach (T item in r_Collection)
                {
                    currentName = nameProperty.GetValue(item) is string ?
                        nameProperty.GetValue(item) as string :
                        noNameForItem();
                    if (currentName != null && currentName.ToUpper().Contains(textBoxSearchByName.Text.ToUpper()))
                    {
                        listBoxCollectionItemsNames.Items.Add(currentName);
                        m_Items.Add(item);
                    }
                }
            }
        }

        private void textBoxSearchByName_Leave(object sender, EventArgs e)
        {
            TextBox textBoxSearch = sender as TextBox;

            if (textBoxSearch != null && textBoxSearch.Text == string.Empty)
            {
                textBoxSearch.Text = "search";
            }
        }

        private void textBoxSearchByName_Enter(object sender, EventArgs e)
        {
            TextBox textBoxSearch = sender as TextBox;

            if (textBoxSearch != null && textBoxSearch.Text.Equals("search"))
            {
                textBoxSearch.Text = string.Empty;
            }
        }

        private void FormCollectionItem_Load(object sender, EventArgs e)
        {

        }

    }
}
