using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;

namespace Northwind.Model
{
    public class ModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void RaisePropertyChanged(string propertyName)
        {
            VerifyProperty(propertyName);
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        [DebuggerStepThrough] //WE can't step through this code
        private void VerifyProperty(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
                throw new InvalidOperationException(
                    string.Format("Property {0} doesnt exist in the {1} type",
                    propertyName, this.GetType().Name));
        }
    }
}
