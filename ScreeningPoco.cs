 
using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace Screening.Poco
{
    public class ScreeningItem
    {
        public string ZipCode { get; set; }
        public int Age { get; set; }
        public int Symptomatic { get; set; }
        public string Puma { get; set; }   
    }
    
    public class ScreeningData : TableEntity
    {
        public string ZipCode { get; set; }
        public int Age { get; set; }
        public int Symptomatic { get; set; }
        public string Puma { get; set; }
        public DateTime SurveyDate { get; set; }
    }
}