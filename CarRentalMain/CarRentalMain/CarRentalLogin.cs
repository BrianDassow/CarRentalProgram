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
    public partial class CarRentalLogin : Form
    {
        public CarRentalLogin()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("LOLWHAT: " + usernameTextBox)
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
