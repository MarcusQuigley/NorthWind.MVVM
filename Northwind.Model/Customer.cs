﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;

namespace Northwind.Model
{
    public class Customer : ModelBase, IDataErrorInfo
    {
        private string _customerID;
        private string _companyName;
        private string _contactName;
        private string _contactTitle;
        private string _address;
        private string _city;
        private string _region;
        private string _postCode;
        private string _country;
        private string _phone;

        public string CustomerID
        {
            get { return _customerID; }
            set
            {
                if (string.Compare(_customerID, value) == 0)
                    return;
                _customerID = value;
                RaisePropertyChanged("CustomerID");
            }
        }

        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                if (string.Compare(_companyName, value) == 0)
                    return;
                _companyName = value;
                RaisePropertyChanged("CompanyName");
            }
        }

        public string ContactName
        {
            get { return _contactName; }
            set
            {
                if (string.Compare(_contactName, value) == 0)
                    return;
                _contactName = value;
                RaisePropertyChanged("ContactName");
            }
        }

        public string ContactTitle
        {
            get { return _contactTitle; }
            set
            {
                if (string.Compare(_contactTitle, value) == 0)
                    return;
                _contactTitle = value;
                RaisePropertyChanged("ContactTitle");
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                if (string.Compare(_address, value) == 0)
                    return;
                _address = value;
                RaisePropertyChanged("Address");
            }
        }

        public string City
        {
            get { return _city; }
            set
            {
                if (string.Compare(_city, value) == 0)
                    return;
                _city = value;
                RaisePropertyChanged("City");
            }
        }

        public string Region
        {
            get { return _region; }
            set
            {
                if (string.Compare(_region, value) == 0)
                    return;
                _region = value;
                RaisePropertyChanged("Region");
            }
        }

        public string PostCode
        {
            get { return _postCode; }
            set
            {
                if (string.Compare(_postCode, value) == 0)
                    return;
                _postCode = value;
                RaisePropertyChanged("PostCode");
            }
        }


        public string Country
        {
            get { return _country; }
            set
            {
                if (string.Compare(_country, value) == 0)
                    return;
                _country = value;
                RaisePropertyChanged("Country");
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (string.Compare(_phone, value) == 0)
                    return;
                _phone = value;
                RaisePropertyChanged("Phone");
            }
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string propertyName]
        {
            get { return this.GetValidationError(propertyName); }
        }

        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                    if (GetValidationError(property) != null)
                        return false;

                return true;
            }
        }

        static readonly string[] ValidatedProperties = 
        { 
            "ContactName", 
         };

        string GetValidationError(string propertyName)
        {
            if (Array.IndexOf(ValidatedProperties, propertyName) < 0)
                return null;

            string error = null;

            switch (propertyName)
            {
                case "ContactName":
                    error = this.ValidateCompanyName();
                    break;



                default:
                    Debug.Fail("Unexpected property being validated on Customer: " + propertyName);
                    break;
            }

            return error;
        }

        private string ValidateCompanyName()
        {
            if (string.IsNullOrEmpty(this.ContactName))
                return "Contact Name can't be empty";

           return null;
        }

    }

}
