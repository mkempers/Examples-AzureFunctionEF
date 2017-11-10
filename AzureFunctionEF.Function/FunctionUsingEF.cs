using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using AzureFunctionEF.Data;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AzureFunctionEF.Function
{
    public static class FunctionUsingEF
    {
        [FunctionName("FunctionUsingEF")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            var customersArray = new List<string>();
            var connectionString = ConfigurationManager.ConnectionStrings["AdventureWorksEntities"].ConnectionString;

            using (var dbContext = new AdventureWorksEntities(connectionString))
            {
                var customers = dbContext.Customers.ToList();

                foreach(var customer in customers)
                {
                    customersArray.Add(customer.CompanyName);
                }
            }

            return customersArray.Count == 0
                ? req.CreateResponse(HttpStatusCode.BadRequest, "Something went wrong!")
                : req.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(customersArray));
        }
    }
}
