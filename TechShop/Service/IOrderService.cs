

namespace TechShop.Service
{
    internal interface IOrderService
    {
        public void UpdateOrderStatus();
        public void CalculateTotalAmount();
        public void GetOrderDetails();

        public void CancelOrder();
    }
}
