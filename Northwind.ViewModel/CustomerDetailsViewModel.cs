﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwind.Application;
using Northwind.Model;
//using Northwind.Application.CustomerService;
 

namespace Northwind.ViewModel
{
   public class CustomerDetailsViewModel :ToolViewModel
    {
       private readonly IUIDataProvider _dataProvider;

       public CustomerDetailsViewModel(IUIDataProvider dataProvider, string customerID)
       {
           _dataProvider = dataProvider;
           Customer = _dataProvider.GetCustomer(customerID);
           base.DisplayName = Customer.CompanyName;
       }

       public Customer Customer {get;set;}
    }
}
