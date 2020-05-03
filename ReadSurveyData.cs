using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;
using Survey.Poco;

namespace ScanScreenProxy.Function
{
    public static class ReadSurveyData
    {
        [FunctionName("ReadSurveyData")]
        public async static Task Run([QueueTrigger("phase1surveydata"), StorageAccount("AzureWebJobsStorage")]SurveyItem mySurveyItem,
                                [Table("phase1survey"), StorageAccount("AzureWebJobsStorage")] CloudTable table, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {mySurveyItem}");

            // create a new row in a table for the queue item
            // create table entry
            var item = new SurveyData()
            {
                PartitionKey = mySurveyItem.ZipCode,
                RowKey = Guid.NewGuid().ToString(),
                SurveyDate = DateTime.Now,
                MyselfOrSomeoneElse = mySurveyItem.MyselfOrSomeoneElse,
                ZipCode = mySurveyItem.ZipCode,
                Puma = mySurveyItem.Puma,
                Age = mySurveyItem.Age,
                Sex = mySurveyItem.Sex,
                BinarySymptoms = mySurveyItem.BinarySymptoms,
                SpecificSymptoms = mySurveyItem.SpecificSymptoms,
                AllSymptoms = mySurveyItem.AllSymptoms,
                Housing = mySurveyItem.Housing,
                SharedSpace = mySurveyItem.SharedSpace,
                ContactWith = mySurveyItem.ContactWith,
                WorkFromHome = mySurveyItem.WorkFromHome,
                Industry = mySurveyItem.Industry,
                IndustryOther = mySurveyItem.IndustryOther,
                BehaviorCleanItems = mySurveyItem.BehaviorCleanItems,
                BehaviorCoughInElbow = mySurveyItem.BehaviorCoughInElbow,
                BehaviorStaySixFeetAway = mySurveyItem.BehaviorStaySixFeetAway,
                BehaviorWashHands = mySurveyItem.BehaviorWashHands,
                BehaviorWearFaceMask = mySurveyItem.BehaviorWearFaceMask
            };

            var operation = TableOperation.Insert(item);
            await table.ExecuteAsync(operation);
        }

    }
}
