 
using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace Survey.Poco
{
    public class SurveyItem
    {
        public string MyselfOrSomeoneElse { get; set; }
        public string ZipCode { get; set; }
        public string Puma { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string BinarySymptoms { get; set; }
        public string SpecificSymptoms { get; set; }
        public string AllSymptoms { get; set; }
        public string Housing { get; set; }
        public int SharedSpace { get; set; }
        public string ContactWith { get; set; }
        public string WorkFromHome { get; set; }
        public string Industry { get; set; }
        public string IndustryOther { get; set; }
        public string BehaviorWashHands { get; set; }
        public string BehaviorCleanItems { get; set; }
        public string BehaviorCoughInElbow { get; set; }
        public string BehaviorWearFaceMask { get; set; }
        public string BehaviorStaySixFeetAway { get; set; }
    }
    
    public class SurveyData : TableEntity
    {
         public string MyselfOrSomeoneElse { get; set; }
        public string ZipCode { get; set; }
        public string Puma { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string BinarySymptoms { get; set; }
        public string SpecificSymptoms { get; set; }
        public string AllSymptoms { get; set; }
        public string Housing { get; set; }
        public int SharedSpace { get; set; }
        public string ContactWith { get; set; }
        public string WorkFromHome { get; set; }
        public string Industry { get; set; }
        public string IndustryOther { get; set; }
        public string BehaviorWashHands { get; set; }
        public string BehaviorCleanItems { get; set; }
        public string BehaviorCoughInElbow { get; set; }
        public string BehaviorWearFaceMask { get; set; }
        public string BehaviorStaySixFeetAway { get; set; }
        public DateTime SurveyDate { get; set; }
    }
}