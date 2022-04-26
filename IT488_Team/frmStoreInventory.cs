using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using IT488_Team.Models.DataLayer;
using System.Data;

namespace IT488_Team
{
    public partial class frmStoreInventory : Form
    {
        private ProductDB ProductDB;
        public frmStoreInventory(ProductDB productDB)
        {
            InitializeComponent();
            this.ProductDB = productDB;
        }

        Product selectedProduct;

        private void btnGetProduct_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                try
                {
                    string productCode = txtProductCode.Text;
                    selectedProduct = ProductDB.GetProduct(productCode);
                    if (selectedProduct == null)
                    {
                        MessageBox.Show("No product found with this code. " +
                            "Please try again.", "Product Not Found");
                            ClearControls();
                        btnDelete.Enabled = false;
                        btnModify.Enabled = false;

                    }
                    else
                    {
                            DisplayProduct();
                            btnDelete.Enabled = true;
                            btnModify.Enabled = true;
                    }
                }
                catch (SqlException ex)
                {
                    this.HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    this.HandleGeneralError(ex);
                }
            }
        }

        private bool IsValidData()
        {
            bool success = true;
            string errorMessage = "";
            errorMessage = Validator.IsPresent(txtProductCode.Text, txtProductCode.ToString());
            if (errorMessage != "")
            {
                success = false;
                MessageBox.Show(errorMessage, "Entry Error");
                txtProductCode.Focus();
            }
            return success;
        }

        private void DisplayProduct()
        {
            txtProductCode.Text = selectedProduct.ProductCode;
            txtLocation.Text = selectedProduct.StorLocation;
            txtDescription.Text = selectedProduct.Description;
            txtUnitPrice.Text = selectedProduct.UnitPrice.ToString("c");
            txtOnHand.Text = selectedProduct.OnHandQuantity.ToString();

            txtProductCode.Focus();
        }

        private void ClearControls()
        {
            txtProductCode.Text = "";
            txtLocation.Text = "";
            txtDescription.Text = "";
            txtUnitPrice.Text = "";
            txtOnHand.Text = "";
            txtProductCode.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModify addModifyForm = new frmAddModify
            {
                AddProduct = true
            };
            DialogResult result = addModifyForm.ShowDialog();

            // Determine if the OK button was clicked on the dialog box.

            if (result == DialogResult.OK)
            {
                try
                {
                    selectedProduct = addModifyForm.Product;
                    ProductDB.AddProduct(selectedProduct);
                    this.DisplayProduct();
                }
                catch (SqlException ex)
                {
                    this.HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    this.HandleGeneralError(ex);
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            Product oldProduct = this.CloneProduct(); //saves the old values
            frmAddModify addModifyForm = new frmAddModify
            {
                AddProduct = false,
                Product = selectedProduct
            };
            DialogResult result = addModifyForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    selectedProduct = addModifyForm.Product;
                    if (ProductDB.UpdateProduct(oldProduct, selectedProduct))
                    {
                        this.DisplayProduct();
                    }
                    else
                    {
                        this.HandleConcurrencyConflict();
                    }
                }
                catch (SqlException ex)
                {
                    this.HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    this.HandleGeneralError(ex);
                }
            }
        }

        private Product CloneProduct()
        {
                return new Product()
                {
                    ProductCode = selectedProduct.ProductCode,
                    StorLocation = selectedProduct.StorLocation,
                    Description = selectedProduct.Description,
                    UnitPrice = selectedProduct.UnitPrice,
                    OnHandQuantity = selectedProduct.OnHandQuantity
                };
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            var desc = selectedProduct.Description;
            DialogResult result =
                MessageBox.Show($"Delete {desc}?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (ProductDB.DeleteProduct(selectedProduct))
                    {
                        this.ClearControls();
                    }
                    else
                    {
                        this.HandleConcurrencyConflict();
                    }
                }
                catch (SqlException ex)
                {
                    this.HandleDatabaseError(ex);
                }
                catch (Exception ex)
                {
                    this.HandleGeneralError(ex);
                }
            }
        }

        private void HandleConcurrencyConflict()
        {
            selectedProduct = ProductDB.GetProduct(selectedProduct.ProductCode); // reload
            if (selectedProduct == null)
            {
                MessageBox.Show("Another user has deleted that product.",
                    "Concurrency Error");
                this.ClearControls();
            }
            else
            {
                string message = "Another user has updated that product.\n" +
                    "The current database values will be displayed.";
                MessageBox.Show(message, "Concurrency Error");
                this.DisplayProduct();
            }
        }


        private void HandleDatabaseError(SqlException ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }

        private void HandleGeneralError(Exception ex)
        {
            MessageBox.Show(ex.Message, ex.GetType().ToString());
        }

        private void frmStoreInventory_Load(object sender, EventArgs e)
        {

        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet productData = ProductDB.displayInventory();
                dataInventoryView1.DataSource = productData.Tables["Products"].DefaultView;
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void reportingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ReportWindow reportWindow = new ReportWindow(this.ProductDB);
            reportWindow.ShowDialog();
        }
    }
}