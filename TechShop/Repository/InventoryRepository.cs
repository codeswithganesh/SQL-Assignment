

using System.Data.SqlClient;
using TechShop.Model;

namespace TechShop.Repository
{
    internal class InventoryRepository : IInventoryRepository
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public InventoryRepository()
        {
            sqlConnection = new SqlConnection("Server=EDITH;Database=TechShop;Trusted_Connection=True");
            //sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
        }
        public string GetProduct(int id)
        {
            cmd.CommandText = @"select ProductName from Products join Inventory
                                on Products.ProductId=Inventory.ProductId
                                where InventoryId=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            object result = cmd.ExecuteScalar();
            sqlConnection.Close();
            if (result != null)
            {
                return (string)result;
            }
            else return null;
            

        }
        public int GetQuantityInStock(int id)
        {
            cmd.CommandText = "select QuantityInStock from Inventory where InventoryId=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            object result = cmd.ExecuteScalar();
            sqlConnection.Close();
            if (result != null)
            {
                return (int)result;
            }
            else return 0;
            
        }

        public int AddToInventory(Inventory inventory)
        {
            cmd.CommandText = "insert into Inventory values(@id,@productid,@stock,@stockupdated";
            cmd.Parameters.AddWithValue("@id", inventory.InventoryID);
            cmd.Parameters.AddWithValue("productid", inventory.Product.ProductID);
            cmd.Parameters.AddWithValue("stock", inventory.QuantityInStock);
            cmd.Parameters.AddWithValue("@stockupdated", inventory.LastStockUpdate);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return result;
            
        }

        public int RemoveFromInventory(int quantity)
        {
            cmd.CommandText = "delete from Inventory where QuantityInStock=@quantity";
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return result;
           

        }

        public int UpdateStockQuantity(int newQuantity, int inventoryid)
        {
            cmd.CommandText = "Update Inventory set QuantityInStock=@newstock where InventoryId=@id";
            cmd.Parameters.AddWithValue("@newstock", newQuantity);
            cmd.Parameters.AddWithValue("@id", inventoryid);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return result;
            

        }

        public int IsProductAvailable(int quantityToCheck)
        {
            cmd.CommandText = "select * from Inventory where QuantityInStock=@stock";
            cmd.Parameters.AddWithValue("@stock", quantityToCheck);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            object result = cmd.ExecuteScalar();
            sqlConnection.Close();
            if (result != null)
            {
                return (int)result;
            }
            else return 0;
            

        }

        public double GetInventoryValue()
        {
            cmd.CommandText = @"SELECT SUM(p.price * i.QuantityInStock) AS TotalValue
                                FROM Inventory i
                            JOIN Products p ON i.ProductID = p.ProductID;";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            object result = cmd.ExecuteScalar();
            sqlConnection.Close();
            if (result != null)
            {
                return (double)result;
            }
            else return 0;
            

        }

        public List<string> ListLowStockProducts(int threshold)
        {
            try
            {
                List<string> lowStockProducts = new List<string>();
                cmd.CommandText = "select ProductName from Products where ProductId in(select ProductId from Inventory where QuantityInStock< @thresold)";
                cmd.Parameters.AddWithValue("@thresold", threshold);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string product = reader.GetString(0);
                    lowStockProducts.Add(product);
                }
                return lowStockProducts;
            }
            finally
                {
                sqlConnection.Close();
            }
           
            

        }

        public List<string> ListOutOfStockProducts()
        {
            List<string> lowStockProducts = new List<string>();
            cmd.CommandText = "select ProductName from Products where ProductId in(select ProductId from Inventory where QuantityInStock=0)";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string product = reader.GetString(0);
                lowStockProducts.Add(product);
            }
            sqlConnection.Close();
            return lowStockProducts;
           
        }
        public List<string> ListAllProducts()
        {
            List<string> products = new List<string>();
            cmd.CommandText = "select ProductName,QuantityInStock from Products join Inventory on Products.ProductId=Inventory.ProductId";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string productName = reader.GetString(0);
                int quantityInStock = reader.GetInt32(1);
                string productInfo = productName + " " + quantityInStock.ToString();
                products.Add(productInfo);

            }
            sqlConnection.Close();
            return products;
            
        }




    }
}
