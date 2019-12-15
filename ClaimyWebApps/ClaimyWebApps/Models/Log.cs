using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClaimyWebApps.Models
{
    public class Log
    {
        public int Id { get; set; }
        public Reply Reply { get; set; }
        public int ReplyId { get; set; }
        public Claim Claim { get; set; }
        public int ClaimId { get; set; }

    }
}