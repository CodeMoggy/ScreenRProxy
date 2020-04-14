using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;

namespace ScanScreenProxy.Function
{
    public static class ReadScanData
    {
        [FunctionName("ReadScanData")]
        public async static Task Run([QueueTrigger("scandata", Connection = "rcscanscreenerproxy_STORAGE")]string myScanItem,
                                [Table("redcap", Connection = "rcscanscreenerproxy_STORAGE")] CloudTable table, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myScanItem}");

            // create a new row in a table for the queue item
            // create table entry
            var item = new Participant()
            {
                PartitionKey = "45",
                RowKey = "98107",
                ZipCode = "98107",
                SurveyDate = DateTime.Now,
                Age = 45
            };

            var operation = TableOperation.Insert(item);
            await table.ExecuteAsync(operation);
        }

        public class Participant : TableEntity
        {
            public string ZipCode { get; set; }
            public DateTime SurveyDate {get; set;}
            public int Age { get; set; }   
        }
    }
}
