 
using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace Survey.Poco
{
    public class SurveyItem
    {
        public string id { get; set; }
        public string filling_out_for { get; set; }
        public string zip { get; set; }
        public string puma { get; set; }
        public int age { get; set; }
        public string sex { get; set; }
        public string symptoms_binary { get; set; }
        public string symptoms_specific { get; set; }
        public string symptoms_all { get; set; }
        public string housing { get; set; }
        public int shared_space { get; set; }
        public string covid_contact { get; set; }
        public string work_from_home { get; set; }
        public string industry { get; set; }
        public string industry_other { get; set; }
        public string behavior_change_hands { get; set; }
        public string behavior_change_sufaces { get; set; }
        public string behavior_change_cough { get; set; }
        public string behavior_change_mask { get; set; }
        public string behavior_change_distance { get; set; }
        public string screener { get; set; }
    }
    
    public class SurveyData : TableEntity
    {
        public string id { get; set; }
        public string filling_out_for { get; set; }
        public string zip { get; set; }
        public string puma { get; set; }
        public int age { get; set; }
        public string sex { get; set; }
        public string symptoms_binary { get; set; }
        public string symptoms_specific { get; set; }
        public string symptoms_all { get; set; }
        public string housing { get; set; }
        public int shared_space { get; set; }
        public string covid_contact { get; set; }
        public string work_from_home { get; set; }
        public string industry { get; set; }
        public string industry_other { get; set; }
        public string behavior_change_hands { get; set; }
        public string behavior_change_sufaces { get; set; }
        public string behavior_change_cough { get; set; }
        public string behavior_change_mask { get; set; }
        public string behavior_change_distance { get; set; }
        public string screener { get; set; }
    }
}