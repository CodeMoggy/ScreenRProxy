using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ScanScreenProxy.Function
{
    public static class ReadScanData
    {
        [FunctionName("ReadScanData")]
        public static void Run([QueueTrigger("myqueue-items", Connection = "rcscanscreenerproxy_STORAGE")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
