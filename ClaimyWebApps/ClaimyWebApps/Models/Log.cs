using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClaimyWebApps.Models
{
    public class Log
    {
        [Key]
        public int LogID { get; set; } //prim key

        //table fields
        public int Type { get; set; }
        public int AdditionalInfo { get; set; }
        //foreign keys


        public ICollection<Customer> Customers { get; set; } // Customer done something
        public ICollection<Employee> Employees { get; set; } //Employee done something
        public ICollection<Reply> Replies { get; set; } //Message happened
        public ICollection<Claim> Claims { get; set; } //on which case thing happened

    }


}