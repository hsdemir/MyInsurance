using MyInsurance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInsurance.Business.Interface
{
    public interface ICustomerBusiness
    {
        Customer GetCustomer(string TcNumber, string PlateNumber);
    }
}
