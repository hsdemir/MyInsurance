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
    public class OfferController : ApiController
    {
        OfferBusiness _offerBusiness;
        CompanyBusiness _companyBusiness;
        public OfferController()
        {
            _offerBusiness = new OfferBusiness();
            _companyBusiness = new CompanyBusiness();
        }

        [HttpPost]
        public Offer GetAllianzOffer(Customer customer)
        {
            //Şirket bilgisi getir
            var company = _companyBusiness.GetCompany(1);

            //Teklif tutarı hesapla
            var offerDetail = new OfferDetail();
            int x = new Random().Next(200, 700);
            offerDetail.Price = 1000 + x;

            //Teklifi doldur
            var offer = new Offer();
            offer.Description = "Allianz Kasko Teklifi";
            offer.CompanyId = company.Id;
            offer.CustomerTcNumber = customer.TCNumber;
            offer.OfferDetail = offerDetail;

            return offer;
        }

        [HttpPost]
        public Offer GetAxaOffer(Customer customer)
        {
            //Şirket bilgisi getir
            var company = _companyBusiness.GetCompany(2);

            //Teklif tutarı hesapla
            var offerDetail = new OfferDetail();
            int x = new Random().Next(200, 700);
            offerDetail.Price = 1000 + x;

            //Teklifi doldur
            var offer = new Offer();
            offer.Description = "Axa Kasko Teklifi";
            offer.CustomerTcNumber = customer.TCNumber;
            offer.CompanyId = company.Id;
            offer.OfferDetail = offerDetail;

            return offer;
        }

        [HttpPost]
        public Offer GetAcibademOffer(Customer customer)
        {
            //Şirket bilgisi getir
            var company = _companyBusiness.GetCompany(3);

            //Teklif tutarı hesapla
            var offerDetail = new OfferDetail();
            int x = new Random().Next(200, 700);
            offerDetail.Price = 1000 + x;

            //Teklifi doldur
            var offer = new Offer();
            offer.Description = "Acıbadem Sigorta Kasko Teklifi";
            offer.CustomerTcNumber = customer.TCNumber;
            offer.CompanyId = company.Id;
            offer.OfferDetail = offerDetail;

            return offer;
        }

        public List<Offer> GetCustomerOffers(string TcNumber)
        {
            return _offerBusiness.GetCustomerOffers(TcNumber);
        }
    }
}
