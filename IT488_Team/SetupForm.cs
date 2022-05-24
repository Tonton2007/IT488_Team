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
        private SqlConnection dbConnection;
        public SetupForm(SqlConnection sqlConnection)
        {
            dbConnection = sqlConnection;
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

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\SQLScripts\CreateTrackItDB.sql");
            string script = File.ReadAllText(path);

            dbConnection.Open();
            SqlCommand createCmd = new SqlCommand(script, dbConnection);
            createCmd.ExecuteNonQuery();

            path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\SQLScripts\CreateTrackItTable.sql");
            script = File.ReadAllText(path);

            createCmd = new SqlCommand(script, dbConnection);
            createCmd.ExecuteNonQuery();

            string sql = $"CREATE LOGIN {databaseUsername.Text} WITH PASSWORD = '{databasePassword.Text}';  USE TrackIT; CREATE USER {databaseUsername.Text} FOR LOGIN {databaseUsername.Text};" +
                $"USE TrackIT; GRANT SELECT, INSERT, UPDATE, DELETE ON Products TO {databaseUsername.Text}; ";
            SqlCommand loginCmd = new SqlCommand(sql, dbConnection);
            loginCmd.ExecuteNonQuery();

            MessageBox.Show("TrackIT database successfully setup!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }
    }
}
