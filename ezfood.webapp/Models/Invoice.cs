using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ezfood.webapp.Models
{
    public class Invoice
    {
        [JsonProperty("ContactID")]
        public Guid InvoiceID { get; set; }

        [JsonProperty("Name")]
        public string Type { get; set; }

        [JsonProperty("InvoiceNumber")]
        public string InvoiceNumber { get; set; }

        [JsonProperty("AmountDue")]
        public decimal AmountDue { get; set; }

        [JsonProperty("AmountPaid")]
        public decimal AmountPaid { get; set; }

        [JsonProperty("AmountCredited")]
        public decimal AmountCredited { get; set; }

        [JsonProperty("DateString")]
        public string DateString { get; set; }

        [JsonProperty("DueDateString")]
        public string DueDateString { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("SubTotal")]
        public decimal SubTotal { get; set; }

        [JsonProperty("TotalTax")]
        public decimal TotalTax { get; set; }

        [JsonProperty("Total")]
        public decimal Total { get; set; }

        public Contact Contact { get; set; }

        public decimal QuantityLoaded { get; set; }
        public DateTime BestBefore { get; set; }
        public DateTime Time { get; set; }
        public string Temperature { get; set; }
        public bool IsVehicleClean { get; set; }
        public string ReceivedBy { get; set; }
        public string Signature { get; set; }

    }
}
