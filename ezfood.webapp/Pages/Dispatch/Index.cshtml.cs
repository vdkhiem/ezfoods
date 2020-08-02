using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ezfood.webapp.Models;
using ezfood.webapp.Services;
using ezfood.webapp.Services.Interfaces;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models = ezfood.webapp.Models;

namespace ezfood.webapp.Pages.Dispatch
{
    public class IndexModel : PageModel
    {
        private IDispatchService dispatchService;
        public IndexModel()
        {
            dispatchService = new DispatchService();
        }

        public InvoiceResult InvoiceResult { get; set; }

        public void OnGet()
        {
            if (HttpContext.Session.GetString("Invoices") == null)
            {
                var oauthUrl = dispatchService.XeroOAuthUrl();
                Redirect(oauthUrl);
            }
            else
            {
                InvoiceResult = System.Text.Json.JsonSerializer.Deserialize<InvoiceResult>(HttpContext.Session.GetString("Invoices"));
                InvoiceResult.Invoices = InvoiceResult.Invoices.Where(row => DateTime.Parse(row.DateString) >= DateTime.Now).ToList();
            }
        }
    }
}
