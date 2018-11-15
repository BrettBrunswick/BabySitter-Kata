using System;
using System.Collections.Generic;

namespace BabySitter.App
{
    class Program
    {

        private const string INTRODUCTION = "Hi, welcome back.\nI hope work went well tonight.";

        static void Main(string[] args)
        {
            BabySitterService service = new BabySitterService();
            Console.WriteLine(INTRODUCTION);

            string familyIdInput = "";
            string startTimeInput = "";
            string endTimeInput = "";
            TimeSpan startTime = new TimeSpan();
            TimeSpan endTime = new TimeSpan();

            do 
            {
                Console.Write("What family did you work for tonight? (A, B, or C): ");
                familyIdInput = Console.ReadLine();
                
            } while (!service.IsValidFamily(familyIdInput));

            do 
            {
                Console.WriteLine("When did you start work? (No earlier than 5:00 PM) (Accepted formats: '17:00', '05:00PM', '10:00 AM'): ");
                startTimeInput = Console.ReadLine();
                startTime = service.GetTimeSpanFromString(startTimeInput);
                
            } while (!service.IsInputTimeFormatValid(startTimeInput) || !service.IsStartTimeValid(startTime));

            do 
            {
                Console.WriteLine("When did you leave work? (No later than 4:00 AM) (Accepted formats: '17:00', '05:00PM', '10:00 AM'): ");
                endTimeInput = Console.ReadLine();
                endTime = service.GetTimeSpanFromString(endTimeInput);
                
            } while (!service.IsInputTimeFormatValid(endTimeInput) || !service.IsEndTimeValid(endTime) || !service.IsEndTimeAfterStartTime(startTime, endTime));
        }
    }
}
