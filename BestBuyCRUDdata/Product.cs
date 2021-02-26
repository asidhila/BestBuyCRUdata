using System;
using System.Collections.Generic;
using System.Text;

namespace BestBuyCRUDdata
{
     public class Product
    {
        // each column from the products table will be a property
        public int ProductionID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public int OnSale { get; set; }
        public string StockLevel { get; set; }
    }
}
