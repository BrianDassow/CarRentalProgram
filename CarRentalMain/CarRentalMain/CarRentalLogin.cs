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
using System.Xml.Serialization;
using System.IO;
using System.Collections;
using System.Xml.Linq;

namespace CarRentalProgram
{

    public partial class CarRentalLogin : Form
    {
        List<User> allUsers = new List<User>();

        public CarRentalLogin()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            allUsers = Program.getUsersFromXMLFile();

            for (int i = 0; i < allUsers.Count; i++)
            {
                if (usernameTextBox.Text.ToLower().Equals(allUsers[i].username) && passwordTextBox.Text.Equals(allUsers[i].password))
                {
                    this.Hide();
                    allUsers = Program.getUsersFromXMLFile();
                    CarRentalMain frm = new CarRentalMain(allUsers[i]);
                    frm.ShowDialog();
                    this.Close();
                }
                else if (i == allUsers.Count-1)
                {
                    MessageBox.Show("Wrong username and/or password.");
                }
            }
        }
            

        private void registerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            allUsers = Program.getUsersFromXMLFile();
            CarRentalRegister frm = new CarRentalRegister();
            frm.ShowDialog();
            this.Show();

        }

        private void guestButton_Click(object sender, EventArgs e)
        {
            //this.Hide();
          //  CarRentalMain frm = new CarRentalMain(0);
           // frm.ShowDialog();

           // this.Close();
        }

    }
}
