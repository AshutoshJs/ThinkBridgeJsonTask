using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonInvoiceGenerator.Model
{
    public class InvoiceViewModel
    {
        public string? CustomerId { get; set; }
        public double? API_Calls { get; set; }
        public double? Storage_GB { get; set; }
        public double? Compute_Minutes { get; set; }

        public double? TotalDue { get; set; }
    }
}
