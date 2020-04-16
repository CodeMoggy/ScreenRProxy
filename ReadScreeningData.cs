using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;
using Screening.Poco;

namespace ScanScreenProxy.Function
{
    public static class ReadScreeningData
    {
        [FunctionName("ReadScreeningData")]
        public async static Task Run([QueueTrigger("screeningdata"), StorageAccount("AzureWebJobsStorage")]ScreeningItem myScanItem,
                                [Table("scanscreening"), StorageAccount("AzureWebJobsStorage")] CloudTable table, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myScanItem}");

            // create a new row in a table for the queue item
            // create table entry
            var item = new ScreeningData()
            {
                PartitionKey = myScanItem.ZipCode,
                RowKey = Guid.NewGuid().ToString(),
                ZipCode = myScanItem.ZipCode,
                SurveyDate = DateTime.Now,
                Age = myScanItem.Age,
                Symptomatic = myScanItem.Symptomatic,
                Puma = myScanItem.Puma
            };

            var operation = TableOperation.Insert(item);
            await table.ExecuteAsync(operation);
        }

    }
}
