using System;

namespace BabySitter.App
{
    public class BabySitterService
    {
        
        //Rounding up if worked more than a half hour.
        public int GetNumberOfHoursWorked(TimeSpan startTime, TimeSpan endTime)
        {
            var timeWorked = endTime.Subtract(startTime).TotalMilliseconds < 0 ? endTime.Subtract(startTime).Add(new TimeSpan(24, 00, 00)) : endTime.Subtract(startTime);
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