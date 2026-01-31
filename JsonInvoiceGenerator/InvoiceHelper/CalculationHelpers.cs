using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonInvoiceGenerator.Model;

namespace JsonInvoiceGenerator.InvoiceHelper
{
    public class CalculationHelpers
    {
        /*
         Pricing Rules
- API Calls
 - First 10,000 calls -> $0.01 each
 - Above 10,000 calls -> $0.008 each
- Storage -> $0.25 per GB
- Compute Time -> $0.05 per minute
         */
        public InvoiceViewModel DoCalculations(InvoiceDbDto data)
        {
            double apicost = 0;
            if(data.API_Calls < 10000)
            {
                apicost = data.API_Calls * 0.01;
            }
            else
            {
                apicost = 10000 * 0.01;

                apicost += (data.API_Calls-10000) * 0.01;
            }
            double sotrage = data.Storage_GB * 0.25;

            double computein = data.Compute_Minutes * 0.05;

            InvoiceViewModel model = new InvoiceViewModel() { API_Calls=apicost, Compute_Minutes=computein,
            Storage_GB=sotrage,CustomerId=data.CustomerId
            };
            return model;
        }
    }
}
