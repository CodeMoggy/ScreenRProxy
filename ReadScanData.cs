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
        public async static Task Run([QueueTrigger("scandata", Connection = "rcscanscreenerproxy_STORAGE")]ParticipantItem myScanItem,
                                [Table("redcap", Connection = "rcscanscreenerproxy_STORAGE")] CloudTable table, ILogger log)
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
                Age = int.Parse(myScanItem.Age)
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

        public class ParticipantItem
        {
            public string ZipCode { get; set; }            
            public string Age { get; set; }   
        }
    }
}
