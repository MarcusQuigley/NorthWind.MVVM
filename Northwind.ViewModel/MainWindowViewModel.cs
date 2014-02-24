using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using System.Data.Objects;
using Northwind.Application;
using System.Windows.Input;
using System.Windows.Data;
using Northwind.Model;
//using Northwind.Application.CustomerService;

namespace Northwind.ViewModel
{
    public class MainWindowViewModel
    {
        private readonly IUIDataProvider _dataProvider;
        private IList<Customer> _customers;
        private RelayCommand _customerCommand;
       

        public MainWindowViewModel(IUIDataProvider dataProvider)
        {
            this._dataProvider = dataProvider;

            Tools = new ObservableCollection<ToolViewModel>();
        }

        public ObservableCollection<ToolViewModel> Tools { get; set; }
        public string SelectedCustomerID { get; set; }

        public string Name
        {
            get { return "Customers Details"; } 
        }
        public string ControlPanelName
        {
            get { return "Customers"; } 
        }

        public bool IsCustomerSelected()
        {
           return SelectedCustomerID != ""; 
        }


        public RelayCommand CustomerCommand
        {
            get
            {
                return _customerCommand ??
                    (_customerCommand = new RelayCommand(
                  p => ShowCustomerDetails(),
                 p => IsCustomerSelected()));
            }

        }

        public void  ShowCustomerDetails()
        {
            if (string.IsNullOrEmpty(SelectedCustomerID))
                throw new ArgumentNullException("SelectedCustomerID");

            CustomerDetailsViewModel customerDetails = GetCustomerDetailsTool(SelectedCustomerID);

            if (customerDetails == null)
            {
                customerDetails = new CustomerDetailsViewModel(this._dataProvider, SelectedCustomerID);
                Tools.Add(customerDetails);
            }

            SetCurrentTool(customerDetails);
        }

        private CustomerDetailsViewModel GetCustomerDetailsTool(string customerID)
        {
            return Tools.OfType<CustomerDetailsViewModel>()
                .FirstOrDefault(c => c.Customer.CustomerID == customerID);
        }

        private void SetCurrentTool(ToolViewModel currentTool)
        {
           ICollectionView source = CollectionViewSource.GetDefaultView(Tools);
           if (source != null)
           {
               if (source.MoveCurrentTo(currentTool) == false)
                   throw new InvalidOperationException("Could not find Customer Tool VM in coll");
           }
        }

        public IList<Customer> Customers
        {
            get
            {
                return _customers ?? 
                    (_customers=GetCustomers());
            }
        }

        private IList<Customer> GetCustomers()
        {
            return _dataProvider.GetCustomers();
        }

    }
}
