using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalProgram
{
    public partial class CarRentalProfile : Form
    {
        User currentUser = new User();
        public CarRentalProfile(User user)
        {
            InitializeComponent();
            currentUser = user;
            usernameTextBox.Text = char.ToUpper(currentUser.username[0]) + currentUser.username.Substring(1);
            address1TextBox.Text = currentUser.address1;
            address2TextBox.Text = currentUser.address2;
            emailTextBox.Text = currentUser.email;
            phoneTextBox.Text = currentUser.phone;
            driversLicenseTextBox.Text = currentUser.license;
            creditCardTextBox.Text = currentUser.creditcard;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
