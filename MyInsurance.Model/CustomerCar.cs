using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInsurance.Model
{
   public class CustomerCar
    {
        [Required]
        public string PlateNumber { get; set; }
        [Required]
        public string LicenseSerialCode { get; set; }
        [Required]
        public string LicenseSerialNumber { get; set; }
    }
}
