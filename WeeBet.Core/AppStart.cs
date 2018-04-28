using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using WeeBet.Core.ViewModels;

namespace WeeBet.Core
{
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        public void Start(object hint = null)
        {
            ShowViewModel<ShowMatchesViewModel>();
        }
    }
}
