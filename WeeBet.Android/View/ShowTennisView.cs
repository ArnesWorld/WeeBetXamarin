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

namespace WeeBet.Android.View
{
    [Activity(Label = "ShowTennisView", MainLauncher = false)]
    public class ShowTennisView : MvxActivity<ShowTennisViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ShowTennisViewModel model = (ShowTennisViewModel)ViewModel;

            // Create your application here
        }
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.ShowTennisView);
        }
    }
}