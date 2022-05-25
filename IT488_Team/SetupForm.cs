using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT488_Team
{
    public partial class SetupForm : Form
    {
        public SetupForm()
        {
            InitializeComponent();
        }

        private void createDBButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(databasePassword.Text))
            {
                MessageBox.Show("Missing password", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(databasePassword.Text))
            {
                MessageBox.Show("Missing username", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string script = "CREATE DATABASE TrackIT";

            SqlConnection dbConnection = new SqlConnection($"server={trackItServer.Text};Trusted_Connection=yes");
            dbConnection.Open();
            try
            {
                SqlCommand createCmd = new SqlCommand(script, dbConnection);
                createCmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("An error occured while creating the database. Please contact your system administrator.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            script = @"USE TrackIT; CREATE TABLE [dbo].[Products](
                [ProductCode][char](10) NOT NULL,
               [Description] [varchar](50) NOT NULL,
               [UnitPrice] [money] NOT NULL,
               [OnHandQuantity] [int] NOT NULL,
               [StorLocation] [varchar](50) NOT NULL,
            CONSTRAINT[PK_Products] PRIMARY KEY CLUSTERED
            (
              [ProductCode] ASC
            )WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON[PRIMARY]
            ) ON[PRIMARY]";

            try
            {
                SqlCommand createCmd = new SqlCommand(script, dbConnection);
                createCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("An error occured while creating the TrackIT tables. Please contact your system administrator.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string sql = $"CREATE LOGIN {databaseUsername.Text} WITH PASSWORD = '{databasePassword.Text}';  USE TrackIT; CREATE USER {databaseUsername.Text} FOR LOGIN {databaseUsername.Text};" +
                $"USE TrackIT; GRANT SELECT, INSERT, UPDATE, DELETE ON Products TO {databaseUsername.Text}; ";

            try
            {
                SqlCommand loginCmd = new SqlCommand(sql, dbConnection);
                loginCmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("An error occured while creating the default username. Please contact your system administrator.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("TrackIT database successfully setup!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}
