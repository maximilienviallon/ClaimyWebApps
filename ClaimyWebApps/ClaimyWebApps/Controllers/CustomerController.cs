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
            var customerProfileViewModel = new CustomerProfileViewModel
            {
                Customer = new Customer(),
                Claims = _context.Claims.ToList()
            };



            return View(customerProfileViewModel);
        }
    }
}