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
        public async static Task Run([QueueTrigger("surveydata"), StorageAccount("AzureWebJobsStorage")]SurveyItem mySurveyItem,
                                [Table("redcapsurvey"), StorageAccount("AzureWebJobsStorage")] CloudTable table, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {mySurveyItem}");

            // create a new row in a table for the queue item
            // create table entry
            var item = new SurveyData()
            {
                PartitionKey = mySurveyItem.ZipCode,
                RowKey = Guid.NewGuid().ToString(),
                SurveyDate = DateTime.Now,
                SickInTheLastWeek = mySurveyItem.SickInTheLastWeek,
                SexAtBirth = mySurveyItem.SexAtBirth,
                DetailedSymptoms = mySurveyItem.DetailedSymptoms,
                IsHispanicOrLatina = mySurveyItem.IsHispanicOrLatina,
                Race = mySurveyItem.Race,
                Income = mySurveyItem.Income,
                WhereDoYouLive = mySurveyItem.WhereDoYouLive,
                LivingSpace = mySurveyItem.LivingSpace,
                ClinicalCare = mySurveyItem.ClinicalCare,
                TobaccoProducts = mySurveyItem.TobaccoProducts,
                MedicalConditions = mySurveyItem.MedicalConditions,
                LongerTermDiseases = mySurveyItem.LongerTermDiseases,
                AceInhibitors = mySurveyItem.AceInhibitors,
                PlacesOfVocation = mySurveyItem.PlacesOfVocation,
                OutsideUs = mySurveyItem.OutsideUsIn14Days,
                OutsideState = mySurveyItem.OutsideStateIn14Days,
                ZipCode = mySurveyItem.ZipCode,
                Symptomatic = mySurveyItem.Symptomatic,
                Puma = mySurveyItem.Puma,
                Age = mySurveyItem.Age  
            };

            var operation = TableOperation.Insert(item);
            await table.ExecuteAsync(operation);
        }

    }
}
