using System;
using System.Collections.Generic;

namespace BabySitter.App 
{
    public class PayPeriod
    {

        public PayPeriod(double pricePerHour, TimeSpan startTime, TimeSpan endTime)
        {
            this.PricePerHour = pricePerHour;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        public double PricePerHour { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
    }
}