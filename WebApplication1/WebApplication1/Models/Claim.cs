using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Claim
    {

        [Required]
        public int ClaimID { get; set; }
        public int FeeID { get; set; }
        public string ReasonCode { get; set; }
        public string Comment { get; set; }
        public string LicensePlate { get; set; }
        public string DriversFirstName { get; set; }
        public string DriversSurname { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Appeal { get; set; }

        public Customer Customer { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
    }
}