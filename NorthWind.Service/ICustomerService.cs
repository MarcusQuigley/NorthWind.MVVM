using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NorthWind.Service
{
    [ServiceContract]
    public interface ICustomerService
    {
        [OperationContract]
        IList<Customer> GetCustomers();
        [OperationContract]
        Customer GetCustomer(string customerID);
    }
}
