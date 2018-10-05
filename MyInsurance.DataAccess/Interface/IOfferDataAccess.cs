using MyInsurance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInsurance.DataAccess.Interface
{
    public interface IOfferDataAccess
    {
        Model.Offer GetOffer(int Id);
        List<Model.Offer> GetCustomerOffers(string TcNumber);
        void Create(Model.Offer offer);
    }
}
