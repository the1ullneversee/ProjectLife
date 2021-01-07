using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinAppToLearnFrom.Models
{
    //base class that defines an Activity. 
    public class Activity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate {get; set;}
        //is this an active activity
        public bool Active { get; set; }
        //how long does the activity last?
        public TimeSpan GoalTime { get; set; }
        //how long have you spent on the activity
        public TimeSpan ElapsedTime { get; set; }
    }
}
