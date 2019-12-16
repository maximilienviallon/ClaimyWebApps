using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClaimyWebApps.Models
{
    public class Customer
    {
        //got to check the webhooks
        [Key]
        public int CustomerID { get; set; } //prim key

        //table fields
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //foreign keys

        public ICollection<Claim> Claims { get; set; } // Claims connected to customer
        public ICollection<ZipCity> ZipCities { get; set; } //zipcode - city
        public ICollection<Reply> Replies { get; set; } //replies written by Customer that should be replies from the lawyers
        public ICollection<Log> Logs { get; set; } //events triggered by customer




    }
}