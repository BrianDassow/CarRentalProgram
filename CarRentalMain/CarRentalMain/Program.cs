using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace CarRentalProgram
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CarRentalLogin());
        }
        public static List<Rental> getRentalsFromXMLFile()
        {
            FileStream fs = new FileStream("rentals.xml", FileMode.Open);
            XmlReader reader = XmlReader.Create(fs);
            XDocument doc = XDocument.Load(reader);




            var allRentalsFromXML = (from s in doc.Descendants("rental")
                                   select new
                                   {
                                       carid = int.Parse(s.Element("carid").Value),
                                       customername = s.Element("customername").Value
                                   }).ToList();

            List<Rental> allRentals = new List<Rental>();

            for (int i = 0; i < allRentalsFromXML.Count; i++)
            {
                Rental rental = new Rental();
                rental.carid = allRentalsFromXML[i].carid;
                rental.customername = allRentalsFromXML[i].customername;
                allRentals.Add(rental);
            }

            reader.Close();
            fs.Close();
            return allRentals;
        }

        public static List<User> getUsersFromXMLFile()
        {



            FileStream fs = new FileStream("users.xml", FileMode.Open);
            XmlReader reader = XmlReader.Create(fs);
            XDocument doc = XDocument.Load(reader);




            var allUsersFromXML = (from s in doc.Descendants("user")
                                   select new
                                   {
                                       username = s.Element("username").Value,
                                       password = s.Element("password").Value,
                                       power = int.Parse(s.Element("power").Value),
                                       address1 = s.Element("address1").Value,
                                       address2 = s.Element("address2").Value,
                                       email = s.Element("email").Value,
                                       phone = s.Element("phone").Value,
                                       license = s.Element("license").Value,
                                       creditcard = s.Element("creditcard").Value
                                   }).ToList();

            List<User> allUsers = new List<User>();

            for (int i = 0; i < allUsersFromXML.Count; i++)
            {
                User user = new User();
                user.username = allUsersFromXML[i].username;
                user.password = allUsersFromXML[i].password;
                user.power = allUsersFromXML[i].power;
                user.address1 = allUsersFromXML[i].address1;
                user.address2 = allUsersFromXML[i].address2;
                user.email = allUsersFromXML[i].email;
                user.phone = allUsersFromXML[i].phone;
                user.license = allUsersFromXML[i].license;
                user.creditcard = allUsersFromXML[i].creditcard;
                allUsers.Add(user);
            }

            reader.Close();
            fs.Close();

            return allUsers;
        }
        public static List<Car> getCarsFromXMLFile()
        {
            FileStream fs = new FileStream("cars.xml", FileMode.Open);
            XmlReader reader = XmlReader.Create(fs);
            XDocument doc = XDocument.Load(reader);

            var allCarsFromXML = (from s in doc.Descendants("car")
                                  select new
                                  {
                                      carid = int.Parse(s.Element("carid").Value),
                                      make = s.Element("make").Value,
                                      model = s.Element("model").Value,
                                      year = int.Parse(s.Element("year").Value),
                                      price = s.Element("price").Value
                                  }).ToList();


            List<Car> allCars = new List<Car>();

            for (int i = 0; i < allCarsFromXML.Count; i++)
            {
                Car car = new Car();
                car.carid = allCarsFromXML[i].carid;
                car.make = allCarsFromXML[i].make;
                car.model = allCarsFromXML[i].model;
                car.year = allCarsFromXML[i].year;
                car.price = allCarsFromXML[i].price;
                allCars.Add(car);
            }

            fs.Close();
            reader.Close();

            return allCars;
        }
    }
}