﻿using MyInsurance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInsurance.DataAccess.Interface
{
    public interface ICustomerDataAccess
    {
        Customer GetCustomer(string TcNumber, string PlateNumber);
        Customer Create(Customer customer);
    }
}
