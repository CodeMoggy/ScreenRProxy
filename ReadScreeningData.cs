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
        public async static Task Run([QueueTrigger("phase2screeningdata"), StorageAccount("AzureWebJobsStorage")]ScreeningItem myScanItem,
                                [Table("phase2screening"), StorageAccount("AzureWebJobsStorage")] CloudTable table, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myScanItem}");

            // create a new row in a table for the queue item
            // create table entry
            var item = new ScreeningData()
            {
                PartitionKey = myScanItem.zip,
                RowKey = myScanItem.id,
                puma = myScanItem.puma,
                zip = myScanItem.zip,            
                age = myScanItem.age,
                symptoms_binary = myScanItem.symptoms_binary,
                symptoms_specific = myScanItem.symptoms_specific
            };

            var operation = TableOperation.Insert(item);
            await table.ExecuteAsync(operation);
        }

    }
}
