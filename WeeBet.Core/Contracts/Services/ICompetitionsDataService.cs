using System;
using System.Collections.Generic;
using System.Text;
using WeeBet.Core.Models;

namespace WeeBet.Core.Contracts.Services
{
    public interface ICompetitionsDataService
    {
        List<Competition> GetCompetitionsBySportId(int id);
    }
}
