using System;

namespace BabySitter.App
{
    public class BabySitterService
    {
        
        //Rounding up if worked more than a half hour.
        public int GetNumberOfHoursWorked(TimeSpan startTime, TimeSpan endTime)
        {
            var timeDifference = endTime.Subtract(startTime);
            var timeWorked = timeDifference.TotalMilliseconds < 0 ? timeDifference.Add(new TimeSpan(24, 00, 00)) : timeDifference;
            if (timeWorked.TotalHours % 1 >= 0.5)
            {
                return timeWorked.Add(new TimeSpan(1, 00, 00)).Hours;
            } else
            {
                return timeWorked.Hours;
            }
        }

        public bool IsInputTimeFormatValid(string inputTime)
        {
            TimeSpan placeHolder = new TimeSpan();
            return TimeSpan.TryParse(inputTime, out placeHolder);
        }

    }
}