using JsonInvoiceGenerator.Model;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace JsonInvoiceGenerator.JsonDataLoader
{
    public class JsonDataLoaderHelper
    {
        //private string filepath = "";
        
        public List<InvoiceDbDto> LoadJsonData()
        {
            List<InvoiceDbDto> jsonDataList = new List<InvoiceDbDto>();
            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = Path.Combine(projectDirectory, "..", "..", "..", "usage-data.json");
            string json = File.ReadAllText(relativePath);
            Console.WriteLine(json);
            try
            {
                
                //var temp = JsonSerializer.Deserialize<Rootobject>(JsonSerializer.Serialize(json));
                var jsonArray = JsonSerializer.Deserialize<JsonArray>(json);
                foreach (var item in jsonArray) 
                {
                    using (JsonDocument doc = JsonDocument.Parse(item.ToString()))
                    {
                        var root = doc.RootElement;

                        // Validate properties before deserialization
                        if (IsValidProperty(root, "API_Calls", typeof(int)) &&
                            IsValidProperty(root, "Storage_GB", typeof(double)) &&
                            IsValidProperty(root, "CustomerId", typeof(string)) &&
                            IsValidProperty(root, "Compute_Minutes", typeof(int)))
                        {
                            jsonDataList.Add(JsonSerializer.Deserialize<InvoiceDbDto>(JsonSerializer.Serialize(item)));
                        }                        
                    }
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
           
            return jsonDataList;
        }
        static bool IsValidProperty(JsonElement root, string propertyName, Type expectedType)
        {
            if (root.TryGetProperty(propertyName, out JsonElement property))
            {
                
                if (expectedType == typeof(int) && property.ValueKind == JsonValueKind.String)
                {
                    return int.TryParse(property.GetString(), out _);
                }
                else if (expectedType == typeof(double) && property.ValueKind == JsonValueKind.String)
                {
                    return double.TryParse(property.GetString(), out _);
                }
                else if (expectedType == typeof(string) && property.ValueKind == JsonValueKind.String)
                {
                    return true;
                }
                else
                {
                    return property.ValueKind == JsonValueKind.Number;
                }
            }

            return false;
        }


    }
}
