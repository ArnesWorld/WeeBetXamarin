using System;
using System.Collections.Generic;
using System.Text;

namespace WeeBet.Core.Contracts.Services
{
    public interface IConnectivityService
    {
        bool CheckOnline();
    }
}
