//****************************************************************************************************
//Defines the use cases the software is supposed to do and coordinates the domain objects to work out problems.
//This layer is kept thin. It does not contain business rules or knowledge, but only coordinates tasks and
//delegates work to collaborations of domain objects in the next layer down. It does not have state reflecting
//the business situation, but it can have state that reflects the progress of a task for the user or the program.
//
// the application layer should return dto back to the client, with only the fields that are needed for that  use case
//***************************************************************************************************

using System.Collections.Generic;
using SampleCompany.Infrastructure.Config;
using SampleCompany.Infrastructure.Logger;
using SampleCompany.Domain;
using Newtonsoft.Json;

namespace SampleCompany.Application
{
    public class ProductService
    {
        //private static readonly string Db = "SampleCompany_" + DateTime.Now.Millisecond.ToString();
        private IConfig _config;
        private ILogger _logger;
        private IProductRepository _repo;

        public ProductService(IConfig config, ILogger logger, IProductRepository repository)
        {
            //todo: check that these are not null
            _config = config;
            _logger = logger;
            _repo = repository;
        }

        public System.Guid AddNewProduct(ProductDto product)
        {
            var p = new Product
            {
                Id = System.Guid.NewGuid(),
                Name = "product name",
                Categories = new List<Category>()
                {
                    new Category()
                    {
                        Id = System.Guid.NewGuid(),
                        Name = "Category Name 1"
                    }, 
                    new Category()
                    {
                        Id = System.Guid.NewGuid(),
                        Name = "Category Name 2"
                    }, 
                },
                Parts = new List<Part>()
                {
                    new Part()
                    {
                        Id = System.Guid.NewGuid(),
                        Name = "Part Name 1"
                    },
                    new Part()
                    {
                        Id = System.Guid.NewGuid(),
                        Name = "Part Name 2"
                    }
                }
            };

            var logEntry = new LogEntry(
                LoggingEventType.Debug, 
                JsonConvert.SerializeObject(p), 
                null
                );

            _logger.Log(logEntry);
            var id = _repo.AddNewProduct(p);
            return id;
        }

        public bool ChangeProductPrice(double price)
        {
            return true;
        }

        public bool DeleteProduct(System.Guid id)
        {
            return true;
        }

        public Product GetProductById(System.Guid id)
        {
            return new Product();
        }
    }
}