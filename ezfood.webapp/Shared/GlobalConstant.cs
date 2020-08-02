using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ezfood.webapp.Shared
{
    public class GlobalConstant
    {

        // Khiem Xero
        //public const string ClientId = "5099DBA768B54244AA4D2FDA818981DA";
        //public const string ClientSecret = "zYqi-8-Ln8S5H5sG2TLp8zjINJAVY9WH2wnp6s4EUqfkNPNa";
        //public const string RedirectUrl = "https://localhost:44316/api"; //"https://localhost:5001/oauth"

        // Ezfood Xero - Dev
        public const string ClientId = "8FD7C604BFD64A7583A13CC8E65D11A9";
        public const string ClientSecret = "pZH0r5fQ4eUyFx4oRPTe8By8cXtj7mrhQQ1ZSFRFPyeS5MqL";
        //public const string RedirectUrl = "https://localhost:44316/api"; //"https://localhost:5001/oauth"
        public const string RedirectUrl = "https://localhost:44316/oauth"; //"https://localhost:5001/oauth"

        //public static string AppBaseUrl => $"{HttpRequest..Scheme}://{Request.Host}{Request.PathBase}";
    }
}
