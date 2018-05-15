using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.UI;
using MvvmCross.Plugins.Messenger;
using System;
using System.Collections.Generic;
using System.Text;
using WeeBet.Core.Models;

namespace WeeBet.Core.Contracts.ViewModels
{
    public interface IOddsItemViewModel
    {
        bool IsButtonsVisible { get; set; }
        Odds Odds { get; set; }
        IMvxMessenger Messenger { get; set; }
        MvxColor BackgroundColor1 { get; set; }
        MvxColor BackgroundColor2 { get; set; }
        MvxColor BackgroundColorX { get; set; }
        IMvxCommand<string> OutcomeClickedCommand { get; set; }
    }
}
