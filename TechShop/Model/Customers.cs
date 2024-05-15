

namespace TechShop.Model
{
    internal class Customers
    {
        private int customerId;
        private string firstName;
        private string lastName;
        private string email;
        private string phone;
        private string address;

        public int CustomerID
        {
            get { return customerId; }
            set { customerId = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Email
        {
            get { return email; }
            set
            {
                // Add email validation logic here
                if (!IsValidEmail(value))
                {
                    throw new ArgumentException("Invalid email address.");
                }
                email = value;
            }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private bool IsValidEmail(string email)
        {
            
            return !string.IsNullOrEmpty(email) && email.Contains("@");
        }
        public Customers()
        {
             
        }
        public Customers(int customerID, string firstName, string lastName, string email, string phone, string address)
        {
            CustomerID = customerID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public override string ToString()
        {
            return $" CustomerID:{CustomerID}\tCustomerName:{FirstName} {LastName}\t Email:{Email}\t Phone:{Phone}\tAddress:{Address}\n ";
        }
    }
}
