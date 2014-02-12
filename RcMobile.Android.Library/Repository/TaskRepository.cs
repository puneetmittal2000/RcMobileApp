using System.Collections.Generic;
using RcMobile.Android.Library.ViewModels;
using RcMobile.Core.Entities;
using RcMobile.Core.Services;

namespace RcMobile.Android.Library.Repository
{
    public class TaskRepository
    {
        private readonly ITask _repos;

        public TaskRepository()
        {
            if (_repos == null)
            {
                _repos = new RcMobileService();
            }
        }

        public List<TaskViewModel> GetTaskList(string authToken, string clientId)
        {
            //Ignore the Server Certificate to call the Web service to login
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };

            //calling web service located at core PCL library
            var data = _repos.GetTaskList(authToken, clientId);
            var result = new List<TaskViewModel>();
            var id = 0;
            foreach (var item in data)
            {
                result.Add(new TaskViewModel
                {
                    Id = id++,
                    RoNumber = item.RoNumber,
                    JobId = item.JobId,
                    VehicleYear = item.VehicleYear,
                    VehicleMake = item.VehicleMake,
                    VehicleLicense = item.VehicleLicense,
                    VehicleVin = item.VehicleVin,
                    VehicleLicenseState = item.VehicleLicenseState,
                    ClaimNumber = item.ClaimNumber,
                    InsuranceCompanyName = item.InsuranceCompanyName,
                    DueOut = item.DueOut,
                    ArrivedDate = item.ArrivedDate,
                    OwnerFirstName = item.OwnerFirstName,
                    OwnerLastName = item.OwnerLastName,
                    Address = new AddressViewModel
                    {
                        AddressLine = item.Address.AddressLine,
                        City = item.Address.City,
                        Province = item.Address.Province,
                        PostalCode = item.Address.PostalCode,
                        OwnerWorkPhone = item.Address.OwnerWorkPhone,
                        OwnerEmail = item.Address.OwnerEmail
                    }
                });
            }
            return result;
        }



        public InsuredDetailsViewModel Details(string authToken, string shopOrgId, string clientId, string jobId)
        {
            //Ignore the Server Certificate to call the Web service to login
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };
            //System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };


            var data = _repos.Details(authToken, shopOrgId, clientId, jobId);
            return new InsuredDetailsViewModel
            {
                NameFirst = data.NameFirst,
                NameLast = data.NameLast,
                Address1 = data.Address1,
                Address2 = data.Address2,
                City = data.City,
                PhoneHome = data.PhoneHome,
                Email = data.Email,
                ProvinceState = data.ProvinceState,
                PostalCode = data.PostalCode
            };
        }

        public InsuredDetailsViewModel GetRoClaimantDetails(string authToken, string shopOrgId, string clientId, string jobId)
        {
            //Ignore the Server Certificate to call the Web service to login
            System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };
            //System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };


            var data = _repos.GetRoClaimantDetails(authToken, shopOrgId, clientId, jobId);
            return new InsuredDetailsViewModel
            {
                NameFirst = data.NameFirst,
                NameLast = data.NameLast,
                Address1 = data.Address1,
                Address2 = data.Address2,
                City = data.City,
                PhoneHome = data.PhoneHome,
                Email = data.Email,
                ProvinceState = data.ProvinceState,
                PostalCode = data.PostalCode
            };
        }

        protected void Dispose()
        {
            if (_repos != null)
            {
                _repos.Dispose();
            }
        }
    }
}