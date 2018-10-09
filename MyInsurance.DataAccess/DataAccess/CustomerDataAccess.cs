using MyInsurance.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyInsurance.Model;
using MyInsurance.DataAccess.Mappers;
using System.Data.Entity;

namespace MyInsurance.DataAccess.DataAccess
{
    public class CustomerDataAccess : ICustomerDataAccess
    {
        private CustomerMapper _customerMapper;
        public CustomerDataAccess()
        {
            _customerMapper = new CustomerMapper();
        }

        public Customer Create(Customer customer)
        {
            using (var db = new Data.MyInsuranceEntities())
            {
                var customerData = _customerMapper.ToData(customer);
                var foundCustomer = db.Customers.FirstOrDefault(c => c.TCNumber == customer.TCNumber && c.PlateNumber == customer.CustomerCar.PlateNumber);
                if (foundCustomer == null)
                {
                    db.Customers.Add(customerData);
                    db.SaveChanges();
                }

                customerData = db.Customers.FirstOrDefault(c => c.TCNumber == customer.TCNumber && c.PlateNumber == customer.CustomerCar.PlateNumber);
                return _customerMapper.ToModel(customerData);
            }
        }

        public Customer GetCustomer(string TcNumber, string PlateNumber)
        {
            using (var db = new Data.MyInsuranceEntities())
            {
                var customerData = db.Customers.Include(o=> o.CustomerCar).FirstOrDefault(c => c.TCNumber == TcNumber && c.PlateNumber == PlateNumber);
                return _customerMapper.ToModel(customerData);
            }
        }
    }
}
