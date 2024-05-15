using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShop.Model;

namespace TechShop.Repository
{
    internal interface ICustomerRepository
    {
       public List<Customers> GetCustomerDetails();
        public int UpdateCustomerInfo(int id, string email, string phone, string address);
        public int CalculateTotalOrders(int id);

        public int register(Customers customer);
        public bool isEmailUnique(string email);


    }
}
