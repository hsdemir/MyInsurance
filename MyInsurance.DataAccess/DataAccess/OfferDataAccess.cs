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
        public Offer Create(Offer offer)
        {
            var offerData = _offerMapper.ToData(offer);
            using (var db = new Data.MyInsuranceEntities())
            {
                db.Offers.Add(offerData);
                db.SaveChanges();

                offerData = db.Offers
                            .Include(o => o.Customer)
                            .Include(o => o.Customer.CustomerCar)
                            .Include(o => o.Company)
                            .OrderByDescending(o => o.Id).First();

                offerData.Customer.Offers = null;
                offerData.Company.Offers = null;

                return _offerMapper.ToModel(offerData);
            }
        }

        public List<Offer> GetCustomerOffers(string TcNumber)
        {
            using (var db = new Data.MyInsuranceEntities())
            {
                var offerData = db.Offers
                                .Include(o=> o.OfferDetail)
                                .Include(o => o.Customer)
                                .Include(o => o.Customer.CustomerCar)
                                .Include(o => o.Company)
                                .Where(o => o.CustomerTcNumber == TcNumber)
                                .ToList();

                offerData.ForEach(o => o.Customer.Offers = null);
                offerData.ForEach(o => o.Company.Offers = null);

                return _offerMapper.ToModelList(offerData);
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
