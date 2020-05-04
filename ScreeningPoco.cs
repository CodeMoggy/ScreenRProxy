 
using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace Screening.Poco
{
    public class ScreeningItem
    {
        public string id { get; set; }
        public string filling_out_for { get; set; }
        public string zip { get; set; }
        public string puma { get; set; }
        public int age { get; set; }
        public string sex { get; set; }
        public string symptoms_binary { get; set; }
        public string symptoms_specific { get; set; }   
    }
    
    public class ScreeningData : TableEntity
    {
        public string id { get; set; }
        public string filling_out_for { get; set; }
        public string zip { get; set; }
        public string puma { get; set; }
        public int age { get; set; }
        public string sex { get; set; }
        public string symptoms_binary { get; set; }
        public string symptoms_specific { get; set; }
    }
}