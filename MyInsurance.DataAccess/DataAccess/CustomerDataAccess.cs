﻿using MyInsurance.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyInsurance.Model;
using MyInsurance.DataAccess.Mappers;

namespace MyInsurance.DataAccess.DataAccess
{
    public class CustomerDataAccess : ICustomerDataAccess
    {
        private CustomerMapper _customerMapper;
        public CustomerDataAccess()
        {
            _customerMapper = new CustomerMapper();
        }

        public Customer GetCustomer(string TcNumber, string PlateNumber)
        {
            using (var db = new Data.MyInsuranceEntities())
            {
                var customerData = db.Customers.FirstOrDefault(c => c.TCNumber == TcNumber && c.PlateNumber == PlateNumber);
                return _customerMapper.ToModel(customerData);
            }
        }
    }
}