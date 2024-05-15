using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsTask
{
    internal class SortOrderByDate
    {
       
        {
            private List<Order> orders;

            public SortOrderByDate()
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
                    throw new KeyNotFoundException("Order not found.");
                }

                orders.Remove(existingOrder);
            }

            // Custom sorting methods for order date
            public List<Order> SortByDate(bool ascending = true)
            {
                if (ascending)
                    return orders.OrderBy(o => o.OrderDate).ToList();
                else
                    return orders.OrderByDescending(o => o.OrderDate).ToList();
            }
        }
    }

