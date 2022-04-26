using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace IT488_Team.Models.DataLayer
{
    public class ProductDB
    {
        private string connectionString;

        public ProductDB(string connectionString)
        {
            this.connectionString = connectionString;
            EstablishConnection().Close();
        }
        private SqlConnection EstablishConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                return connection;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public bool TestConnection()
        {
            try
            {
                EstablishConnection();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Product GetProduct(string productCode)
        {
            string selectStatement = "SELECT ProductCode, Description, UnitPrice, OnHandQuantity, StorLocation " +
                                     "FROM Products " +
                                     "WHERE ProductCode = @ProductCode";
            
            SqlConnection sqlConnection = EstablishConnection();
            SqlCommand command = new SqlCommand();
            command.CommandText = selectStatement;
            command.Connection = sqlConnection;

            command.Parameters.AddWithValue("@ProductCode", productCode);


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

        public void AddProduct(Product product)
        {
            string insertStatement = "INSERT Products (ProductCode, Description, UnitPrice, OnHandQuantity, StorLocation) " +
                                     "VALUES (@ProductCode, @Description, @UnitPrice, @OnHandQuantity, @StorLocation)";
            
            SqlConnection sqlConnection = EstablishConnection();
            SqlCommand command = new SqlCommand();
            command.CommandText = insertStatement;
            command.Connection = sqlConnection;
            
            command.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            command.Parameters.AddWithValue("@Description", product.Description);
            command.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@OnHandQuantity", product.OnHandQuantity);
            command.Parameters.AddWithValue("@StorLocation", product.StorLocation);
            command.ExecuteNonQuery();
            
            sqlConnection.Close();
        }

        public bool UpdateProduct(Product oldProduct, Product newProduct)
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

            SqlConnection sqlConnection = EstablishConnection();
            SqlCommand command = new SqlCommand();
            command.CommandText = updateStatement;
            command.Connection = sqlConnection;

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

            int count = command.ExecuteNonQuery();

            sqlConnection.Close();

            return (count > 0);
        }

        public bool DeleteProduct(Product product)
        {
            string deleteStatement = "DELETE Products " +
                "WHERE ProductCode = @ProductCode " +
                "AND Description = @Description " +
                "AND UnitPrice = @UnitPrice " +
                "AND OnHandQuantity = @OnHandQuantity " +
                "AND StorLocation = @StorLocation ";

            SqlConnection sqlConnection = EstablishConnection();
            SqlCommand command = new SqlCommand();
            command.CommandText = deleteStatement;
            command.Connection = sqlConnection;

            command.Parameters.AddWithValue("@ProductCode", product.ProductCode);
            command.Parameters.AddWithValue("@Description", product.Description);
            command.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            command.Parameters.AddWithValue("@OnHandQuantity", product.OnHandQuantity);
            command.Parameters.AddWithValue("@StorLocation", product.StorLocation);
            
            int count = command.ExecuteNonQuery();

            sqlConnection.Close();

            return (count > 0);
        }
        //scan one at a time
        public void SimulateConcurrentUpdate(string productCode)
        {
            string updateStatement =
                "UPDATE Products " +
                "SET OnHandQuantity = OnHandQuantity - 1" +
                "WHERE ProductCode = @ProductCode";

            SqlConnection sqlConnection = EstablishConnection();
            SqlCommand command = new SqlCommand();
            command.CommandText = updateStatement;
            command.Connection = sqlConnection;

            command.Parameters.AddWithValue("@ProductCode", productCode);
            
            command.ExecuteNonQuery();

            sqlConnection.Close();
        }
        public bool LoginPassword(string theUsername, string thePassword)
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
        public DataSet displayInventory()
        {
            string viewInventory =
                            "SELECT ProductCode, Description, UnitPrice, OnHandQuantity, StorLocation FROM Products";

            SqlConnection sqlConnection = EstablishConnection();
            SqlCommand command = new SqlCommand();
            command.CommandText = viewInventory;
            command.Connection = sqlConnection;


            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataSet dataSet = new DataSet();
            try
            {
                sqlDataAdapter.Fill(dataSet, "Products");
                sqlConnection.Close();
                return dataSet;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
    

        
