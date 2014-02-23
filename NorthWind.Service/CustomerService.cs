using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NorthWind.Service
{
     public class CustomerService : ICustomerService
    {
         private readonly Northwind.Data.NORTHWNDEntities nwindEntity;
         private IList<Customer> _customers;
         public CustomerService()
         {
             nwindEntity = new Northwind.Data.NORTHWNDEntities();
         }

        public IList<Customer> GetCustomers()
        {
            if (_customers == null)

                _customers = nwindEntity.Customers.Select
                    (c => new Customer{
                    CustomerID = c.CustomerID,
                    CompanyName = c.CompanyName
                }).ToList();

            return _customers;
        }

        public Customer GetCustomer(string customerID)
        {
            Northwind.Data.Customer c = nwindEntity.Customers.Single(cust => cust.CustomerID == customerID);

            return new Customer 
            {
                CustomerID = c.CustomerID,
                CompanyName = c.CompanyName,
                Address = c.Address,
                City = c.City,
                ContactName = c.ContactName,
                ContactTitle = c.ContactTitle,
                Country = c.Country,
                Phone = c.Phone,
                PostalCode = c.PostalCode,
                Region = c.Region
            };
              
        }
    }
}
