using MyInsurance.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInsurance.Business.Interface
{
    public interface IOfferBusiness
    {
        double GetFromService();
        List<Offer> GetOfferList(string tcNumber);
        Offer Create();
        void Save(Offer offer);
    }
}
