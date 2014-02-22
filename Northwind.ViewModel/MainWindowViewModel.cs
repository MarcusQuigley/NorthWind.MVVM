using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Northwind.Data;
using System.Data.Objects;
using Northwind.Application;
using System.Windows.Input;

namespace Northwind.ViewModel
{
    public class MainWindowViewModel
    {
        private readonly IUIDataProvider _dataProvider;
        private IList<Customer> _customers;
        private CustomerCommand _customerCommand;
       

        public MainWindowViewModel(IUIDataProvider dataProvider)
        {
            this._dataProvider = dataProvider;

            Tools = new ObservableCollection<ToolViewModel>();
        }

        public ObservableCollection<ToolViewModel> Tools { get; set; }
        public string SelectedCustomerID { get; set; }

        public string Name
        {
            get { return "Northwind"; } 
        }
        public string ControlPanelName
        { 
            get { return "Control Panel"; } 
        }

        public bool IsCustomerSelected()
        {
           return SelectedCustomerID != ""; 
        }


        public CustomerCommand CustomerCommand
        {
            get { return _customerCommand ??
                (_customerCommand = new CustomerCommand(
                    (param) => SelectCustomer(),
                   (param) => IsCustomerSelected()));
            }
            
        }

        public void  SelectCustomer()
        {
            Tools.Add(new CustomerDetailsViewModel(_dataProvider, SelectedCustomerID));
        }

        public IList<Customer> Customers
        {
            get
            {
                return _customers ?? (_customers=GetCustomers());
            }
        }

        private IList<Customer> GetCustomers()
        {
            return _dataProvider.GetCustomers();
        }

    }
}
