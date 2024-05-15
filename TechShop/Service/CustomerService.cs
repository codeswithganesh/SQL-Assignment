

using System.Threading.Channels;
using TechShop.Model;
using TechShop.Repository;

namespace TechShop.Service
{
    internal class CustomerService:ICustomerService
    {
        readonly ICustomerRepository _customerRepository;
        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }
        public void GetCustomerDetails()
        {
            List<Customers> customers=_customerRepository.GetCustomerDetails();
            foreach(Customers item in  customers)
            {
                Console.WriteLine(item);
            } 

        }
        public  void UpdateCustomerInfo()
        {
        
            Console.WriteLine("Enter the Customer ID");
            int id=int.Parse(Console.ReadLine());
            
           
            Console.WriteLine("Enter the Email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter the Phone NO");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter the Address");
            string address = Console.ReadLine();

            int status = _customerRepository.UpdateCustomerInfo(id,email,phone,address);
            if(status>0)
            {
                Console.WriteLine($"{status} Rows Updated Sucessfully");
            }
            else
            {
                Console.WriteLine("Not updated please try after some time");
            }
        }
        public void CalculateTotalOrders()
        {
            Console.WriteLine("Enter the CustomerId");
            int id= int.Parse(Console.ReadLine());
            int result = _customerRepository.CalculateTotalOrders(id);
            if(result !=null)
            {
                Console.WriteLine($"TotalOrders::{result}");
            }
            else
            {
                Console.WriteLine("No rows retreived");
            }
        }

        public void register()
        {
            int result = 0;

            try
            {
                
                Customers customer = new Customers();
                Console.WriteLine("Enter the Customer ID");
                customer.CustomerID = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the FirstName");
                customer.FirstName = Console.ReadLine();
                Console.WriteLine("Enter the LastName");
                customer.LastName = Console.ReadLine();
                Console.WriteLine("Enter hte customer Email");
                customer.Email = Console.ReadLine();
                Console.WriteLine("Enter the customer Phone");
                customer.Phone = Console.ReadLine();
                Console.WriteLine("Enter the Customer Address");
                customer.Address = Console.ReadLine();
                result = _customerRepository.register(customer);
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(SystemException e)
            {
                Console.WriteLine(e.Message);
            }
           if(result>0)
            {
                Console.WriteLine("Registriration sucessfull");
            }
            else
            {
                Console.WriteLine("registreation not sucess full");
            }
        }
    }
}
