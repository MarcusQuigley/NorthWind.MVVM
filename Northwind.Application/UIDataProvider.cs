using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwind.Application.CustomerService;
 

namespace Northwind.Application
{
   public class UIDataProvider : IUIDataProvider
    {
       private IList<Customer> _customers;
       private readonly CustomerServiceClient _customerServiceClient 
           = new CustomerServiceClient();

        public IList<Customer> GetCustomers()
        {
            if (_customers == null)
                _customers = _customerServiceClient.GetCustomers();

            return _customers;
        }

       



        public Customer GetCustomer(string customerID)
        {
            Customer customer = _customers.First(c => c.CustomerID == customerID);

            return customer.Update(_customerServiceClient.GetCustomer(customerID));

            //return _customers.Single(c => c.CustomerID == CustomerID);
        }


    }

   internal static class CustomerExtensions
   {
       public static Customer Update(this Customer customer, Customer existingCustomer)
       {
           customer.CustomerID = existingCustomer.CustomerID;
           customer.CompanyName = existingCustomer.CompanyName;
           customer.Address = existingCustomer.Address;
           customer.City = existingCustomer.City;
           customer.ContactName = existingCustomer.ContactName;
           customer.Country = existingCustomer.Country;
           customer.Phone = existingCustomer.Phone;
           customer.PostalCode = existingCustomer.PostalCode;
           customer.Region = existingCustomer.Region;

           return customer;
       }
   }
}
