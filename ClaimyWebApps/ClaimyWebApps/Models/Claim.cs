using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.Owin.BuilderProperties;

namespace ClaimyWebApps.Models
{
    public class Claim
    {
        [Key]
        public int ID { get; set; } //prim key

        //table fields
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

        //foreign keys
        public ZipCity ZipCity { get; set; }
        public string Zipcode { get; set; }
        public Customer Customer { get; set; }
        public string CustomerEmail { get; set; }

        //bridge table connections 
        public ICollection<Employee> Employees { get; set; } //added to this employee's watchlist



    }
}