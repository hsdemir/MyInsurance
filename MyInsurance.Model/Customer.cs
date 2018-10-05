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
        [Required]
        public string TcNumber { get; set; }
        [Required]
        public CustomerCar CustomerCar { get; set; }
    }
}
