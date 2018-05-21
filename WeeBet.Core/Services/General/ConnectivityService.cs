using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using WeeBet.Core.Contracts.Services;

namespace WeeBet.Core.Services.General
{
    public class ConnectivityService : IConnectivityService
    {
        public bool CheckOnline()
        {
            return CrossConnectivity.Current.IsConnected;
        }
    }
}
