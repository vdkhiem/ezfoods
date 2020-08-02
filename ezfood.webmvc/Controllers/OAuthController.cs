using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ezfood.webmvc.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ezfood.webmvc.Controllers
{
    [Route("/api")]
    [ApiController]
    public class OAuthController : Controller
    {

        private string clientId = "5099DBA768B54244AA4D2FDA818981DA";
        private string clientSecret = "zYqi-8-Ln8S5H5sG2TLp8zjINJAVY9WH2wnp6s4EUqfkNPNa";
        private string redirectUrl = "https://localhost:53456/api/oauth"; //"https://localhost:5001/oauth"
        // GET api/values
        [HttpGet]
        public ContentResult Get()
        {

            var xeroAuthorizeUri = new RequestUrl("https://login.xero.com/identity/connect/authorize");
            var url = xeroAuthorizeUri.CreateAuthorizeUrl(
             clientId: clientId,
             responseType: "code", //hardcoded authorisation code for now.
             redirectUri: redirectUrl,
             state: "your state",
             scope: "openid profile email files accounting.transactions accounting.transactions.read accounting.reports.read accounting.journals.read accounting.settings accounting.settings.read accounting.contacts accounting.contacts.read accounting.attachments accounting.attachments.read offline_access"
         );
            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = String.Format("<html><head></head><body><a href ='{0}'>Connect to Xero</a></body></html>", url)
            };
        }

        [HttpGet("api/oauth")]
        public async Task<ContentResult> Get(string code, string state)
        {
            var result = new ContentResult();
            var tenantList = new List<Tenant>();
            using (var client = new HttpClient())
            {
                var response = await client.RequestAuthorizationCodeTokenAsync(new AuthorizationCodeTokenRequest
                {
                    Address = "https://identity.xero.com/connect/token",
                    GrantType = "code",
                    Code = code,
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    RedirectUri = redirectUrl,
                    Parameters =
                    {
                        { "scope", "openid profile email files accounting.transactions accounting.transactions.read accounting.reports.read accounting.journals.read accounting.settings accounting.settings.read accounting.contacts accounting.contacts.read accounting.attachments accounting.attachments.read offline_access"}
                    }
                });

                if (response.IsError) { throw new Exception(response.Error); }
                var accessToken = response.AccessToken;
                var refreshToken = response.RefreshToken;
                var identityToken = response.IdentityToken;
                string tenant;
                string invoices;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                using (var requestMessage = new HttpRequestMessage(System.Net.Http.HttpMethod.Get, "https://api.xero.com/connections"))
                {
                    HttpResponseMessage httpResult = client.SendAsync(requestMessage).Result;
                    System.Console.WriteLine(httpResult.RequestMessage);
                    tenant = httpResult.Content.ReadAsStringAsync().Result;
                    tenantList = JsonConvert.DeserializeObject<List<Tenant>>(tenant);
                }
                string data = "";
                foreach (Tenant t in tenantList)
                {
                    using (var requestMessage = new HttpRequestMessage(System.Net.Http.HttpMethod.Get, "https://api.xero.com/api.xro/2.0/Invoices"))
                    {
                        requestMessage.Headers.Add("xero-tenant-id", t.TenantId.ToString());
                        HttpResponseMessage httpResult = client.SendAsync(requestMessage).Result;
                        System.Console.WriteLine(httpResult.RequestMessage);
                        invoices = httpResult.Content.ReadAsStringAsync().Result;
                        data = data + invoices;
                    }
                    var content = String.Format(@"<html><head></head><body>
            <h3>AccessToken</h3><p>{0}</p>
            <h3>RefreshToken</h3><p>{1}</p>
            <h3>IdentityToken</h3><p>{2}</p>
            <h3>Tenant</h3><p>{3}</p>
            <h3>Invoice Data</h3><p>{4}</p>
            </body></html>", accessToken, refreshToken, identityToken, tenant, invoices);
                    result.Content = content;
                    result.ContentType = "text/html";

                }
            }
            return result;
        }
    }
}
