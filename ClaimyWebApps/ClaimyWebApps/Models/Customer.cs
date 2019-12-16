using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClaimyWebApps.Models
{
    public class Customer
    {
        [Required]
        public int CustomerID { get; set; } //prim key

        //table fields
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //What do we wanna store about them? Do we really need to know where they from and stuff?
        public string Address { get; set; } 
        public string PostCode { get; set; }

        //foreign keys

        public ICollectible<Claim> Claims; // Claims connected to customer
        public ICollectible<ZipCity> ZipCities; //zipcode - city
        public ICollectible<Reply> Replies; //replies written by Customer
        public ICollectible<Log> Logs; //events triggered by customer




    }
}