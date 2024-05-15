

namespace TechShop.Model
{
    internal class Orders
    {
        private int orderId;
        private Customers customer;
        private DateTime orderDate;
        private decimal totalAmount;
        private string status;

        public int OrderID
        {
            get { return orderId; }
            set { orderId = value; }
        }

        public Customers Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        public DateTime OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }

        public decimal TotalAmount
        {
            get { return totalAmount; }
            set { totalAmount = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }


        public Orders(int orderId, Customers customer, DateTime orderDate, decimal totalAmount,string status)
        {
            OrderID = orderId;
            this.customer = customer;
            OrderDate = orderDate;
            TotalAmount = totalAmount;
            Status = status;
        }

        public Orders()
        {
        }

        public override string ToString()
        {
            return $"OrderId:{OrderID}\tCustomerName:{Customer.FirstName} {Customer.LastName}\tOrderDate:{OrderDate}\tTotalAmount:{TotalAmount}\tStatus{Status}\n";
        }

    }
}
