using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT488_Team.Models.DataLayer
{
    public class Product
    {
        public string ProductCode { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int OnHandQuantity { get; set; }
    }
}
