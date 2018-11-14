using System;

namespace BabySitter.App
{
    public class BabySitterService
    {
        
        public int GetNumberOfHoursWorked(TimeSpan startTime, TimeSpan endTime)
        {
            return (endTime - startTime).Hours;
        }

    }
}