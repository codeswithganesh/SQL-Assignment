

using System.Data.SqlClient;

namespace TechShop.Repository
{
    internal interface IOrderRepository
    {
        public int UpdateOrderStatus(int Orderid,string status);
        public int CalculateTotalAmount(int orderid);

        public List<dynamic> GetOrderDetails(int orderid);

        public bool CancelOrder(int orderid);
       


    }
}
