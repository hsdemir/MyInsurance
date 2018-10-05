using MyInsurance.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyInsurance.Model;
using MyInsurance.DataAccess.DataAccess;

namespace MyInsurance.Business.Business
{
    public class CustomerBusiness : ICustomerBusiness
    {
        CustomerDataAccess _customerDataAccess;
        public CustomerBusiness()
        {
            _customerDataAccess = new CustomerDataAccess();
        }
        public Customer GetCustomer(string TcNumber, string PlateNumber)
        {
            return _customerDataAccess.GetCustomer(TcNumber, PlateNumber);
        }
    }
}
