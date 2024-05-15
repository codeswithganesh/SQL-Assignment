﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShop.Exception
{
    internal class InsufficientStockException:SystemException
    {
        public InsufficientStockException(string message) : base(message)
        {
        }
    }
}
