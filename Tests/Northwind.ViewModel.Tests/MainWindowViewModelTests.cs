using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.Application;
using Rhino.Mocks;
using Northwind.Data;

namespace Northwind.ViewModel.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        /// <summary>
        /// this is a behaviour test. 
        /// Whereby we use a mock (IUIDataProvider) to confirm that 
        /// the class we test (MainWindowViewModel) did what its supposed to do
        /// </summary>
        [TestMethod]
        public void Customers_AlwaysCalls_GetCustomers()
        {
            //Arrange

            IUIDataProvider dataMock = MockRepository.GenerateMock<IUIDataProvider>();
            dataMock.Expect(c => c.GetCustomers());

            MainWindowViewModel target = new MainWindowViewModel(dataMock);
             
            //Act
            IList<Customer> customers = target.Customers;

            //Assert
            dataMock.VerifyAllExpectations();
            //Assert Failure
            //dataStub.AssertWasNotCalled(c=> c.GetCustomers());
        }

    [TestMethod]
      public void Customers_Never_ReturnsNull()
      {
          //Arrange

           IUIDataProvider dataStub = MockRepository.GenerateStub<IUIDataProvider>();
          dataStub.Expect(c => c.GetCustomers());

          MainWindowViewModel target = new MainWindowViewModel(dataStub);

          //Act
          IList<Customer> customers = target.Customers;

          //Assert
          Assert.IsNotNull(customers);
          
          //Assert Failure
          //Assert.IsNull(customers);
      }
    }
}
