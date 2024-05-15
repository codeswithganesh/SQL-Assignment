

using System.Linq;
using TechShop.Repository;

namespace TechShop.Service
{
    internal class OrderService:IOrderService
    {
        readonly IOrderRepository _orderRepository;
        public OrderService()
        {
            _orderRepository = new OrderRepository();
        }
        public void UpdateOrderStatus()
        {
            Console.WriteLine("Eneter the OrderID You want to Chage the Status");
            int id=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Status");
            string changedStatus=Console.ReadLine();
            int result=_orderRepository.UpdateOrderStatus(id, changedStatus);
            if (result > 0)
            {
                Console.WriteLine($"{result} Rows Updated Sucessfully");
            }
            else
            {
                Console.WriteLine("Not updated please check your input  try after some time");
            }

        }

        public void CalculateTotalAmount()
        {
            Console.WriteLine("Enter the OrderId"); 
            int id= int.Parse(Console.ReadLine());
            int result=_orderRepository.CalculateTotalAmount(id);
            if (result > 0)
            {
                Console.WriteLine($"Total Amount for the OrderId::{id} is ::{result}");
            }
            else
            {
                Console.WriteLine("We cannot find the order with the inputed orderid");
            }

        }


        public void GetOrderDetails()
        {
            Console.WriteLine("Enter the OrderID");
            int id= int.Parse(Console.ReadLine());
            List<dynamic> orderDetails = new List<dynamic>();
            orderDetails = _orderRepository.GetOrderDetails(id);
            foreach(dynamic item in orderDetails)
            {
                Console.WriteLine(item);
            }
        }

        public void CancelOrder()
        {
            Console.WriteLine("Enter the OrderId you want to Cancel");
            int id = int.Parse(Console.ReadLine());
            bool result= _orderRepository.CancelOrder(id);
            if(result)
            {
                Console.WriteLine("Cancel Order Sucessful");
            }
            else
            {
                Console.WriteLine("Cancel Order  Not Sucessful");
            }
        }
    }
}
