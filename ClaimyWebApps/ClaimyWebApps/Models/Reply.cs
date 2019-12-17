using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClaimyWebApps.Models
{
    public class Reply
    {
        [Key]
        public int ID { get; set; } //prim key

        //table fields
        
        public string ReplyText { get; set; }

        //foreign keys
        public Employee Employee { get; set; }
        public int? EmployeeID { get; set; }
        public Claim Claim { get; set; }
        public int? ClaimID { get; set; } //in theory since every case will have a mail/user connected we don't need customerID field
        
    }
}