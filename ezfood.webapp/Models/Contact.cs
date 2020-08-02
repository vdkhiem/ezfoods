using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ezfood.webapp.Models
{
    public class Contact
    {
        [JsonProperty("ContactID")]
        public Guid ContactID { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}
