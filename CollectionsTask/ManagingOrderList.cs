using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTask
{
    public class Order
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public DateTime OrderDate { get; set; }
        // Other properties as needed
    }
    internal class ManagingOrderList
    {
        private List<Order> orders;

        public ManagingOrderList()
        {
            orders = new List<Order>();
        }

        public void Add(Order order)
        {
            orders.Add(order);
        }

        public void Update(Order order)
        {
            var existingOrder = orders.FirstOrDefault(o => o.Id == order.Id);
            if (existingOrder == null)
            {
                throw new KeyNotFoundException("Order not found.");
            }

            existingOrder.Customer = order.Customer;
            existingOrder.OrderDate = order.OrderDate;
            // Update other properties as needed
        }

        public void Remove(Order order)
        {
            var existingOrder = orders.FirstOrDefault(o => o.Id == order.Id);
            if (existingOrder == null)
            {
                throw new KeyNotFoundException("Product not found.");
            }

            orders.Remove(existingOrder);
        }
    }
}
