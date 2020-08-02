using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ezfood.Models
{
    public class Tenant
    {
        [JsonProperty("id")]
        public Guid id { get; set; }
        [JsonProperty("tenantId")]
        public Guid TenantId { get; set; }
        [JsonProperty("tenantType")]
        public string TenantType { get; set; }
    }
}
