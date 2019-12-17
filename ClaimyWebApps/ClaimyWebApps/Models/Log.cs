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
        public int ID { get; set; } //prim key

        //table fields
        public string Type { get; set; }
        public string AdditionalInfo { get; set; }
        //foreign keys

        public Customer Customer { get; set; }
        public string CustomerEmail { get; set; }
        public Employee Employee { get; set; }
        public int? EmployeeID { get; set; }
        public Reply Reply { get; set; }
        public int? ReplyID { get; set; }
        public Claim Claim { get; set; }
        public int? ClaimID { get; set; }


    }


}