using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalProject
{
    public partial class CarRentalMain : Form
    {
        int userPower = -1;
        string userName = "null";
        string[] userPowerString = {"Guest","Member", "Administrator"};
        public CarRentalMain(int userPower)
        {
            InitializeComponent();
            this.userPower = userPower;
            this.Text += " - Logged in as: " + userPowerString[userPower];
            if (userPower > 0)
            {
                this.Text += " " + userName;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your user power: " + userPowerString[userPower]);
            mainRichText.Text += addTextBox.Text + "\n";
            addTextBox.Text = "";
            addTextBox.Focus();// = true;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}

/*
 * A Car Rental System

This system will allow for three types of users: guests, members, and administrators. Guests will be able to browse location, availability, price, and model. Members will have their personal information stored (i.e. name, address, and credit card info.) and will have access to any specials. Finally, the administrator can change or update car models, prices, etc

Requirements:
A user can login. 
A user can view cars and prices that are available to be rented.
Administrators have CRUD functions on cars and prices (Create, Read, Update, Delete)


System shall be available 24/7.
System should provide an interface that is easily maneuverable for all users.
System should be down for maintenance no longer than 1 hour at a time.
*/