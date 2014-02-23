﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Northwind.Application.CustomerService;
using Northwind.Model;

namespace Northwind.Application
{
    public interface IUIDataProvider
    {
        IList<Customer> GetCustomers();
        Customer GetCustomer(string customerID);
    }
}
