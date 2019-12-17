using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClaimyWebApps.Models
{
    public class ZipCity
    {
        [Key]
        public string Zipcode { get; set; } //prim key

        //table fields
        public string City { get; set; }


    }
}