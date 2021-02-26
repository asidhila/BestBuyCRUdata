using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;

namespace BestBuyCRUDdata
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;
        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        // methods that I define here
        public IEnumerable<Product> GetAllProducts()
        {
            // dapper starts here
            // dapper extends ==> IDbConnection
            return _connection.Query<Product>("SELECT * FROM PRODUCTS;");
        }

        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO products(Name,Price,CategoryID)VALUES @productname,@price,@categoryID);",
                new { productname = name, price = price, categoryID = categoryID });
        }

        //bonus
        public void UpdateProductName(int productID,string updateName)
        {
            _connection.Execute("UPDATE products SET name = @updateName WHERE ProductID = @productID;",
                new {updateName = updateName,productID = productID});
        }

        //bonus
        //Delete data
 
            public void DeleteProduct(int productID)
            {
                _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID;",
                    new { productID = productID });

                _connection.Execute("DELETE FROM sales WHERE ProductID = @productID;",
                   new { productID = productID });

                _connection.Execute("DELETE FROM products WHERE ProductID = @productID;",
                   new { productID = productID });
            }

 
    }
}
