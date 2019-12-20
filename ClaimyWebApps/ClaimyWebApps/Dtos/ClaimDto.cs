using ClaimyWebApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ClaimyWebApps.Dtos
{
    public class ClaimDto
    {
        public int ID { get; set; }

        public int? FeeNum { get; set; }
        public string Transgression { get; set; }
        public string Remarks { get; set; }
        public string LicensePlate { get; set; }
        public string DriversFirstName { get; set; }
        public string Address { get; set; }
        public string Appeal { get; set; }
        public string GuardNumber { get; set; }
        public string Amount { get; set; }
        public string PaymentInfo { get; set; }

        public ZipCityDto ZipCity { get; set; }
        public string Zipcode { get; set; }
        public CustomerDto Customer { get; set; }
        public string CustomerEmail { get; set; }

    }
}