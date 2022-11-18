//---------------------------------------------------------------------------------//
// the purpose of this is to provide abstraction of the domain objects to and from 
// the consumer.  Data will be passed in as a dto and returned as a dto, allowing
// only the data that is necessary and nothing else to be exposed, not the entire
// entities
//---------------------------------------------------------------------------------//



using System.Collections.Generic;

namespace SampleCompany.Application
{
    public class CategoryDto
    {   
        public System.Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class PartDto
    {   
        public System.Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductDto
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public List<PartDto> Parts { get; set; }
        
    }
}