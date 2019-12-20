using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClaimyWebApps.Models;

namespace ClaimyWebApps.ViewModel
{
    public class ClaimformViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<ZipCity> ZipCities { get; set; }
        public Claim Claim { get; set; }
    }
}