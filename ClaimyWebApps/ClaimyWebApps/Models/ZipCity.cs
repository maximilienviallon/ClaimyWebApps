using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClaimyWebApps.Models
{
    public class ZipCity
    {
        [Required]
        public int Zipcode { get; set; } //prim key

        //table fields
        public string City { get; set; }

        public ICollectible<Customer> Customers; //zip code - city
        public ICollectible<Claim> Claims; // zipcode - city
    }
}