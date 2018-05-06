using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using WeeBet.Core.ViewModels;

namespace WeeBet.Android.View
{
    [Activity(Label = "WeeBet", MainLauncher = false)]
    class ShowCompetitionsView : MvxActivity<ShowCompetitionsViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            ShowCompetitionsViewModel model = (ShowCompetitionsViewModel)ViewModel;
        }
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.ShowCompetitionsView);
        }
    }
}