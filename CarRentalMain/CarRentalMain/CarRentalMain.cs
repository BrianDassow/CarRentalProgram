using System;
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

        string[] userPowerString = {"Guest","Member", "Administrator"};
        public CarRentalMain(int userPower)
        {
            InitializeComponent();

            this.Text += " - Logged in as: " + userPowerString[userPower];
            if (userPower > 0)
            {
                this.Text += " " + char.ToUpper(user.username[0]) + user.username.Substring(1);
            }

            FileStream fs = new FileStream("cars.xml", FileMode.Open);
            XmlReader reader = XmlReader.Create(fs);
            XDocument doc = XDocument.Load(reader);

            var allCarsFromXML = (from s in doc.Descendants("car")
                                  select new
                                  {
                                      make = s.Element("make").Value,
                                      model = s.Element("model").Value,
                                      year = int.Parse(s.Element("year").Value),
                                      price = s.Element("price").Value
                                  }).ToList();

            List<Car> allCars = new List<Car>();

            for (int i = 0; i < allCarsFromXML.Count; i++)
            {
                Car car = new Car();
                car.make = allCarsFromXML[i].make;
                car.model = allCarsFromXML[i].model;
                car.year = allCarsFromXML[i].year;
                car.price = allCarsFromXML[i].price;
                allCars.Add(car);
            }

            fs.Close();
            reader.Close();

            for (int i = 0; i < allCars.Count; i++)
            {
                Console.WriteLine("Make: " + allCars[i].make + " Model: " + allCars[i].model + " Year: " + allCars[i].year + " Price: " + allCars[i].price);
                carBindingSource.Add(allCars[i]);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {

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