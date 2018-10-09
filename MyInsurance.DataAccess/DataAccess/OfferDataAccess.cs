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
    public class OfferDataAccess : IOfferDataAccess
    {
        OfferMapper _offerMapper;
        public OfferDataAccess()
        {
            _offerMapper = new OfferMapper();
        }
        public void Create(Offer offer)
        {
            var offerData = _offerMapper.ToData(offer);
            using (var db = new Data.MyInsuranceEntities())
            {
                db.Offers.Add(offerData);
                db.SaveChanges();
            }
        }

        public List<Offer> GetCustomerOffers(string TcNumber)
        {
            using (var db = new Data.MyInsuranceEntities())
            {
                var offerData = db.Offers.Where(o => o.CustomerTcNumber == TcNumber).ToList();
                var offerModel = _offerMapper.ToModelList(offerData);
                return offerModel;
            }
        }

        public Offer GetOffer(int Id)
        {
            using (var db = new Data.MyInsuranceEntities())
            {
                var offerData = db.Offers.FirstOrDefault(o => o.Id == Id);
                return _offerMapper.ToModel(offerData);
            }
        }
    }
}
