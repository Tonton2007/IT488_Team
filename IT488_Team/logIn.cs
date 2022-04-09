using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using IT488_Team.Models.DataLayer;

namespace IT488_Team
{
    public partial class logIn : Form
    {
        public logIn()
        {
            InitializeComponent();
        }


        public static string username = "";
        public static string password = "";

        private void OkLogin_Click(object sender, EventArgs e)
        {
            username = userName.Text;
            password = txtPassword.Text;
            if (username == "" || password == "")
            {
                MessageBox.Show("Please enter your username and password.");
            }
            else
            {

                
                string thisUsername = username;
                string thisPassword = password;
                

                if (ProductDB.LoginPassword(thisUsername, thisPassword) == true)
                {
                    frmStoreInventory storInventory = new frmStoreInventory();
                    storInventory.ShowDialog();
                                                               
                }
               else
                {
                    MessageBox.Show("Not a valid username and password.");
                }

            }
        }

        private void loginExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
