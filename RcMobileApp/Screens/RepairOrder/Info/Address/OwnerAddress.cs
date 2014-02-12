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

namespace RcMobileApp.Screens.RepairOrder.Info.Address
{
    [Activity(Label = "Owner")]
    public class OwnerAddress : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.AddressLayout);
            var taskObject = JsonConvert.DeserializeObject<TaskViewModel>(Intent.GetStringExtra("task"));
            TextView Address = FindViewById<TextView>(Resource.Id.txtAddress);
            TextView Name = FindViewById<TextView>(Resource.Id.txtNameFirst);
            TextView City = FindViewById<TextView>(Resource.Id.txtCity);
            TextView Email = FindViewById<TextView>(Resource.Id.txtEmail);
            TextView PhoneHome = FindViewById<TextView>(Resource.Id.txtPhoneHome);
            TextView PostalCode = FindViewById<TextView>(Resource.Id.txtPostalCode);
            TextView ProvinceState = FindViewById<TextView>(Resource.Id.txtProvinceState);

            Address.Text = taskObject.Address.AddressLine;
            Name.Text = taskObject.OwnerFirstName + " " + taskObject.OwnerLastName;
            City.Text = taskObject.Address.City;
            Email.Text = taskObject.Address.OwnerEmail;
            PhoneHome.Text = taskObject.Address.OwnerWorkPhone;
            PostalCode.Text = taskObject.Address.PostalCode;
            ProvinceState.Text = taskObject.Address.Province;
        }
    }
}