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
        OfferBusiness _offerBusiness;
        public OfferController()
        {
            _offerBusiness = new OfferBusiness();
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
                return RedirectToAction("GetOffer");
            }

            //Teklif topla
            var offerList = _offerBusiness.GetAllCompanyOffers(customer);

            return RedirectToAction("OfferList", new { offerList = offerList });
        }

        public ActionResult OfferList(List<Offer> offerList)
        {
            return View(offerList);
        }
    }
}