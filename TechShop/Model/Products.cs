

namespace TechShop.Model
{
    internal class Products
    {
        private int productId;
        private string productName;
        private string description;
        private double price;
        private string category;

        public int ProductID
        {
            get { return productId; }
            set { productId = value; }
        }

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public double Price
        {
            get { return price; }
            set
            {
                // Add price validation logic here
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative.");
                }
                price = value;
            }
        }
        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public Products()
        {

        }
        public Products(int productID, string productName, string description, double price)
        {
            ProductID = productID;
            ProductName = productName;
            Description = description;
            Price = price;
        }
        public override string ToString()
        {
            return $"ProductID:{ProductID}\tProductName{ProductName}\tDescrption:{Description}\tPrice:{Price}\t Category::{Category}\n ";
        }
    }
}
