using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.Application
{
    public class CustomerTranslator : IEntityTranslator<Model.Customer, CustomerService.Customer>
    {
        internal static IEntityTranslator<Model.Customer, CustomerService.Customer> _instance;

        public static IEntityTranslator<Model.Customer, CustomerService.Customer> Instance
        {
            get
            {
                return _instance ??
                    (_instance = new CustomerTranslator());
            }
        }

        public Model.Customer CreateModel(CustomerService.Customer dto)
        {
            return new Model.Customer
            {
                CustomerID = dto.CustomerID,
                CompanyName = dto.CompanyName,
                Address = dto.Address,
                City = dto.City,
                ContactName = dto.ContactName,
                ContactTitle = dto.ContactTitle,
                Country = dto.Country,
                Phone = dto.Phone,
                PostCode = dto.PostalCode

            };
        }

        public Model.Customer UpdateModel(Model.Customer model, CustomerService.Customer dto)
        {
            if (model == null) throw new ArgumentNullException("model");
            if (dto == null) throw new ArgumentNullException("dto");

            if (model.CustomerID != dto.CustomerID)
                model.CustomerID = dto.CustomerID;

            if (model.CompanyName != dto.CompanyName)
                model.CompanyName = dto.CompanyName;

            model.Address = dto.Address;
            model.City = dto.City;
            model.ContactName = dto.ContactName;
            model.ContactTitle = dto.ContactTitle;
            model.Country = dto.Country;
            model.Phone = dto.Phone;
            model.PostCode = dto.PostalCode;
            model.Region = dto.Region;

            return model;
        }


        public CustomerService.Customer CreateDto(Model.Customer model)
        {
            return new CustomerService.Customer
            {
                CustomerID = model.CustomerID,
                CompanyName = model.CompanyName,
                Address = model.Address,
                City = model.City,
                ContactName = model.ContactName,
                ContactTitle = model.ContactTitle,
                Country = model.Country,
                Phone = model.Phone,
                Region = model.Region,
                PostalCode = model.PostCode
            };
        }

        public CustomerService.Customer UpdateDto(CustomerService.Customer dto, Model.Customer model)
        {
            if (model == null) throw new ArgumentNullException("model");
            if (dto == null) throw new ArgumentNullException("dto");

             if (dto.CustomerID != model.CustomerID)
                dto.CustomerID = model.CustomerID;

            if (dto.CompanyName != model.CompanyName)
                dto.CompanyName = model.CompanyName;

            dto.Address = model.Address;
            dto.City = model.City;
            dto.ContactName = model.ContactName;
            dto.ContactTitle = model.ContactTitle;
            dto.Country = model.Country;
            dto.Phone = model.Phone;
            dto.PostalCode = model.PostCode;
            dto.Region = model.Region;

            return dto;
        }
    }
}
