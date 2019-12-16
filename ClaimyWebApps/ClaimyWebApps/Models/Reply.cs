using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClaimyWebApps.Models
{
    public class Reply
    {
        [Required]
        public int ReplyID { get; set; } //prim key

        //table fields
        
        public string ReplyText { get; set; }

        //foreign keys
        public int EmployeeID { get; set; }
        public int ClaimID { get; set; } //in theory since every case will have a mail/user connected we dont need customerID field


        public ICollectible<Employee> Employees; //if written by employee
        public ICollectible<Log> Logs; //for proper logging
        public ICollectible<Claim> Claims; //Case on which reply has been made

    }
}