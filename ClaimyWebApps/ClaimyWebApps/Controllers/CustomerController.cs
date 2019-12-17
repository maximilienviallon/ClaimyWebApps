using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClaimyWebApps.Models;
using ClaimyWebApps.ViewModel;

namespace ClaimyWebApps.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoggedInMainPage()
        {
            var customer = new Customer();
            var claims = _context.Claims.ToList();
            List<Claim> ToBeDeleted = new List<Claim>();
            foreach (Claim Line in claims)
            { 
            if(Line.CustomerEmail.Equals("max@gmail.com"))
                {
                    ToBeDeleted.Add(Line);
                }
            }
            foreach (Claim Line in ToBeDeleted)
            {
                claims.Remove(Line);
            }
            var customerProfileViewModel = new CustomerProfileViewModel
                {
                    Customer = customer,
                    Claims = claims
            };



            return View(customerProfileViewModel);
        }
    }
}