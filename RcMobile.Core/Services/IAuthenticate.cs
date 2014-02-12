using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RcMobile.Core.Entities;

namespace RcMobile.Core.Services
{
    public interface IAuthenticate : IDisposable
    {
        LoginResponse IsAuthenticated(string clientId, string userName, string password);
    }
}
