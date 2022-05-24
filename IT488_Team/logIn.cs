using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using IT488_Team.Models.DataLayer;

namespace IT488_Team
{
    public partial class logIn : Form
    {
        private string connectionString;
        public ProductDB ProductDB;
        public logIn()
        {
            InitializeComponent();
            ServerTextBox.Text = ConfigurationManager.AppSettings["defaultServer"];

            if(!CheckDatabaseExists(ServerTextBox.Text))
            {
                var setupForm = new SetupForm(new SqlConnection($"server={ServerTextBox.Text};Trusted_Connection=yes"));
                setupForm.Show();
            }
        }

        public bool InitializeDBConnection(string username, string password, string server)
        {
            try
            {
                this.connectionString = $@"Data Source={server};Initial Catalog=TrackIT;User Id={username};Password={password}";
                ProductDB = new ProductDB(this.connectionString);
            }
            catch (Exception e)
            {
                throw e;
            }

            return ProductDB.TestConnection();
        }

        private void OkLogin_Click(object sender, EventArgs e)
        {
            string username = userName.Text;
            string password = txtPassword.Text;
            string server = ServerTextBox.Text;

            if (username == "")
            {
                MessageBox.Show("Please enter your username.");
            }
            else if (password == "")
            {
                MessageBox.Show("Please enter your password.");
            }
            else if (server == "")
            {
                MessageBox.Show("Please enter your server name.");
            }
            else
            {
                try
                {
                    InitializeDBConnection(username, password, server);
                    this.Visible = false;
                    frmStoreInventory storInventory = new frmStoreInventory(this.ProductDB);
                    storInventory.ShowDialog();
                }
                catch
                {
                    MessageBox.Show("Not a valid username, password, or server.");
                }
            }
        }

        private void loginExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private bool CheckDatabaseExists(string server)
        {
            string sqlCreateDBQuery;
            bool result = false;

            try
            {
                var tmpConn = new SqlConnection($"server={server};Trusted_Connection=yes");

                sqlCreateDBQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name = 'TrackITT'");
        
                using (tmpConn)
                {
                    using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, tmpConn))
                    {
                        tmpConn.Open();

                        object resultObj = sqlCmd.ExecuteScalar();

                        int databaseID = 0;

                        if (resultObj != null)
                        {
                            int.TryParse(resultObj.ToString(), out databaseID);
                        }

                        tmpConn.Close();

                        result = (databaseID > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
    }
}
