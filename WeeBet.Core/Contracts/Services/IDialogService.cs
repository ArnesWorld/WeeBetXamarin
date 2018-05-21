using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeeBet.Core.Contracts.Services
{
    public interface IDialogService
    {
        void ShowAlert(string message, string title, string buttonText);
    }
}
