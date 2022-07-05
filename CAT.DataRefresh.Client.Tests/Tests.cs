//
// This is where you would create your unit tests, right now this is just an example.  Normally you would
// create dto objects, pass them in and look for dto to be returned and validate it.
//

using System;
using System.Collections.Generic;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.TestUtilities;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace CAT.DataRefresh.Client.Tests
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestHandler(){
            var request = new APIGatewayProxyRequest();
            var context = new TestLambdaContext();
            string location = GetCallingIp().Result;
            Dictionary<string, string> body = new Dictionary<string, string>
            {
                { "message", "Lambda Test" },
                { "location", location },
            };

            request.Body = JsonConvert.SerializeObject(body);
            
            var expectedResponse = new APIGatewayProxyResponse
            {
                Body = request.Body,
                StatusCode = 200,
                Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
            };

            var function = new Handler();
            var response = await function.LambdaHandler(request, context);
            
            Assert.AreEqual(expectedResponse.Body, response.Body);
        }
        
        private static readonly HttpClient Client = new HttpClient();
        private static async Task<string> GetCallingIp()
        {
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Add("User-Agent", "AWS Lambda .Net Client");

            var stringTask = Client.GetStringAsync("http://checkip.amazonaws.com/").ConfigureAwait(continueOnCapturedContext:false);

            var msg = await stringTask;
            return msg.Replace("\n","");
        }
    }
}