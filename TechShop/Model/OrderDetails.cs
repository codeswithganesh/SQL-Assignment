

namespace TechShop.Model
{
    internal class OrderDetails
    {
        private int orderDetailId;
        private Orders order;
        private Products product;
        private int quantity;

        public int OrderDetailId
        {
            get { return orderDetailId; }
            set { orderDetailId = value; }
        }

        public Orders Order
        {
            get { return order; }
            set { order = value; }
        }

        public Products Product
        {
            get { return product; }
            set { product = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                // Add quantity validation logic here
                if (value <= 0)
                {
                    throw new ArgumentException("Quantity must be a positive integer.");
                }
                quantity = value;
            }
        }
        public OrderDetails()
        {
            
        }
        public OrderDetails(int orderDetailId, Orders order, Products product, int quantity)
        {
            OrderDetailId = orderDetailId;
            this.order = order;
            this.product = product;
            Quantity = quantity;
        }
        
        public override string ToString()
        {
            return $"OrderdetailId{OrderDetailId}\nOrder{Order}\nProduct{Product}\nQuantity{Quantity}";
        }
    }
}
