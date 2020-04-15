 
using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace ScanScreenProxy.Poco
{
    public class ParticipantItem
    {
        public string ZipCode { get; set; }
        public int Age { get; set; }
        public int Symptomatic { get; set; }
        public string Puma { get; set; }   
    }
    
    public class Participant : TableEntity
    {
        public string ZipCode { get; set; }
        public int Age { get; set; }
        public int Symptomatic { get; set; }
        public string Puma { get; set; }
        public DateTime SurveyDate { get; set; }
    }
}