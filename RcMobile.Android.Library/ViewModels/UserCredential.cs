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

namespace RcMobile.Android.Library.ViewModels
{
    public class UserCredential
    {
        public string AuthToken { get; set; }

        public string ShopId { get; set; }

        public string ShopOrgId { get; set; }
    }
}