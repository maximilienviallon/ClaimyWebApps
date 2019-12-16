using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClaimyWebApps.Models
{
    public class Employee
    {
        [Required]
        public int EmployeeID { get; set; } //prim key

        //table fields
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        //foreign keys


        public ICollectible<Claim> Claims; //Add to my cases
        public ICollectible<Log> Logs; //done something
        public ICollectible<Reply> Replies; //wrote reply
    }
}