using MyInsurance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInsurance.Business.Interface
{
    public interface IOfferBusiness
    {
        List<Offer> GetAllCompanyOffers(Customer customer);
        List<Offer> GetCustomerOffers(string TcNumber);
        void Create(Offer offer);
    }
}
