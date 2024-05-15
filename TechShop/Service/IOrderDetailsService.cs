using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Service
{
    internal interface IOrderDetailsService
    {
        public void GetOrderDetailInfo();
        public void UpdateQuantity();
        public void CalculateSubtotal();

    }
}
