using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClaimyWebApps.Controllers.API;


namespace ClaimyWebAppTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetAllClaims_ShouldReturnHttpNotFound()
        {
            
            var controller = new ClaimController(); 
            var result = controller.GetClaim(ClaimTestData());
            var comp = new System.Web.Mvc.HttpNotFoundResult();
            Assert.Equals(result, comp);
            
        }
        public int ClaimTestData()
        {
            int test = 0;
            return test;
        }

    }
}
