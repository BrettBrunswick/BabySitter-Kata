using System;

namespace BabySitter.App
{
    public class BabySitterService
    {
        private const int MINUTES_IN_HOUR = 60;
        
        public int GetNumberOfHoursWorked(TimeSpan startTime, TimeSpan endTime)
        {
            var timeWorked = endTime - startTime;
            if (timeWorked.TotalMinutes % MINUTES_IN_HOUR >= 0.5)
            {
                return timeWorked.Add(new TimeSpan(1, 00, 00)).Hours;
            } else
            {
                return timeWorked.Hours;
            }
        }

        

    }
}