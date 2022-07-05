//
// This is the top most layer, essentially for example a rest service wrapper. It is meant to wire up all of
// the dependencies for the application layer. Handler is executed by AWS Lambda in the main function for example,
// although it could also be an exe or any other logic that then uses the application layer. 
//
// it will get the data from the app layer in teh form of a dto or just the id.  it will then build the response needed by the api
//

using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using CAT.DataRefresh.Application;
using CAT.DataRefresh.Infrastructure.Config;
using CAT.DataRefresh.Infrastructure.Logger;
using CAT.DataRefresh.Infrastructure.Repository;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]
namespace CAT.DataRefresh.Client
{
    public class Handler
    {   public async Task<APIGatewayProxyResponse> LambdaHandler(APIGatewayProxyRequest request, ILambdaContext context)
        {
            //todo: gather this information from the product dto passed into the handler.
            var product = new ProductDto();
            product.Name = "name here";
            product.Categories = null;
            product.Parts = null;
            var category = new CategoryDto();
            var part = new PartDto();
            
            //todo: this needs to be pulled from some other secure storage and not hard  coded.
            //for example, use the parameter store repo.
            var c = new Config();
            var host = "localhost";
            var userName = "postgres";
            var password = "postgres";
            var database = "CAT_Test_DB_2";
                //System.Guid.NewGuid().ToString().Replace("-", string.Empty).Replace("+", string.Empty).Substring(0, 4);
            
            var r = new ProductRepository(host,userName, password, database);
            var l = new ConsoleLogger(LoggingEventType.Debug);
            var productService = new ProductService(c, l, r);
            var id = productService.AddNewProduct(product);

            var req = JsonConvert.DeserializeObject<Dictionary<string, string>>(request.Body);

            var body = new Dictionary<string, string>
            {
                //dto data would go here
                {"message", req["message"]},
                {"location", req["location"]}
            };

            var handler = new APIGatewayProxyResponse
            {
                Body = JsonConvert.SerializeObject(body),
                StatusCode = 200,
                Headers = new Dictionary<string, string> {{"Content-Type", "application/json"}}
            };
            return handler;
        }
    }
}