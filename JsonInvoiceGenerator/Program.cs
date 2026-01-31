using JsonInvoiceGenerator.InvoiceHelper;
using JsonInvoiceGenerator.JsonDataLoader;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JsonInvoiceGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var data = new JsonDataLoaderHelper().LoadJsonData();
            for(int i = 0; i < data.Count; i++)
            {
                var invoice = new CalculationHelpers().DoCalculations(data[i]);
                invoice.TotalDue = invoice.Compute_Minutes + invoice.API_Calls + invoice.Storage_GB;
                Console.WriteLine($"Invoice for Customer: {invoice.CustomerId}");
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"API Calls: {data[i].API_Calls} calls -> ${invoice.API_Calls:F2}");
                Console.WriteLine($"Storage: {data[i].Storage_GB} GB -> ${invoice.Storage_GB:F2}");
                Console.WriteLine($"Compute Time: {invoice.Compute_Minutes} minutes -> ${invoice.Compute_Minutes:F2}");
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"Total Due: ${invoice.TotalDue:F2}");
                Console.WriteLine();
            }
        }
    }
}
