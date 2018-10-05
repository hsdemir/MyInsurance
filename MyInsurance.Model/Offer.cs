using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInsurance.Model
{
    public class Offer
    {
        public int Id { get; set; }
        public string CustomerTcNumber { get; set; }
        public int CompanyId { get; set; }
        public string Description { get; set; }
        public Company Company { get; set; }
        public Customer Customer { get; set; }
        public OfferDetail OfferDetail { get; set; }
    }
}
