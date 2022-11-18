//
// Responsible for representing concepts of the business, information about the business situation, and business
// rules. State that reflects the business situation is controlled and used here, even though the technical details
// of changing it are delegated to the infrastructure. This layer is the heart of business software.  This example
// is an aggregate root, which means that everything that is affected by this entity must be updated within this
// root.
//



using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SampleCompany.Domain
{
    public class Product
    {
        public Product()
        {
            Categories = new List<Category>();
            Parts = new List<Part>();
        }

        public System.Guid Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Category> Categories { get; set; }
        [JsonIgnore]
        public List<Part> Parts { get; set; }
    }
}