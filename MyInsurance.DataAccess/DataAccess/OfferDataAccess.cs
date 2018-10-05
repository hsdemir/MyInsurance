using MyInsurance.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyInsurance.Model;
using MyInsurance.DataAccess.Mappers;

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
                //Müşteri daha önce eklenmişse tekrar eklemeye çalışma
                var customer = db.Customers.FirstOrDefault(c => c.TCNumber == offerData.Customer.TCNumber);
                if (customer != null)
                {
                    //Müşteriye ait aynı araç daha önce eklendi ise tekrar eklemeye çalışma
                    offerData.CustomerTcNumber = customer.TCNumber;
                    var customerCar = db.CustomerCars.FirstOrDefault(c => c.PlateNumber == customer.PlateNumber);
                    if (customerCar != null)
                    {
                        offerData.Customer.PlateNumber = customerCar.PlateNumber;
                    }
                }

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
