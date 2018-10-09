using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInsurance.Model
{
    public class Customer
    {
        public Customer()
        {
            Offers = new List<Offer>();
        }
        [Required]
        public string TCNumber { get; set; }
        public string PlateNumber { get; set; }
        [Required]
        public CustomerCar CustomerCar { get; set; }
        public List<Offer> Offers { get; set; }
    }
}
