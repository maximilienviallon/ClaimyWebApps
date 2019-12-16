using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClaimyWebApps.Models
{
    public class Customer
    {
        ///got to check the webhooks
        [Required]
        public int CustomerID { get; set; } //prim key

        //table fields
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //What do we wanna store about them? Do we really need to know where they from and stuff?
        public string Address { get; set; } 
        public string PostCodeID { get; set; }

        //foreign keys

        //public int Claim { get; set; }
        //public string Type { get; set; }

        public ICollection<Claim> Claims { get; set; } // Claims connected to customer
        public ICollection<ZipCity> ZipCities { get; set; } //zipcode - city
        public ICollection<Reply> Replies { get; set; } //replies written by Customer
        public ICollection<Log> Logs { get; set; } //events triggered by customer




    }
}