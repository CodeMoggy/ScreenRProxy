 
using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace Screening.Poco
{
    public class ScreeningItem
    {
        public string Puma { get; set; }
        public string ZipCode { get; set; }
        public int Age { get; set; }
        public string BinarySymptoms { get; set; }
        public string SpecificSymptoms { get; set; }
        public string Session { get; set; }   
    }
    
    public class ScreeningData : TableEntity
    {
        public string Puma { get; set; }
        public string ZipCode { get; set; }
        public int Age { get; set; }
        public string BinarySymptoms { get; set; }
        public string SpecificSymptoms { get; set; }
        public string Session { get; set; }
        public DateTime ScreeningDate { get; set; }
    }
}