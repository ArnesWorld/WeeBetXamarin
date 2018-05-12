using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeeBet.Core.Models;
using WeeBet.Core.Services.General;

namespace WeeBet.Core.UnitTests.GeneralServicesTests
{
    [TestClass]
    public class CombinationCalcTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Vendor vendorA = new Vendor() { Name = "VENDOR-A" };
            Vendor vendorB = new Vendor() { Name = "VENDOR-B" };
            Odds o1 = new Odds() { Odds1 = 2.1, OddsX = 2.2, Odds2 = 2.3, Vendor = vendorA };
            Odds o2 = new Odds() { Odds1 = 3.1, OddsX = 3.2, Odds2 = 3.3, Vendor = vendorB };
            List<Odds> odds1 = new List<Odds>();
            odds1.Add(o1); odds1.Add(o2);
            Odds o3 = new Odds() { Odds1 = 2.1, OddsX = 2.2, Odds2 = 2.3, Vendor = vendorA };
            Odds o4 = new Odds() { Odds1 = 3.1, OddsX = 3.2, Odds2 = 3.3, Vendor = vendorB };
            List<Odds> odds2 = new List<Odds>();
            odds2.Add(o3); odds2.Add(o4);
            Match m1 = new Match() { Odds = odds1 };
            Match m2 = new Match() { Odds = odds2 };

            Dictionary<Match, string> matchOutcomes = new Dictionary<Match, string>();
            matchOutcomes.Add(m1, "1");
            matchOutcomes.Add(m2, "x");

            CombinationCalculator combCalc = new CombinationCalculator();
            VendorValue res = combCalc.CalculateCombination(matchOutcomes);
            Assert.AreEqual("VENDOR-B", res.Vendor.Name);

        }
    }
}
