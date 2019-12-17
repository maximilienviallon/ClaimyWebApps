﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClaimyWebApps.Models
{
    public class Customer
    {
        
        [Key]
        public string Email { get; set; }

        //table fields
        public string Name { get; set; }
        public string Password { get; set; }

        



    }
}