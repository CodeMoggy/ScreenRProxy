 
using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace Survey.Poco
{
    public class SurveyItem
    {
        public string SickInTheLastWeek { get; set; }
        public string DetailedSymptoms { get; set; }
        public string SexAtBirth { get; set; }
        public string IsHispanicOrLatina { get; set; }
        public string Race { get; set; }
        public string Income { get; set; }
        public string WhereDoYouLive { get; set; }
        public string LivingSpace { get; set; }
        public string ClinicalCare { get; set; }
        public string TobaccoProducts { get; set; }
        public string MedicalConditions { get; set; }
        public string LongerTermDiseases { get; set; }
        public string AceInhibitors { get; set; }
        public string PlacesOfVocation { get; set; }
        public string OutsideUsIn14Days { get; set; }
        public string OutsideStateIn14Days { get; set; }
        public string ZipCode { get; set; }
        public int Age { get; set; }
        public int Symptomatic { get; set; }
        public string Puma { get; set; }
    }
    
    public class SurveyData : TableEntity
    {
        
        public string SickInTheLastWeek { get; set; }
        public string DetailedSymptoms { get; set; }
        public string SexAtBirth { get; set; }
        public string IsHispanicOrLatina { get; set; }
        public string Race { get; set; }
        public string Income { get; set; }
        public string WhereDoYouLive { get; set; }
        public string LivingSpace { get; set; }
        public string ClinicalCare { get; set; }
        public string TobaccoProducts { get; set; }
        public string MedicalConditions { get; set; }
        public string LongerTermDiseases { get; set; }
        public string AceInhibitors { get; set; }
        public string PlacesOfVocation { get; set; }
        public string OutsideUs { get; set; }
        public string OutsideState { get; set; }
        public string ZipCode { get; set; }
        public int Age { get; set; }
        public int Symptomatic { get; set; }
        public string Puma { get; set; }
        public DateTime SurveyDate { get; set; }
    }
}