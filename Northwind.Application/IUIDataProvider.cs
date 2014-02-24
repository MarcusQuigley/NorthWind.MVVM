using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Northwind.Application.CustomerService;
using Northwind.Model;

namespace Northwind.Application
{
    public interface IUIDataProvider
    {
        IList<Model.Customer> GetCustomers();
        Model.Customer GetCustomer(string customerID);
        void Update(Model.Customer customer);
    }
}
