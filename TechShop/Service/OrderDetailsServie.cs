

using TechShop.Model;
using TechShop.Repository;

namespace TechShop.Service
{
    internal class OrderDetailsServie:IOrderDetailsService
    {
        readonly IOrderDetailsRepository _orderDetailsRepository;
        public OrderDetailsServie()
        {
            _orderDetailsRepository = new OrderDetailsRepository();
        }
        public void GetOrderDetailInfo()
        {
            List<OrderDetails> LOrderDetails = new List<OrderDetails>();
            LOrderDetails = _orderDetailsRepository.GetOrderDetailInfo();
            foreach(OrderDetails item in LOrderDetails)
            {
                Console.WriteLine(item);
            }

        }

        public void UpdateQuantity()
        {
            Console.WriteLine("Enter the OrderDetailID"); 
            int id=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Updated Quantity");
            int quantity=int.Parse(Console.ReadLine());
            int result = _orderDetailsRepository.UpdateQuantity(id, quantity);
            if(result>0)
            {
                Console.WriteLine($"{result} updated Sucessfully");
            }
            else
            {
                Console.WriteLine("No Rows Updated ");
            }


        }

        public void CalculateSubtotal()
        {
            Console.WriteLine("Enter the OrderDetailId");
            int id=int.Parse (Console.ReadLine());
            double result=_orderDetailsRepository.CalculateSubtotal(id);
            if(result>0)
            {
                Console.WriteLine($"SubTotal for the ORderDetailId:{id} is::{result}");
            }
            else
            {
                Console.WriteLine("Cannot find the records with inputed data");
            }
        }
    }
}
