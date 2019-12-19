using ClaimyWebApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClaimyWebApps.Controllers
{
    public class ClaimController : Controller
    {
        private ApplicationDbContext _context;
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ClaimController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Claim
        public ActionResult Index()
        {

            
            return View();
        }
    }
}