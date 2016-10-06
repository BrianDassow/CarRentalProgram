using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalMain
{
    public partial class CarRentalMain : Form
    {
        public CarRentalMain()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("What car would you like to add?");
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
