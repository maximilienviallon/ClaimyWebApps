using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClaimyWebApps.Models;

namespace ClaimyWebApps.ViewModel
{
    public class CustomerProfileViewModel
    { 
        public List<Claim> Claims { get; set; }
        public Customer Customer { get; set; }
    }
}