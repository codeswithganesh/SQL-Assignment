using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTask
{
   
        public class OrderDetails
        {
            public int OrderId { get; set; }
            public int ProductId { get; set; }
            public int Quantity { get; set; }
            // Other properties as needed
        }

        public class OrderDetailsManager
        {
            private List<OrderDetails> orderDetails;

            public OrderDetailsManager()
            {
                orderDetails = new List<OrderDetails>();
            }

            public void Add(OrderDetails orderDetail)
            {
                orderDetails.Add(orderDetail);
            }

           
        }
    }


