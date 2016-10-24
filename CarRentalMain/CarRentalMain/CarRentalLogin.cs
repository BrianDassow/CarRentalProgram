using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections;
using System.Xml.Linq;

namespace CarRentalProgram
{

    public partial class CarRentalLogin : Form
    {
        public CarRentalLogin()
        {
            InitializeComponent();

            FileStream fs = new FileStream("users.xml", FileMode.Open);
            XmlReader reader = XmlReader.Create(fs);
            XDocument doc = XDocument.Load(reader);

            var allUsersFromXML = (from s in doc.Descendants("user") select new {
                               username = s.Element("username").Value,
                               password = s.Element("password").Value,
                               power = int.Parse(s.Element("power").Value)
                           }).ToList();

            List<User> allUsers = new List<User>();

            for(int i = 0; i < allUsersFromXML.Count; i++)
            {
                User user = new User();
                user.username = allUsersFromXML[i].username;
                user.password = allUsersFromXML[i].password;
                user.power = allUsersFromXML[i].power;
                allUsers.Add(user);
                //MessageBox.Show("LOL: " + allUsers[i].Id);
            }

            reader.Close();
            
            for(int i = 0; i < allUsers.Count; i++)
            {
// MessageBox.Show("LOL");
                Console.WriteLine("Username: " + allUsers[i].username + " password: " + allUsers[i].password + " power: " + allUsers[i].power);
            }




        }
        
        private void loginButton_Click(object sender, EventArgs e)
        {



            // if (usernameTextBox.Text.Equals("admin") && passwordTextBox.Text.Equals("password"))
            // {
            this.Hide();
                CarRentalMain frm = new CarRentalMain(1);
                frm.ShowDialog();

                //   Application.Run(new CarRentalLogin());
               // myForm.ShowDialog();
                this.Close();

          //  }
         //   else
         //   {
         //       MessageBox.Show("Wrong username and/or password.");
         //   }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            CarRentalMain frm = new CarRentalMain(1);
            frm.ShowDialog();

        }

        private void guestButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            CarRentalMain frm = new CarRentalMain(0);
            frm.ShowDialog();

            //   Application.Run(new CarRentalLogin());
            // myForm.ShowDialog();
            this.Close();
        }
    }
}
