using MyInsurance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInsurance.DataAccess.Interface
{
    public interface IOfferDataAccess
    {
        Offer GetOffer(int Id);
        List<Offer> GetCustomerOffers(string TcNumber);
        Offer Create(Offer offer);
    }
}
