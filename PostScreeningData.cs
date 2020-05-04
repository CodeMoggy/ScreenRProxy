using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Screening.Poco;

namespace ScanScreenProxy.Function
{
    public static class PostScreeningData
    {
        [FunctionName("PostScreeningData")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, 
            [Queue("screeningdata"),StorageAccount("AzureWebJobsStorage")] ICollector<ScreeningItem> msg, 
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var item = JsonConvert.DeserializeObject<ScreeningItem>(requestBody);
            item.id = Guid.NewGuid().ToString();

            // Add a message to the output collection.
            msg.Add(item);

            return (ActionResult)new OkObjectResult(item.id);                ;
        }
    }
}
