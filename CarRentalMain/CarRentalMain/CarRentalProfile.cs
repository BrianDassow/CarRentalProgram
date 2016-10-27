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
        List<Rental> allRentals;
        List<Car> carsAssociatedWithRentals;
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
            List<Rental> userSpecificRentals = Program.getUserSpecificRentalsFromXMLFile(currentUser);
            carsAssociatedWithRentals = Program.matchRentalsToCars(userSpecificRentals);
            carRentalBindingSource.DataSource = carsAssociatedWithRentals;
            userRentalComboBox.DataSource = carRentalBindingSource.DataSource;
            userRentalComboBox.DisplayMember = "make";

            if (currentUser.address1 == "null")
            {
                address1TextBox.Text = "";
            }
            if (currentUser.address2 == "null")
            {
                address2TextBox.Text = "";
            }
            if (currentUser.email == "null")
            {
                emailTextBox.Text = "";
            }
            if (currentUser.phone == "null")
            {
                phoneTextBox.Text = "";
            }
            if (currentUser.license == "null")
            {
                driversLicenseTextBox.Text = "";
            }
            if (currentUser.creditcard == "null")
            {
                creditCardTextBox.Text = "";
            }
        }
            
        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void userRentalComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Car x = carsAssociatedWithRentals.ElementAt<Car>(userRentalComboBox.SelectedIndex);
          
                    //Console.WriteLine("Found a match!" + allCars.ElementAt<Car>(i).model);
                    //Car foundCar = allCars.ElementAt<Car>(i);
                    rentalCarMakeLabel.Text = x.make;
                    rentalCarModelLabel.Text = x.model;
                    rentalCarPrice.Text = "$" + x.price.ToString() + " per day";
                    rentalCarSize.Text = x.size;
                    rentalCarYear.Text = x.year.ToString();
                    //carName.Refresh();
        }
    }
}
