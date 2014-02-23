using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Application;
using Rhino.Mocks;
 using Northwind.Application.CustomerService;

namespace Northwind.ViewModel.Tests
{
    [TestClass]
    public class CustomerDetailsViewModelTests
    {
        [TestMethod]
        public void Ctr_Always_CallsGetCustomer()
        {
            //Arrange
            const string expectID = "EXPECTEDID";
            IUIDataProvider dataMock = MockRepository.GenerateMock<IUIDataProvider>();
            dataMock.Expect(c=>c.GetCustomer(expectID));
            
            //Act
            CustomerDetailsViewModel target = new CustomerDetailsViewModel(dataMock, expectID);

            //Assert
            dataMock.VerifyAllExpectations();
            //AssertFail
           
        }

        [TestMethod]
        public void Customer_Always_ReturnsCustomerFromGetCustomer()
        {
             //Arrange
            const string expectID = "EXPECTEDID";
            IUIDataProvider dataStub = MockRepository.GenerateStub<IUIDataProvider>();

            Customer expectedCustomer = new Customer
            {
                CustomerID=expectID
            };

            dataStub.Expect(c => c.GetCustomer(expectID)).Return(expectedCustomer);

            //Act
            CustomerDetailsViewModel target = new CustomerDetailsViewModel(dataStub, expectID);
           
            //Assert
             Assert.AreSame(expectedCustomer, target.Customer);
            //Assert Fail
            //Assert.AreNotSame(expectedCustomer, target.Customer);
        }

        [TestMethod]
        public void DisplayName_Always_ReturnsCompanyName()
        {
            //Arrange
            const string expectID = "EXPECTEDID";
            const string companyName = "ACMECO";

            Customer expectedCustomer = new Customer
            {
                CustomerID = expectID,
                CompanyName = companyName
            };
            IUIDataProvider dataStub = MockRepository.GenerateStub<IUIDataProvider>();

            dataStub.Expect(c => c.GetCustomer(expectID)).Return(expectedCustomer);

            //Act
            CustomerDetailsViewModel target = new CustomerDetailsViewModel(dataStub, expectID);

            //Assert
            Assert.AreEqual(target.DisplayName, expectedCustomer.CompanyName);

            //Assert Fail
           //Assert.AreNotEqual(target.DisplayName, expectedCustomer.CompanyName);
        }
    }
}
