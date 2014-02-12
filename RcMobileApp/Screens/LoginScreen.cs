using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using RcMobile.Android.Library.Repository;

namespace RcMobileApp.Screens
{
    [Activity(Label = "RcMobileApp", MainLauncher = true, Icon = "@drawable/caricon")]
    public class LoginScreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login);
            Button button = FindViewById<Button>(Resource.Id.login_button);
            EditText txtClientId = FindViewById<EditText>(Resource.Id.txtClientId);
            EditText txtUserName = FindViewById<EditText>(Resource.Id.txtUserId);
            EditText txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);

            // Get our button from the layout resource,
            // and attach an event to it
            button.Click += delegate
            {
                if (string.IsNullOrWhiteSpace(txtClientId.Text) || string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    Toast.MakeText(this, "Please enter all details.", ToastLength.Long).Show();
                }
                else
                {
                    System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };
                    var userCredential = new AuthenticationRepository().IsAuthenticated(txtClientId.Text, txtUserName.Text, txtPassword.Text);
                    if (userCredential.ShopId != null)
                    {
                        var taskList = new Intent(this, typeof(HomeScreen));
                        taskList.PutExtra("AuthToken", userCredential.AuthToken);
                        taskList.PutExtra("ShopId", userCredential.ShopId);
                        taskList.PutExtra("ShopOrgId", userCredential.ShopOrgId);
                        StartActivity(taskList);
                    }
                    else
                    {
                        Toast.MakeText(this, "Login failed", ToastLength.Short).Show();
                        Toast.MakeText(this, "Please enter correct credentials", ToastLength.Long).Show();
                        txtClientId.Text = null;
                        txtUserName.Text = null;
                        txtPassword.Text = null;

                    }
                }
            };
        }
    }
}

