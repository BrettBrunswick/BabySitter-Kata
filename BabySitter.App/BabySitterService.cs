using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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

        private static List<Family> FAMILIES = new List<Family> 
            {
                new Family
                (
                    "A", 
                    new List<PayPeriod>
                    {
                        (new PayPeriod (15, new TimeSpan(17, 00, 00), new TimeSpan(23, 00, 00))),
                        (new PayPeriod (20, new TimeSpan(23, 00, 00), new TimeSpan(28, 00, 00)))
                    }
                ),
                new Family
                (
                    "B", 
                    new List<PayPeriod>
                    {
                        (new PayPeriod (12, new TimeSpan(17, 00, 00), new TimeSpan(22, 00, 00))),
                        (new PayPeriod (8, new TimeSpan(22, 00, 00), new TimeSpan(24, 00, 00))),
                        (new PayPeriod (16, new TimeSpan(24, 00, 00), new TimeSpan(28, 00, 00)))
                    }
                ),
                new Family
                (
                    "C", 
                    new List<PayPeriod>
                    {
                        (new PayPeriod (21, new TimeSpan(17, 00, 00), new TimeSpan(21, 00, 00))),
                        (new PayPeriod (15, new TimeSpan(21, 00, 00), new TimeSpan(28, 00, 00)))
                    }
                ),
            };


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
                return AddDayToTimeSpanIfInMorning(TimeSpan.Parse(inputTime));
            }
            else
            {
                return AddDayToTimeSpanIfInMorning(GetTimeSpanFromStringWithAMPMFormat(inputTime));
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
            return FAMILIES.Any(id => id.Id.Equals(familyId.ToUpper()));
        }


        //Calculate Earnings
        public double GetTotalEarnings(bool roundUpHours, string familyId, TimeSpan startTime, TimeSpan endTime)
        {
            double result = 0;
            var payPeriodsBabySitterWorkedIn = GetPayPeriodsBabySitterWorkedIn(familyId, startTime, endTime);
            
            foreach (var period in payPeriodsBabySitterWorkedIn)
            {
                result += GetEarningsByPayPeriod(roundUpHours, period, startTime, endTime);
            }
            return result;
        }

        public int GetNumberOfHoursWorked(bool roundUp, TimeSpan startTime, TimeSpan endTime)
        {
            var timeDifference = endTime.Subtract(startTime);
            if (roundUp && timeDifference.TotalHours % 1 >= 0.5)
            {
                return timeDifference.Add(ONE_HOUR).Hours;
            } else
            {
                return timeDifference.Hours;
            }
        }

        private List<PayPeriod> GetPayPeriodsBabySitterWorkedIn(string familyId, TimeSpan startTime, TimeSpan endTime)
        {
            return FAMILIES.First(x => x.Id.Equals(familyId.ToUpper())).PayPeriods.Where(t => startTime <= t.EndTime && endTime >= t.StartTime).ToList();
        }

        private double GetEarningsByPayPeriod(bool roundUpHours, PayPeriod payPeriod, TimeSpan startTime, TimeSpan endTime)
        {
            var startTimeToUse = new TimeSpan();
            var endTimeToUse = new TimeSpan();

            if ((startTime) > (payPeriod.StartTime))
            {
                startTimeToUse = startTime;
            } else 
            {
                startTimeToUse = payPeriod.StartTime;
            }

            if ((endTime) > (payPeriod.EndTime))
            {
                endTimeToUse = payPeriod.EndTime;
            } else 
            {
                endTimeToUse = endTime;
            }

            return GetNumberOfHoursWorked(roundUpHours, startTimeToUse, endTimeToUse) * payPeriod.PricePerHour;
        }

        private TimeSpan AddDayToTimeSpanIfInMorning (TimeSpan time)
        {
            return time <= LATEST_END_TIME ? time.Add(ONE_DAY) : time; 
        }

        #endregion

    }
}