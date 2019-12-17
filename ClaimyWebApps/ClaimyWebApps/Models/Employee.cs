using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClaimyWebApps.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; } //prim key

        //table fields
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }

       
        
        //bridge table connections
        public ICollection<Claim> Claims { get; set; } //Add to my cases
        
    }
}