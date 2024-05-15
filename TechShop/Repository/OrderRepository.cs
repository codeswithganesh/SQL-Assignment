using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Utility;

namespace TechShop.Repository
{
    internal class OrderRepository : IOrderRepository
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public OrderRepository()
        {
            sqlConnection = new SqlConnection("Server=EDITH;Database=TechShop;Trusted_Connection=True");
            //sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();

        }
        public int UpdateOrderStatus(int id, string ProductStatus)
        {
            cmd.CommandText = "Update Orders set status=@status where OrderId=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@status", ProductStatus);

            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int status = cmd.ExecuteNonQuery();
            return status;
        }

        public int CalculateTotalAmount(int orderid)
        {
            cmd.CommandText = "select sum(TotalAmount) from Orders where OrderId=@orderid;";
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            object total = cmd.ExecuteScalar();
            sqlConnection.Close();
            int result = 0;
            if (total != null)
            {
                result = Convert.ToInt32(total);
                return result;
            }
            else
            {
                return 0;
            }
        }

        public List<dynamic> GetOrderDetails(int orderid)
        {
            List<dynamic> orderlist = new List<dynamic>();
            cmd.CommandText = @"select o.OrderID,o.OrderDate,o.TotalAmount,ProductName,Quantity from Orders o join OrderDetails
                on o.OrderID=OrderDetails.OrderId join Products on Products.ProductId=OrderDetails.ProductId where o.OrderID=@id";
            cmd.Parameters.AddWithValue("@id", orderid);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            

            SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var orderDetails = new
                    {
                        OrderID = (int)reader["OrderID"],
                        OrderDate = (DateTime)reader["OrderDate"],
                        TotalAmount = (double)reader["TotalAmount"],
                        ProductName = (string)reader["ProductName"],
                        Quantity = (int)reader["Quantity"]
                    };

                    orderlist.Add(orderDetails);
                }


            sqlConnection.Close();
            return orderlist;
            
        }

        public bool CancelOrder(int orderid)
        {
            using (SqlConnection connection = new SqlConnection(DbConnUtil.GetConnectionString()))
        {
            // Delete the order from Orders table
            string deleteOrderQuery = "DELETE FROM Orders WHERE OrderID = @id;";
            using (SqlCommand deleteOrderCommand = new SqlCommand(deleteOrderQuery, connection))
            {
                deleteOrderCommand.Parameters.AddWithValue("@id", orderid);
                connection.Open();
                int rowsAffected = deleteOrderCommand.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    // Order not found or not deleted
                    return false;
                }
            }

            // Update inventory
            string updateInventoryQuery = @"
                UPDATE Inventory 
                SET QuantityInStock = QuantityInStock + 1 
                WHERE ProductId IN (
                    SELECT OrderDetails.ProductID 
                    FROM Orders 
                    JOIN OrderDetails ON Orders.OrderID = OrderDetails.OrderId 
                    WHERE Orders.OrderId = @id
                );";

            using (SqlCommand updateInventoryCommand = new SqlCommand(updateInventoryQuery, connection))
            {
                updateInventoryCommand.Parameters.AddWithValue("@id", orderid);
                int result = updateInventoryCommand.ExecuteNonQuery();
                if (result > 0)
                {
                    return true; // Order cancelled and inventory updated successfully
                }
            }
        }

        return false;


        }
    }
}
