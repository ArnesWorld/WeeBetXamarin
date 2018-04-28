using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;
using WeeBet.Core.ViewModels;

namespace WeeBet.Android.Views
{
    [Activity(Label = "WeeBet", MainLauncher = true)]
    public class ShowMatchesView : MvxActivity<ShowMatchesViewModel>
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.ShowMatchesView);
        }
    }
}