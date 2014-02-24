using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwind.Application;
using Northwind.Model;
using System.ComponentModel;
//using Northwind.Application.CustomerService;
 

namespace Northwind.ViewModel
{
    public class CustomerDetailsViewModel : ToolViewModel 
    {
       private readonly IUIDataProvider _dataProvider;
       private RelayCommand _updateCommand;
       private bool _isDirty=false;

       public CustomerDetailsViewModel(IUIDataProvider dataProvider, string customerID)
       {
           _dataProvider = dataProvider;
           Customer = _dataProvider.GetCustomer(customerID);
           base.DisplayName = Customer.CompanyName;
           Customer.PropertyChanged += Customer_PropertyChanged;
       }

       void Customer_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
       {
           _isDirty = true;
           UpdateCommand.RaiseExecuteChanged();
       }

       public RelayCommand UpdateCommand
       {
           get
           {
               return _updateCommand ??
                   (_updateCommand = new RelayCommand(
                   p => UpdateCustomer(),
                   p => CanUpdateCustomer()
                   ));
           }
       }

       public Customer Customer {get;set;}

       public void UpdateCustomer()
       {
           _dataProvider.Update(this.Customer);
           _isDirty = false;
       }

       public bool CanUpdateCustomer()
       { 
        return _isDirty;
       }

    
    }
}
