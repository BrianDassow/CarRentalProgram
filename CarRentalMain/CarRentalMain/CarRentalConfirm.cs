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
    public partial class CarRentalConfirm : Form
    {
        User currentUser = new User();
        Car currentCar = new Car();

        public CarRentalConfirm(Car currentCar, User currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            this.currentCar = currentCar;

            rentalConfirmationTextBox.Text = "Confirmation Page for: " + currentUser.username + "\nLicense Num: " + currentUser.license 
                + "\n\nCar Information:\n\nMake: " + currentCar.make + "\nModel: " + currentCar.model + "\nYear: " + currentCar.year 
                + "\nSize: " + currentCar.size + "\nPrice: $" + currentCar.price + "/day";
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            List<Rental> allRentals = Program.getRentalsFromXMLFile();
            Rental registeredRental = new Rental();
            registeredRental.carid = currentCar.carid;
            registeredRental.customername = currentUser.username;
            allRentals.Add(registeredRental);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;

            using (XmlWriter writer = XmlWriter.Create("rentals.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Rentals");

                foreach (Rental rental in allRentals)
                {
                    writer.WriteStartElement("rental");
                    writer.WriteElementString("carid", rental.carid.ToString());
                    writer.WriteElementString("customername", rental.customername);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
            MessageBox.Show("You successfully rented: " + currentCar.year + " " + currentCar.make + " " + currentCar.model + " for $" + currentCar.price + "/day!");
            this.Close();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
