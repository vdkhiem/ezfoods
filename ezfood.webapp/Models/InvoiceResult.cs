using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ezfood.webapp.Models
{
    public class InvoiceResult
    {

        [JsonProperty("Id")]
        public Guid Id { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("ProviderName")]
        public string ProviderName { get; set; }

        [JsonProperty("DateTimeUTC")]
        public string DateTimeUTC { get; set; }

        public List<Invoice> Invoices { get; set; }
    }
}
