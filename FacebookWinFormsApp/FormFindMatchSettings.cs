using FacebookLogic;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public partial class FormFindMatchSettings : Form
    {
        private User m_LoggedInUser;

        public FormFindMatchSettings(User i_LoggedInUser)
        {
            InitializeComponent();
            m_LoggedInUser = i_LoggedInUser;

        }


        private void buttonLetsGo_Click(object sender, EventArgs e)
        {   
            if (checkIfAllFieldsfilled())
            {
                PrefferedUsersDetails preferedUsersDetails = new PrefferedUsersDetails(
                    numericUpDownMinAge.Value,
                    numericUpDownMaxAge.Value,
                    checkBoxMale.Checked,
                    checkBoxFemale.Checked);

                new FormFindMatch(m_LoggedInUser, preferedUsersDetails).ShowDialog();
            }
            else
            {
                MessageBox.Show("You Dont Fill All the Details!\n" +
                    "Please ycheck you interrested check boxes and the max age.",
                    "Error!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }


        }
        private bool checkIfAllFieldsfilled()
        {
            return (checkBoxFemale.Checked || checkBoxMale.Checked) &&
                numericUpDownMaxAge.Value != 0;
        }

        private void numericUpDownMinAge_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDownMinAge = sender as NumericUpDown;

            if (numericUpDownMinAge.Value > this.numericUpDownMaxAge.Value)
            {
                this.numericUpDownMaxAge.Value = numericUpDownMinAge.Value;
            }
        }

        private void numericUpDownMaxAge_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDownMaxAge = sender as NumericUpDown;

            if (numericUpDownMaxAge.Value < this.numericUpDownMinAge.Value)
            {
                this.numericUpDownMinAge.Value = numericUpDownMaxAge.Value;
            }
        }
    }
}
