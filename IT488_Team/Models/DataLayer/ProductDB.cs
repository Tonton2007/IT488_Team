using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace IT488_Team.Models.DataLayer
{
    public static class ProductDB
    {
        public static Product GetProduct(string productCode)
        {
            string selectStatement = "SELECT ProductCode, Description, UnitPrice, OnHandQuantity, StorLocation " +
                                     "FROM Products " +
                                     "WHERE ProductCode = @ProductCode";
            SqlConnection sqlConnection = new SqlConnection(TrackITDB.ConnectionString);
            using SqlConnection connection = sqlConnection;



            using SqlCommand command = new SqlCommand(selectStatement, connection);


            command.Parameters.AddWithValue("@ProductCode", productCode);
            connection.Open();

            Product product = null;   // default value
            using SqlDataReader reader = command.ExecuteReader(
                CommandBehavior.SingleRow & CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                product = new Product()
                {
                    ProductCode = reader["ProductCode"].ToString(),
                    StorLocation = reader["StorLocation"].ToString(),
                    Description = reader["Description"].ToString(),
                    UnitPrice = (decimal)reader["UnitPrice"],
                    OnHandQuantity = (int)reader["OnHandQuantity"]
                };
            }
            return product;
        }

        public static void AddProduct(Product product)
        {
            string insertStatement = "INSERT Products (ProductCode, Description, UnitPrice, OnHandQuantity, StorLocation) " +
                                     "VALUES (@ProductCode, @Description, @UnitPrice, @OnHandQuantity, @StorLocation)";
            using SqlConnection connection = new SqlConnection(TrackITDB.ConnectionString);
            using SqlCommand command = new SqlCommand(insertStatement, connection);
            command.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            command.Parameters.AddWithValue("@Description", product.Description);
            command.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@OnHandQuantity", product.OnHandQuantity);
            command.Parameters.AddWithValue("@StorLocation", product.StorLocation);
            connection.Open();
            command.ExecuteNonQuery();
        }

        public static bool UpdateProduct(Product oldProduct, Product newProduct)
        {
            string updateStatement = "UPDATE Products SET " +
                "ProductCode = @NewProductCode, " +
                "Description = @NewDescription, " +
                "UnitPrice = @NewUnitPrice, " +
                "OnHandQuantity = @NewOnHandQuantity, " +
                "StorLocation = @NewStorLocation " +
                "WHERE ProductCode = @OldProductCode " +
                "AND Description = @OldDescription " +
                "AND UnitPrice = @OldUnitPrice " +
                "AND OnHandQuantity = @OldOnHandQuantity " +
                "AND StorLocation= @OldStorLocation";
            using SqlConnection connection = new SqlConnection(TrackITDB.ConnectionString);
            using SqlCommand command = new SqlCommand(updateStatement, connection);
            command.Parameters.AddWithValue("@NewProductCode", newProduct.ProductCode);
            command.Parameters.AddWithValue("@NewDescription", newProduct.Description);
            command.Parameters.AddWithValue("@NewUnitPrice", newProduct.UnitPrice);
            command.Parameters.AddWithValue("@NewOnHandQuantity", newProduct.OnHandQuantity);
            command.Parameters.AddWithValue("@NewStorLocation", newProduct.StorLocation);

            command.Parameters.AddWithValue("@OldStorLocation", oldProduct.StorLocation);
            command.Parameters.AddWithValue("@OldProductCode", oldProduct.ProductCode);
            command.Parameters.AddWithValue("@OldDescription", oldProduct.Description);
            command.Parameters.AddWithValue("@OldUnitPrice", oldProduct.UnitPrice);
            command.Parameters.AddWithValue("@OldOnHandQuantity", oldProduct.OnHandQuantity);
            connection.Open();
            int count = command.ExecuteNonQuery();

            return (count > 0);
        }

        public static bool DeleteProduct(Product product)
        {
            string deleteStatement = "DELETE Products " +
                "WHERE ProductCode = @ProductCode " +
                "AND Description = @Description " +
                "AND UnitPrice = @UnitPrice " +
                "AND OnHandQuantity = @OnHandQuantity " +
                "AND StorLocation = @StorLocation ";
            using SqlConnection connection = new SqlConnection(TrackITDB.ConnectionString);
            using SqlCommand command = new SqlCommand(deleteStatement, connection);
            command.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            command.Parameters.AddWithValue("@Description", product.Description);
            command.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@OnHandQuantity", product.OnHandQuantity);
            command.Parameters.AddWithValue("@StorLocation", product.StorLocation);
            connection.Open();
            int count = command.ExecuteNonQuery();

            return (count > 0);
        }
        //scan one at a time
        public static void SimulateConcurrentUpdate(string productCode)
        {
            string updateStatement =
                "UPDATE Products " +
                "SET OnHandQuantity = OnHandQuantity - 1" +
                "WHERE ProductCode = @ProductCode";
            using SqlConnection connection = new SqlConnection(TrackITDB.ConnectionString);
            using SqlCommand command = new SqlCommand(updateStatement, connection);
            command.Parameters.AddWithValue("@ProductCode", productCode);
            connection.Open();
            command.ExecuteNonQuery();
        }
        public static bool LoginPassword(string theUsername, string thePassword)
        {
            var datasource = @"DESKTOP-JOLUDPU\SQLEXPRESS"; 
            var database = "TrackIT";
            string updateStatement =
             @"Data Source=" + datasource + ";Initial Catalog=" + database + 
             ";Persist Security Info=True;User ID=" + theUsername + ";Password=" + thePassword;

            SqlConnection command = new SqlConnection(updateStatement);

            try
            {
                command.Open();
                return true;
            }
            catch 
            {
                return false;
            }


        }
        public static DataTable  displayInvtory()
        {
            string viewInventory =
                            "SELECT ProductCode, Description, UnitPrice, OnHandQuantity, StorLocation FROM Products";
            using SqlConnection connection = new SqlConnection(TrackITDB.ConnectionString);
            {
                connection.Open();
                using SqlDataAdapter command = new SqlDataAdapter(viewInventory, connection);
                DataTable dt = new DataTable();
                command.Fill(dt);
                return dt;
                

            }
            //frmStoreInventory.dataInventoryView1.DataSource = dt;
            //dataGridView1.DataMember = "ProductCode, Description, UnitPrice, OnHandQuantity, StorLocation";

        }
    }
}
    

        
