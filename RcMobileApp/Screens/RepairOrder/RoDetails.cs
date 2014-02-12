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
using RcMobile.Android.Library.ViewModels;
using Newtonsoft.Json;
using RcMobile.Android.Library.Repository;

namespace RcMobileApp.Screens.RepairOrder
{
    [Activity(Label = "Task Details", Icon = "@drawable/caricon")]
    public class RoDetails : TabActivity
    {
        private string _authenticationToken { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.RoDetails);
            CreateTab(typeof(Screens.RepairOrder.Info.InfoDetails), "Info", "Info", Resource.Drawable.tab_element);
            CreateTab(typeof(Screens.RepairOrder.Status.StatusDetails), "Status", "Status", Resource.Drawable.tab_element);
            CreateTab(typeof(Screens.RepairOrder.Photos.PhotoDetails), "Photos", "Photos", Resource.Drawable.tab_element);
            CreateTab(typeof(Screens.RepairOrder.Tasks.TasksDetails), "Tasks", "Tasks", Resource.Drawable.tab_element);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.default_actionbar_menu, menu);
            this.ActionBar.SetDisplayShowHomeEnabled(true);
            this.ActionBar.SetDisplayHomeAsUpEnabled(true);
            this.ActionBar.SetHomeButtonEnabled(true);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnMenuItemSelected(int featureId, IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_refresh:
                    Toast.MakeText(this, "Refreshing RO Details..", ToastLength.Long).Show();
                    return true;
            }
            return base.OnMenuItemSelected(featureId, item);
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();          
        }


        private void CreateTab(Type activityType, string tag, string label, int drawableId)
        {
            var taskObject = JsonConvert.DeserializeObject<TaskViewModel>(Intent.GetStringExtra("task"));
            var ShopId = Intent.GetStringExtra("ShopId");
            var ShopOrgId = Intent.GetStringExtra("ShopOrgId");
            var JobId = Intent.GetStringExtra("JobId");
            _authenticationToken = Intent.GetStringExtra("AuthToken");

            if (tag == "Info")
            {
                var intent = new Intent(this, activityType);
                intent.PutExtra("task", JsonConvert.SerializeObject(taskObject));
                intent.PutExtra("ShopId", ShopId);
                intent.PutExtra("ShopOrgId", ShopOrgId);
                intent.PutExtra("JobId", JobId);
                intent.PutExtra("AuthToken", _authenticationToken);
                intent.AddFlags(ActivityFlags.NewTask);
                var spec = TabHost.NewTabSpec(tag);
                var drawableIcon = Resources.GetDrawable(drawableId);
                spec.SetIndicator(label, drawableIcon);
                spec.SetContent(intent);

                TabHost.AddTab(spec);
            }
            else
            {
                var intent = new Intent(this, activityType);
                string RoNumber = taskObject.RoNumber;
                intent.PutExtra("task", RoNumber);
                intent.AddFlags(ActivityFlags.NewTask);
                var spec = TabHost.NewTabSpec(tag);
                var drawableIcon = Resources.GetDrawable(drawableId);
                spec.SetIndicator(label, drawableIcon);
                spec.SetContent(intent);

                TabHost.AddTab(spec);

            }
        }
    }
}