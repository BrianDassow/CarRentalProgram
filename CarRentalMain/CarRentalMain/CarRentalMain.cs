﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace CarRentalProgram
{
    public partial class CarRentalMain : Form
    {
        List<Car> allCars = new List<Car>();
        List<User> allUsers = new List<User>();
        User currentUser = new User();

        string[] userPowerString = {"Guest","Member", "Administrator"};
        public CarRentalMain(User user)
        {
            InitializeComponent();

            allUsers = Program.getUsersFromXMLFile();
            currentUser = user;

            this.Text += " - Logged in as: " + userPowerString[user.power];
            if (user.power > 0)
            {
                this.Text += " " + char.ToUpper(user.username[0]) + user.username.Substring(1);
            }

            allCars = Program.getCarsFromXMLFile();
            for (int i = 0; i < allCars.Count; i++)
            {
                carBindingSource.Add(allCars[i]);
            }

            carGridView.RowTemplate.Height = 50;
            //carGridView.;
        }


        private void exitButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void profileButton_Click(object sender, EventArgs e)
        {
            CarRentalProfile frm = new CarRentalProfile(currentUser);
            frm.ShowDialog();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            CarRentalConfirm frm = new CarRentalConfirm((Car)carBindingSource[carGridView.CurrentCell.RowIndex], currentUser);
            frm.ShowDialog();
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