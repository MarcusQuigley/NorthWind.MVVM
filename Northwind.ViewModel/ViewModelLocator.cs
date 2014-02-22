using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwind.Application;

namespace Northwind.ViewModel
{
   public class ViewModelLocator
    {
       private static MainWindowViewModel _mainWindowViewModel;

       public static MainWindowViewModel MainWindowViewModelStatic
       {
           get {
     
               return _mainWindowViewModel ??
                   ( _mainWindowViewModel = new MainWindowViewModel(new UIDataProvider()));
           }
       }

    }
}
