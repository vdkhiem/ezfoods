using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ezfood.webapp.Services.Interfaces
{
    public interface IDispatchService
    {
        Task<List<ezfood.webapp.Models.Dispatch>> GetDispatches();
        string XeroOAuthUrl();
    }
}
