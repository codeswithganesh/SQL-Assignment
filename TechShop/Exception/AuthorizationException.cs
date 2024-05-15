using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Exception
{
    internal class AuthorizationException:SystemException
    {
        public AuthorizationException(string message) : base(message)
        {
        }
    }
}
