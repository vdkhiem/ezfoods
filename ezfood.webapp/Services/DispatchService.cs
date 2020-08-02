using ezfood.webapp.Services.Interfaces;
using ezfood.webapp.Shared;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ezfood.webapp.Services
{
    public class DispatchService : IDispatchService
    {
        public async Task <List<ezfood.webapp.Models.Dispatch>> GetDispatches()
        {
            
            var dispatches = new List<ezfood.webapp.Models.Dispatch>()
            {
                new Models.Dispatch { Id = 1, CustomerName = "Khiem 1", OrderNumber = "1234", DispatchDate=DateTime.Now.ToString()},
                new Models.Dispatch { Id = 2, CustomerName = "Khiem 2", OrderNumber = "1235", DispatchDate=DateTime.Now.ToString()},
                new Models.Dispatch { Id = 3, CustomerName = "Khiem 3", OrderNumber = "1236", DispatchDate=DateTime.Now.ToString()},
            };

            return await Task.FromResult(dispatches) ;
        }

        public string XeroOAuthUrl()
        {
            var xeroAuthorizeUri = new RequestUrl("https://login.xero.com/identity/connect/authorize");
            var url = xeroAuthorizeUri.CreateAuthorizeUrl(
             clientId: GlobalConstant.ClientId,
             responseType: "code", //hardcoded authorisation code for now.
             redirectUri: GlobalConstant.RedirectUrl,
             state: "your state",
             scope: "openid profile email files accounting.transactions accounting.transactions.read accounting.reports.read accounting.journals.read accounting.settings accounting.settings.read accounting.contacts accounting.contacts.read accounting.attachments accounting.attachments.read offline_access"
            );

            return url;
        }
    }
}
