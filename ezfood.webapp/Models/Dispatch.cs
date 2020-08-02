using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ezfood.webapp.Models
{
    public class Dispatch
    {
        [Key]
        public int Id { get; set; }
        public string DispatchDate { get; set; }
        public string CustomerName { get; set; }
        public string OrderNumber { get; set; }
    }
}
