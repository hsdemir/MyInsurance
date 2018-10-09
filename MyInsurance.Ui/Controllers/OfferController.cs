using MyInsurance.Business.Business;
using MyInsurance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyInsurance.Ui.Controllers
{
    public class OfferController : Controller
    {
        CustomerBusiness _customerBusiness;
        OfferBusiness _offerBusiness;
        public OfferController()
        {
            _customerBusiness = new CustomerBusiness();
            _offerBusiness = new OfferBusiness();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetOffer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetOffer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToRoute("TeklifAl");
            }

            //Önce müşteri bilgilerini kaydet
            customer = _customerBusiness.Create(customer);

            //Teklif topla
            var offerList = _offerBusiness.GetAllCompanyOffers(customer);
            TempData["OfferList"] = offerList;

            return RedirectToRoute("Teklifler");
        }

        public ActionResult OfferList()
        {
            var offerList = TempData["OfferList"] as List<Offer>;
            return View(offerList);
        }
    }
}