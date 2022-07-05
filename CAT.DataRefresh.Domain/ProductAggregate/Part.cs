using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CAT.DataRefresh.Domain
{
    public class Part
    {
        public Part()
        {
            Products = new List<Product>();
        }

        public System.Guid Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Product> Products { get; set; }
    }
}