using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwind.Data;

namespace Northwind.Application
{
    public interface IUIDataProvider
    {
        IList<Customer> GetCustomers();
        Customer GetCustomer(string CustomerID);
    }
}
