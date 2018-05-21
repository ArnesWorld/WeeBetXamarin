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
using MvvmCross;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using WeeBet.Android.Services;
using WeeBet.Core;
using WeeBet.Core.Contracts.Repository;
using WeeBet.Core.Contracts.Services;
using WeeBet.Core.Repository;
using WeeBet.Core.Services;

namespace WeeBet.Android
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            var dbConn = FileAccessHelper.GetLocalFilePath("WeeBetDb");
            Mvx.RegisterSingleton<IFavouriteCompetitionsRepository>(new FavouriteCompetitionsRepository(dbConn));
            return new App();
        }

        protected override void InitializeIoC()
        {
            base.InitializeIoC();
            Mvx.RegisterSingleton<IDialogService>(() => new DialogService());
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();
          //  Mvx.RegisterType<IPopupService, DroidPopupService>();
        }
    }
}