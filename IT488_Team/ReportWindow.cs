using IT488_Team.Models.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace IT488_Team
{
    public partial class ReportWindow : Form
    {
        private ProductDB ProductDB;

        public ReportWindow(ProductDB productDB)
        {
            this.ProductDB = productDB;
            InitializeComponent();
            loadDefaultGraph();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void inventoryManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmStoreInventory storInventory = new frmStoreInventory(this.ProductDB);
            storInventory.ShowDialog();
        }

        private void loadDefaultGraph()
        {
            var inventory = ProductDB.displayInventory();
            DataTable products = inventory.Tables["Products"];

            chart1.DataBindTable(products.DefaultView);
        }
    }
}
