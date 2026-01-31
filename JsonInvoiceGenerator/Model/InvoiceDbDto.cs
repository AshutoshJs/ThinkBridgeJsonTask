using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonInvoiceGenerator.Model
{
    public class InvoiceDbDto
    {
        public string CustomerId { get; set; }
        public int API_Calls { get; set; }
        public int Storage_GB { get; set; }
        public int Compute_Minutes { get; set; }
    }
    //

    public class FileJsonobject
    {
        public InvoiceDbDto[] Property1 { get; set; }
    }

    


    //
}
