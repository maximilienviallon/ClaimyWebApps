using ClaimyWebApps.Models;
using ClaimyWebApps.ViewModel;
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

        public ActionResult NewClaim()
        {
            var customers = _context.Customers.ToList();
            var zipcities = _context.ZipCities.ToList();
            var viewModel = new ClaimformViewModel()
            {
                Customers = customers,
                ZipCities = zipcities,
                Claim = new Claim()
                
            };
            return View("NewClaim", viewModel);
        }
        public ActionResult Save(Claim claim)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ClaimformViewModel
                {
                    Claim = claim,
                    ZipCities = _context.ZipCities.ToList(),
                    Customers = _context.Customers.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if(claim.ID == 0)
            {
                _context.Claims.Add(claim);
            }
            else
            {
                var claimInDb = _context.Claims.Single(c => c.ID == claim.ID);
                claimInDb.FeeNum = claim.FeeNum;
                claimInDb.Transgression = claim.Transgression;
                claimInDb.Remarks = claim.Remarks;
                claimInDb.LicensePlate = claim.LicensePlate;
                claimInDb.DriversFirstName = claim.DriversFirstName;
                claimInDb.Address= claim.Address;
                claimInDb.Appeal = claim.Appeal;
                claimInDb.GuardNumber = claim.GuardNumber;
                claimInDb.Amount = claim.Amount;
                claimInDb.PaymentInfo = claim.PaymentInfo;
                claimInDb.Zipcode= claim.Zipcode;
                claimInDb.CustomerEmail = claim.CustomerEmail;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Claim");
        }
    }
}