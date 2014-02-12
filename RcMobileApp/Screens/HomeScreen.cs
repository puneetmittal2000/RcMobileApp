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
using Newtonsoft.Json;
using RcMobile.Android.Library.Repository;
using RcMobileApp.Adapter;
using RcMobile.Android.Library.ViewModels;
using RcMobileApp.Screens.RepairOrder;


namespace RcMobileApp.Screens
{
    [Activity(Label = "Ro List", Icon = "@drawable/caricon")]
    public class HomeScreen : ListActivity
    {
        private IList<TaskViewModel> _taskList { get; set; }
        private string _authenticationToken { get; set; }
        private string _shopId { get; set; }
        private string _shopOrgId { get; set; }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _authenticationToken = Intent.GetStringExtra("AuthToken");
            _shopId = Intent.GetStringExtra("ShopId");
            _shopOrgId = Intent.GetStringExtra("ShopOrgId");

            _taskList = new TaskRepository().GetTaskList(_authenticationToken, _shopId);
            ListAdapter = new TaskAdapter(this, _taskList);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            TaskViewModel taskSelected = _taskList.ElementAt(position);
            var task = new Intent(this, typeof(RoDetails));
            task.PutExtra("AuthToken", _authenticationToken);
            task.PutExtra("JobId", taskSelected.JobId);
            task.PutExtra("ShopId", _shopId);
            task.PutExtra("ShopOrgId", _shopOrgId);
            task.PutExtra("task", JsonConvert.SerializeObject(taskSelected));
            StartActivity(task);
        }
    }
}