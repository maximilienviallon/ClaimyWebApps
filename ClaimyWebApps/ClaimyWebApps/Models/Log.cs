using System;
using System.Collections.Generic;
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
        public int EmployeeID { get; set; }
        public int CustomerID { get; set; } //should be here, could log stuff unrelated to cases
        public int ClaimID { get; set; }

        public ICollectible<Customer> Customers; // Customer done something
        public ICollectible<Employee> Employees; //Employee done something
        public ICollectible<Reply> Replies; //Message happened
        public ICollectible<Claim> Claims; //on which case thing happened

    }
}