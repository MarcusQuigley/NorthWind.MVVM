using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwind.Data;

namespace Northwind.Application
{
   public class UIDataProvider : IUIDataProvider
    {
       private IList<Data.Customer> _customers;

        public IList<Data.Customer> GetCustomers()
        {
            if (_customers == null)
                _customers = new NORTHWNDEntities().Customers.ToList();

            return _customers;
        }

       



        public Customer GetCustomer(string CustomerID)
        {
            if (_customers == null)
                GetCustomers();

            return _customers.Single(c => c.CustomerID == CustomerID);
        }
    }
}
