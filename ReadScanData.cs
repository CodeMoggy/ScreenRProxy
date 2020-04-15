using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;
using ScanScreenProxy.Poco;

namespace ScanScreenProxy.Function
{
    public static class ReadScanData
    {
        [FunctionName("ReadScanData")]
        public async static Task Run([QueueTrigger("scandata"), StorageAccount("AzureWebJobsStorage")]ParticipantItem myScanItem,
                                [Table("redcap"), StorageAccount("AzureWebJobsStorage")] CloudTable table, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myScanItem}");

            // create a new row in a table for the queue item
            // create table entry
            var item = new Participant()
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
