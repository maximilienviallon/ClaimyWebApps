using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Owin.BuilderProperties;

namespace ClaimyWebApps.Models
{
    public class Claim
    {
        [Key]
        public int ClaimID { get; set; } //prim key

        //table fields
        public int FeeNum { get; set; }
        public string Transgression { get; set; }
        public string Remarks { get; set; }
        public string LicensePlate { get; set; }
        public string DriversFirstName { get; set; } 
        public string Address { get; set; } 
        public string PostCode { get; set; }
        public string Email { get; set; }
        public string Appeal { get; set; }
        public string GuardNumber { get; set; }
        public string Amount { get; set; }
        public string PaymentInfo { get; set; }

        //foreign keys
        

        public ICollection<Customer> Customers { get; set; } //Connected to customer
        public ICollection<Employee> Employees { get; set; } //added to this employee's watchlist
        public ICollection<ZipCity> ZipCities { get; set; } //zipcode - city



    }
}