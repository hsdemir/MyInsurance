using MyInsurance.Business.Business;
using MyInsurance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyInsurance.Service.Controllers
{
    public class CustomerController : ApiController
    {
        CustomerBusiness _customerBusiness;
        public CustomerController()
        {
            _customerBusiness = new CustomerBusiness();
        }
        Customer GetCustomer(string TcNumber, string PlateNumber)
        {
            return _customerBusiness.GetCustomer(TcNumber, PlateNumber);
        }
    }
}
