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
        double GetOffer()
        {
            double price = 1000.50;
            int x = new Random().Next(200, 700);
            return (price * x);
        }
    }
}
