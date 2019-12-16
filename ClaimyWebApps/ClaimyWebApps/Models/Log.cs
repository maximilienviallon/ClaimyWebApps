using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClaimyWebApps.Models
{
    public class Log
    {
        [Required]
        public int LogID { get; set; } //prim key

        //table fields
        public int Type { get; set; }
        public int AdditionalInfo { get; set; }
        //foreign keys
        //public int EmployeeID { get; set; }
        //public int CustomerID { get; set; } //should be here, could log stuff unrelated to cases
        //public int ClaimID { get; set; }

        public ICollection<Customer> Customers { get; set; } // Customer done something
        public ICollection<Employee> Employees { get; set; } //Employee done something
        public ICollection<Reply> Replies { get; set; } //Message happened
        public ICollection<Claim> Claims { get; set; } //on which case thing happened

    }


}