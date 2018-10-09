using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInsurance.Model
{
    public class CustomerCar
    {
        [DisplayName("Plaka"), Required, MaxLength(12)]
        public string PlateNumber { get; set; }
        [DisplayName("Ruhsat Seri Kodu"), Required]
        public string LicenseSerialCode { get; set; }
        [DisplayName("Ruhsat Seri No"), Required]
        public string LicenseSerialNumber { get; set; }
    }
}
