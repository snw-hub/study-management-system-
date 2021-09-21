using System;

namespace MyLibrary
{
    public class studyCalculations
    {
        public double selectedNumberOfCredits;
        public double selectedClassHoursPerWeek;
        public double selectedNumberOfWeeks;

        public studyCalculations(double Credits, double ClassHours, double Weeks)
        {
            selectedNumberOfCredits = Credits;
            selectedClassHoursPerWeek = ClassHours;
            selectedNumberOfWeeks = Weeks;
        }


        //myt method caculates the study hours
        public double study_hours_calculations()
        {
            double results;
            //Duration 
            results = ((selectedNumberOfCredits * 10) / selectedNumberOfWeeks) - selectedClassHoursPerWeek;

            return Math.Round(results, 2);
        }
    }
}