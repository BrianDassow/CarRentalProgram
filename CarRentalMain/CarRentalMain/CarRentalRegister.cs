using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CarRentalProgram
{
    public partial class CarRentalRegister : Form
    {
        public CarRentalRegister()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            List<User> allUsers = Program.getUsersFromXMLFile();

            bool made = true;
            for (int i = 0; i < allUsers.Count; i++)
            {
                if (usernameTextBox.Text.ToLower() == allUsers[i].username)
                {
                    made = false;
                    MessageBox.Show("This user already exists!");
                    break;
                }
                else if (usernameTextBox.Text.ToLower() == "")
                {
                    made = false;
                    MessageBox.Show("Please enter a username!");
                    break;
                }
                else if (passwordTextBox.Text == "")
                {
                    made = false;
                    MessageBox.Show("Please enter a password!");
                    break;
                }
            }

            if(made)
            {
                User registeredUser = new User();
                registeredUser.username = usernameTextBox.Text.ToLower();
                registeredUser.password = passwordTextBox.Text;
                registeredUser.power = 1;

                allUsers.Add(registeredUser);

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
                        writer.WriteElementString("address1", "null");
                        writer.WriteElementString("address2", "null");
                        writer.WriteElementString("email", "null");
                        writer.WriteElementString("phone", "null");
                        writer.WriteElementString("license", "null");
                        writer.WriteElementString("creditcard", "null");

                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Close();
                }
                this.Close();
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
