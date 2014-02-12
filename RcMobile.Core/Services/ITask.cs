using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RcMobile.Core.Entities;


namespace RcMobile.Core.Services
{
    public interface ITask : IDisposable
    {
        IList<RcMobile.Core.Entities.Task> GetTaskList(string authToken, string clientId);
        InsuredDetails Details(string authToken, string shopOrgId, string clientId, string jobId);
        InsuredDetails GetRoClaimantDetails(string authToken, string shopOrgId, string clientId, string jobId);
    }
}
