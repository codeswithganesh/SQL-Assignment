using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;

namespace TechShop.Repository
{
    internal interface IOrderDetailsRepository
    {
        public List<OrderDetails> GetOrderDetailInfo();

        public int UpdateQuantity(int orderDeatilid,int quantity);

        public double CalculateSubtotal(int OrderDetailId);

    }
}
