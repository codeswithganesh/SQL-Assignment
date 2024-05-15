

using System.Data.SqlClient;
using System.Numerics;
using TechShop.Model;

namespace TechShop.Repository
{
    internal class OrderDetailsRepository:IOrderDetailsRepository
    {
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public OrderDetailsRepository()
        {
            sqlConnection = new SqlConnection("Server=EDITH;Database=TechShop;Trusted_Connection=True");
            //sqlConnection = new SqlConnection(DbConnUtil.GetConnectionString());
            cmd = new SqlCommand();
        }
        public List<OrderDetails> GetOrderDetailInfo()
        {
            List<OrderDetails> LOrderDetails = new List<OrderDetails>();
            cmd.CommandText = "select * from OrderDetails";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                OrderDetails od = new OrderDetails();
                od.OrderDetailId = (int)reader["OrderDetailId"];
                od.Order.OrderID = (int)reader["OrderId"];
                od.Product.ProductName = (string)reader["ProductName"];
                od.Quantity = (int)reader["Quantity"];
                LOrderDetails.Add(od);
            }
            sqlConnection.Close();
            return LOrderDetails;
           

        }

        public int UpdateQuantity(int orderDeatilid,int quantity)
        {
            cmd.CommandText = "Update OrderDetails set quantity=@quantity where OrderDetailId=@id";
            cmd.Parameters.AddWithValue("@id", orderDeatilid);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int status = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return status;
        }

        public double CalculateSubtotal(int OrderDetailId)
        {
            cmd.CommandText = @"select sum(Quantity*price) from OrderDetails join Products
                                on OrderDetails.ProductId=Products.ProductId 
                                where OrderDetailId=@id";
            cmd.Parameters.AddWithValue("@id", OrderDetailId);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            object result = cmd.ExecuteScalar();
            sqlConnection.Close();
            if (result!= null )
            {
                return (double)result;
            }
            else
            {
                return 0;
            }


        }

    }
}
