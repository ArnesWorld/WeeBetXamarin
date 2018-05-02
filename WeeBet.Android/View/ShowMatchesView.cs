using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Interop;
using Java.Lang;
using MvvmCross;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Views;
using WeeBet.Core.ViewModels;

namespace WeeBet.Android.Views
{

    [Activity(Label = "WeeBet", MainLauncher = false)]
    public class ShowMatchesView : MvxActivity<ShowMatchesViewModel>
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            ShowMatchesViewModel model = (ShowMatchesViewModel)ViewModel;

        }
        protected override void OnViewModelSet()
        {    
            SetContentView(Resource.Layout.ShowMatchesView);    
        }

        
    }
  
}