using System;
using System.Globalization;

namespace BabySitter.App
{
    public class BabySitterService
    {

        private TimeSpan OutTime;
        
        private DateTime OutDate;

        private readonly TimeSpan ONE_DAY = new TimeSpan(24, 00, 00);

        private readonly TimeSpan ONE_HOUR = new TimeSpan(1, 00, 00);

        private readonly TimeSpan EARLIEST_START_TIME = new TimeSpan(17, 00, 00);

        private readonly TimeSpan LATEST_END_TIME = new TimeSpan(4, 00, 00);

        private readonly string[] VALID_TIME_FORMATS = { "hh\\:mm", "h\\:mm",  "hh\\:mm tt", "h\\:mm tt", "hh\\:mmtt", "h\\:mmtt" };
        
        
        //Rounding up if worked more than a half hour.
        public int GetNumberOfHoursWorked(TimeSpan startTime, TimeSpan endTime)
        {
            var timeDifference = endTime.Subtract(startTime);
            var timeWorked = timeDifference.TotalMilliseconds < 0 ? timeDifference.Add(ONE_DAY) : timeDifference;
            if (timeWorked.TotalHours % 1 >= 0.5)
            {
                return timeWorked.Add(ONE_HOUR).Hours;
            } else
            {
                return timeWorked.Hours;
            }
        }

        #region Validate Input

        public bool IsInputTimeFormatValid(string inputTime)
        {
            return (TimeSpan.TryParseExact(inputTime, VALID_TIME_FORMATS, null, out OutTime) ||
                (DateTime.TryParseExact(inputTime, VALID_TIME_FORMATS, CultureInfo.CurrentCulture, DateTimeStyles.None, out OutDate)));
        }

        public bool IsStartTimeValid(TimeSpan startTime)
        {
            return (startTime >= EARLIEST_START_TIME) || (startTime < LATEST_END_TIME);
        }

        public bool IsEndTimeValid(TimeSpan endTime)
        {
            return (endTime <= LATEST_END_TIME) || (endTime > EARLIEST_START_TIME);
        }

        public bool IsEndTimeAfterStartTime (TimeSpan startTime, TimeSpan endTime)
        {
            if (startTime < EARLIEST_START_TIME)
            {
                return endTime > startTime;
            } else 
            {
                return IsStartTimeValid(startTime) && IsEndTimeValid(endTime);
            }
        }

        #endregion
    }
}