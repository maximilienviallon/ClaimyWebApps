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
        //public int EmployeeID { get; set; }
        //public int ClaimID { get; set; } //in theory since every case will have a mail/user connected we dont need customerID field


        public ICollection<Employee> Employees { get; set; } //if written by employee
        public ICollection<Log> Logs { get; set; } //for proper logging
        public ICollection<Claim> Claims { get; set; } //Case on which reply has been made

    }
}