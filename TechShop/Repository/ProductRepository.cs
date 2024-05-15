using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;
using TechShop.Service;

namespace TechShop.Repository
{
    internal class ProductRepository:IProductsRepository
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public ProductRepository()
        {
            sqlConnection = new SqlConnection("Server=EDITH;Database=TechShop;Trusted_Connection=True");
            //sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
        }
        List<Products> products = new List<Products>();
        public List<Products> GetProductDetails()
        {
            
            cmd.CommandText = "select * from Products;";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Products product = new Products();
                product.ProductID = (int)reader["ProductID"];
                product.ProductName = (string)reader["ProductName"];
                product.Description = (string)reader["Description"];
                product.Price = (double)reader["Price"];
                product.Category = (string)reader["Category"];

                products.Add(product);

            }
            sqlConnection.Close();
            return products;
            
        }
        public int UpdateProductInfo(Products product)
        {
            int status = 0;
            if (IsValidProductInfo(product.ProductName, product.Price))
            {
                cmd.CommandText = "Update Products set Description=@desc,price=@price where ProductId=@id";
                cmd.Parameters.AddWithValue("@id", product.ProductID);
                cmd.Parameters.AddWithValue("@desc", product.Description);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                 status = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return status;

            }
            else
            {
                throw new InvalidDataException("Invalid Product Information");
            }
            return status;
           
        }
        public bool IsValidProductInfo(string productName, double price)
        {
            return !string.IsNullOrWhiteSpace(productName) && price >= 0;
        }

        public int IsProductInStock(int productid)
        {
            
             cmd.CommandText = "select QuantityInStock from Inventory where ProductId=@id";
            cmd.Parameters.AddWithValue("@id",productid);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            object result = cmd.ExecuteScalar();
            int productstock = 0;
            if (result != null)
            {
                productstock = Convert.ToInt32(result);
            }
            sqlConnection.Close();
            return productstock;

        }




       
    }
}
