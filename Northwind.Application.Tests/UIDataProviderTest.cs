using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Application;
using Rhino.Mocks;
namespace Northwind.Application.Tests
{
    [TestClass]
    public class UIDataProviderTest
    {
        [TestMethod]
        public void GetCustomers_Always_CallsGetCustomers()
        {
            //arrange

            CustomerService.ICustomerService serviceMock = MockRepository.GenerateMock<CustomerService.ICustomerService>();
            CustomerService.Customer[] customers = { new CustomerService.Customer() };
            serviceMock.Expect(c => c.GetCustomers()).Return(customers);

            UIDataProvider target = new UIDataProvider(serviceMock);

            //act
           var x= target.GetCustomers();

            //assert
            serviceMock.AssertWasCalled(c => c.GetCustomers());
           //assert failed
           //serviceMock.AssertWasNotCalled(c => c.GetCustomers());
        }
    }
}
