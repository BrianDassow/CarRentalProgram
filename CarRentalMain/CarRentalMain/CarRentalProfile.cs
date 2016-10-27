using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CarRentalProgram
{
    public partial class CarRentalProfile : Form
    {
        User currentUser = new User();
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
            // address1TextBox.Text.Replace(" ", string.Empty);
            bool failed = false;

            if (address1TextBox.Text.Replace(" ", string.Empty) == "")
            {
                addressLabel1.ForeColor = Color.Red;
                failed = true;
            }
            else
            {
                addressLabel1.ForeColor = Color.Black;
            }

            if (address2TextBox.Text.Replace(" ", string.Empty) == "")
            {
                addressLine2.ForeColor = Color.Red;
                failed = true;
            }
            else
            {
                addressLine2.ForeColor = Color.Black;
            }

            if (emailTextBox.Text.Replace(" ", string.Empty) == "")
            {
                emailLabel.ForeColor = Color.Red;
                failed = true;
            }
            else
            {
                emailLabel.ForeColor = Color.Black;
            }

            if (phoneTextBox.Text.Replace(" ", string.Empty) == "")
            {
                phoneLabel.ForeColor = Color.Red;
                failed = true;
            }
            else
            {
                phoneLabel.ForeColor = Color.Black;
            }

            if (driversLicenseTextBox.Text.Replace(" ", string.Empty) == "")
            {
                driversLicenseLabel.ForeColor = Color.Red;
                failed = true;
            }
            else
            {
                driversLicenseLabel.ForeColor = Color.Black;
            }

            if (creditCardTextBox.Text.Replace(" ", string.Empty) == "")
            {
                creditCardNumber.ForeColor = Color.Red;
                failed = true;
            }
            else
            {
                creditCardNumber.ForeColor = Color.Black;
            }

            List<User> allUsers = Program.getUsersFromXMLFile();
            User userToRemove = new User();

            foreach (User user in allUsers)
            {
                if (user.username == currentUser.username)
                {
                    userToRemove = user;
                }
            }
            allUsers.Remove(userToRemove);
            if (!failed)
            {
                User registeredUser = new User();
                registeredUser.username = currentUser.username;
                registeredUser.password = currentUser.password;
                registeredUser.power = currentUser.power;
                registeredUser.address1 = address1TextBox.Text;
                registeredUser.address2 = address2TextBox.Text;
                registeredUser.email = emailTextBox.Text;
                registeredUser.phone = phoneTextBox.Text;
                registeredUser.license = driversLicenseTextBox.Text;
                registeredUser.creditcard = creditCardTextBox.Text;

                allUsers.Add(registeredUser);
                currentUser = registeredUser;

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.NewLineOnAttributes = true;

                using (XmlWriter writer = XmlWriter.Create("users.xml", settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Users");

                    foreach (User user in allUsers)
                    {
                        writer.WriteStartElement("user");

                        writer.WriteElementString("username", user.username);
                        writer.WriteElementString("password", user.password);
                        writer.WriteElementString("power", user.power.ToString());
                        writer.WriteElementString("address1", user.address1);
                        writer.WriteElementString("address2", user.address2);
                        writer.WriteElementString("email", user.email);
                        writer.WriteElementString("phone", user.phone);
                        writer.WriteElementString("license", user.license);
                        writer.WriteElementString("creditcard", user.creditcard);

                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Close();
                }
                
                MessageBox.Show("User profile information successfully saved!");
                


            }
            else
            {
                MessageBox.Show("Please fill in the required information.");
            }



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
