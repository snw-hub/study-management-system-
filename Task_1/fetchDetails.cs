using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary;

namespace Task_1
{
    class fetchDetails
    {
        //getters and setters for my variables
        public string module_code { get; set; }
        public string module_name { get; set; }
        public double number_of_credits { get; set; }
        public double class_hours_per_week { get; set; }
        public double number_of_weeks { get; set; }
        public double number_of_hours { get; set; }
        public DateTime start_date { get; set; }
        public double study_hours_calculations { get; set; }
        public double hours_remaining { get; set; }
    }
}