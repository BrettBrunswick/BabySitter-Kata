using System;

namespace BabySitter.App
{
    public class BabySitterService
    {
        
        public int GetNumberOfHoursWorked(TimeSpan startTime, TimeSpan endTime)
        {
            var timeWorked = endTime - startTime;
            if (timeWorked.TotalHours % 1 >= 0.5)
            {
                return timeWorked.Add(new TimeSpan(1, 00, 00)).Hours;
            } else
            {
                return timeWorked.Hours;
            }
        }

        

    }
}