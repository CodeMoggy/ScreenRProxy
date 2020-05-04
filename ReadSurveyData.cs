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
                                [Table("surveydata"), StorageAccount("AzureWebJobsStorage")] CloudTable table, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {mySurveyItem}");

            // create a new row in a table for the queue item
            // create table entry
            var item = new SurveyData()
            {
                PartitionKey = mySurveyItem.zip,
                RowKey = mySurveyItem.id,
                id = mySurveyItem.id,
                filling_out_for = mySurveyItem.filling_out_for,
                zip = mySurveyItem.zip,
                puma = mySurveyItem.puma,
                age = mySurveyItem.age,
                sex = mySurveyItem.sex,
                symptoms_binary = mySurveyItem.symptoms_binary,
                symptoms_specific = mySurveyItem.symptoms_specific,
                symptoms_all = mySurveyItem.symptoms_all,
                housing = mySurveyItem.housing,
                shared_space = mySurveyItem.shared_space,
                covid_contact = mySurveyItem.covid_contact,
                work_from_home = mySurveyItem.work_from_home,
                industry = mySurveyItem.industry,
                industry_other = mySurveyItem.industry_other,
                behavior_change_sufaces = mySurveyItem.behavior_change_sufaces,
                behavior_change_cough = mySurveyItem.behavior_change_cough,
                behavior_change_distance = mySurveyItem.behavior_change_distance,
                behavior_change_hands = mySurveyItem.behavior_change_hands,
                behavior_change_mask = mySurveyItem.behavior_change_mask,
                screener = mySurveyItem.screener
            };

            var operation = TableOperation.Insert(item);
            await table.ExecuteAsync(operation);
        }

    }
}
