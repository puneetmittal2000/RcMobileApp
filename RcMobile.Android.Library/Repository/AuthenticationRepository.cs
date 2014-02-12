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
using RcMobile.Core.Services;
using RcMobile.Android.Library.ViewModels;

namespace RcMobile.Android.Library.Repository
{
    public class AuthenticationRepository
    {
        private readonly IAuthenticate _repos;

        public AuthenticationRepository()
        {
            if (_repos == null)
            {
                _repos = new RcAuthenticationService();
            }
        }

        public UserCredential IsAuthenticated(string clientId, string userName, string password)
        {
            //Ignore the Server Certificate to call the Web service to login
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };

            //Calling the web service located in the core PCL library through interface
            var credencial = _repos.IsAuthenticated(clientId, userName, password);
            return new UserCredential
            {
                AuthToken = credencial.AuthToken,
                ShopId = credencial.ShopId,
                ShopOrgId = credencial.ShopOrgId
            };
        }
    }
}