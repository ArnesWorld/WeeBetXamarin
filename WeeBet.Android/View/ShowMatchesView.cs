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
using MvvmCross.Binding.Attributes;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.Droid.Views;
using MvvmCross.Droid.Views;
using WeeBet.Core.Contracts.ViewModels;
using WeeBet.Core.Models;
using WeeBet.Core.ViewModels;

namespace WeeBet.Android.Views
{

    [Activity(Label = "WeeBet", MainLauncher = false)]
    public class ShowMatchesView : MvxActivity<ShowMatchesViewModel>
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
        }

        protected override void OnViewModelSet()
        {    
            SetContentView(Resource.Layout.ShowMatchesView);

            MvxExpandableListView exList = (MvxExpandableListView)FindViewById(Resource.Id.expandable_match_list);
            MyExpandableListAdapter adapter = new MyExpandableListAdapter(this, (IMvxAndroidBindingContext)BindingContext, ViewModel);
            exList.SetAdapter(adapter);

            var set = this.CreateBindingSet<ShowMatchesView, ShowMatchesViewModel>();
            set.Bind(exList).To(vm => vm.Matches).For(el => el.ItemsSource);
            set.Apply();
            exList.ItemTemplateId = Resource.Layout.item_odds_header;
        }

        public class MyExpandableListAdapter : MvxExpandableListAdapter
        {

            public MyExpandableListAdapter(Context context, IMvxAndroidBindingContext bindingContext, ShowMatchesViewModel vm) : base(context, bindingContext)
            {
            }

            protected override global::Android.Views.View GetBindableView(global::Android.Views.View convertView, object dataContext, ViewGroup parent, int templateId)
            {             
                templateId = Resource.Layout.item_matches;
                return base.GetBindableView(convertView, dataContext, parent, templateId);
            }
      

            public override global::Android.Views.View GetChildView(int groupPosition,
                int childPosition, bool isLastChild, 
                global::Android.Views.View convertView, ViewGroup parent)
            {
                var item = this.GetRawItem(groupPosition, childPosition);
                if (childPosition == 0)
                {
                    IOddsItemViewModel ow = (IOddsItemViewModel)item;
                    ow.IsButtonsVisible = true;             
                }             
                return base.GetBindableView(convertView, item, parent, base.ItemTemplateId);
            }

            



        }


    }

  

}