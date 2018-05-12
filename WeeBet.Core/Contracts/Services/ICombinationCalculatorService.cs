using System;
using System.Collections.Generic;
using System.Text;
using WeeBet.Core.Models;

namespace WeeBet.Core.Contracts.Services
{
    public interface ICombinationCalculatorService
    {
        VendorValue CalculateCombination(Dictionary<Match, string> matchOutcomes);

        IEnumerable<Vendor> GetVendorsFromMatches(IEnumerable<Match> matches);
    }
}
