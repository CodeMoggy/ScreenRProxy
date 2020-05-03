using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Survey.Poco;

namespace ScanScreenProxy.Function
{
    public static class PostSurveyData
    {
        [FunctionName("PostSurveyData")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, 
            [Queue("phase1surveydata"),StorageAccount("AzureWebJobsStorage")] ICollector<SurveyItem> msg, 
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var item = JsonConvert.DeserializeObject<SurveyItem>(requestBody);

            // Add a message to the output collection.
            msg.Add(item);

            var referenceNumber = Guid.NewGuid().ToString();

            return (ActionResult)new OkObjectResult(referenceNumber);                ;
        }
    }
}
