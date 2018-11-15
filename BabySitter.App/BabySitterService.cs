using System;
using System.Collections.Generic;
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

        private readonly List<Family> CLIENTS = new List<Family> 
            {
                new Family
                (
                    "A", 
                    new List<PayPeriod>
                    {
                        (new PayPeriod (15, new TimeSpan(17, 00, 00), new TimeSpan(23, 00, 00))),
                        (new PayPeriod (20, new TimeSpan(23, 00, 00), new TimeSpan(4, 00, 00)))
                    }
                ),
                new Family
                (
                    "B", 
                    new List<PayPeriod>
                    {
                        (new PayPeriod (12, new TimeSpan(17, 00, 00), new TimeSpan(22, 00, 00))),
                        (new PayPeriod (8, new TimeSpan(22, 00, 00), new TimeSpan(0, 00, 00))),
                        (new PayPeriod (16, new TimeSpan(0, 00, 00), new TimeSpan(4, 00, 00)))
                    }
                ),
                new Family
                (
                    "C", 
                    new List<PayPeriod>
                    {
                        (new PayPeriod (21, new TimeSpan(17, 00, 00), new TimeSpan(21, 00, 00))),
                        (new PayPeriod (15, new TimeSpan(21, 00, 00), new TimeSpan(4, 00, 00)))
                    }
                ),
            };

        
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



        #region Convert Input to TimeSpan

        public TimeSpan GetTimeSpanFromString(string inputTime)
        {
            if (TimeSpan.TryParseExact(inputTime, VALID_TIME_FORMATS, null, out OutTime))
            {
                return TimeSpan.Parse(inputTime);
            }
            else
            {
                return GetTimeSpanFromStringWithAMPMFormat(inputTime);
            }
        }

        private TimeSpan GetTimeSpanFromStringWithAMPMFormat(string inputTime)
        {
            var date = DateTime.Parse(inputTime);
            return date.TimeOfDay;
        }

        #endregion



        #region Data Retrieval

        public bool IsValidFamily(string familyId)
        {
            throw new NotImplementedException();
        }
        
        #endregion
    }
}