using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Northwind.Application.CustomerService;
 

namespace Northwind.Application
{
   public class UIDataProvider : IUIDataProvider
    {
       private IList<Model.Customer> _customers;
       private readonly CustomerService.ICustomerService _customerServiceClient;



       public UIDataProvider(CustomerService.ICustomerService customerService)
       {
           _customerServiceClient = customerService;
       }

       public IList<Model.Customer> GetCustomers()
        {
            if (_customers == null)
                _customers = _customerServiceClient.GetCustomers().Select(
                    c=> CustomerTranslator.Instance.CreateModel(c)).ToList();

            return _customers;
         
        }

       public Model.Customer GetCustomer(string customerID)
        {

            return CustomerTranslator.Instance.UpdateModel(
                _customers.First(c=>c.CustomerID == customerID),
                  _customerServiceClient.GetCustomer(customerID));
            //return _customers.Single(c => c.CustomerID == CustomerID);
        }

    }

   //internal static class CustomerExtensions
   //{
   //    public static Customer Update(this Customer customer, Customer existingCustomer)
   //    {
   //        customer.CustomerID = existingCustomer.CustomerID;
   //        customer.CompanyName = existingCustomer.CompanyName;
   //        customer.Address = existingCustomer.Address;
   //        customer.City = existingCustomer.City;
   //        customer.ContactName = existingCustomer.ContactName;
   //        customer.Country = existingCustomer.Country;
   //        customer.Phone = existingCustomer.Phone;
   //        customer.PostalCode = existingCustomer.PostalCode;
   //        customer.Region = existingCustomer.Region;

   //        return customer;
   //    }
   //}
}
