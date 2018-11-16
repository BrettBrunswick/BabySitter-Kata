using System;
using System.Collections.Generic;

namespace BabySitter.App
{
    class Program
    {

        private const string INTRODUCTION = "Hi, welcome back.\nI hope work went well tonight.";

        private const string VALID_TIME_FORMATS = "17:00, 5:00PM, 5:00 PM";

        static void Main(string[] args)
        {
            BabySitterService _service = new BabySitterService();

            bool isRunning = true;
            while (isRunning)
            {
                string familyIdInput = "";
                string roundUpHoursInput ="";
                string startTimeInput = "";
                string endTimeInput = "";
                TimeSpan startTime = new TimeSpan();
                TimeSpan endTime = new TimeSpan();

                Console.WriteLine(INTRODUCTION);

                bool isFamilyInputValid = false;
                while (!isFamilyInputValid)
                {
                    Console.Write("Which family did you work for tonight?: ");
                    familyIdInput = Console.ReadLine();

                    if (_service.IsValidFamily(familyIdInput))
                    {
                        isFamilyInputValid = true;
                    } else 
                    {
                        Console.WriteLine("Oops. It appears " + familyIdInput + " is not one of your active clients.");
                    }
                }

                bool roundUpHours = false;
                Console.WriteLine("Should we round up hours worked? (Enter Y for Yes. Enter anything else for No.): ");
                roundUpHoursInput = Console.ReadLine();
                if (roundUpHoursInput.ToUpper().Equals("Y")) roundUpHours = true;

                bool isStartTimeInputValid = false;
                while (!isStartTimeInputValid)
                {
                    Console.WriteLine("What time did you go into work tonight? (If entering a PM time, please specify PM or use military time.): ");
                    startTimeInput = Console.ReadLine();

                    if (_service.IsInputTimeFormatValid(startTimeInput))
                    {
                        startTime = _service.GetTimeSpanFromString(startTimeInput);
                    } else
                    {
                        Console.WriteLine("Oops. It appears " + startTimeInput + " is not in the correct format.\nPlease enter time in one of the following formats: " + VALID_TIME_FORMATS);
                    }

                    if (_service.IsStartTimeValid(startTime))
                    {
                        isStartTimeInputValid = true;
                    } else 
                    {
                        Console.WriteLine("Oops. You aren't supposed to go into work before 5:00PM, remember?");

                    }
                }

                bool isEndTimeInputValid = false;
                while (!isEndTimeInputValid)
                {
                    Console.WriteLine("What time did you leave work tonight?: ");
                    endTimeInput = Console.ReadLine();

                     if (_service.IsInputTimeFormatValid(endTimeInput))
                    {
                        endTime = _service.GetTimeSpanFromString(endTimeInput);
                    } else
                    {
                        Console.WriteLine("Oops. It appears " + endTimeInput + " is not in the correct format.\nPlease enter time in one of the following formats: " + VALID_TIME_FORMATS);
                    }

                    if (_service.IsEndTimeValid(endTime) && _service.IsEndTimeAfterStartTime(startTime, endTime))
                    {
                        isEndTimeInputValid = true;
                    } else
                    {
                        Console.WriteLine("Oops. The time you entered is invalid. You must leave work before 4:00AM and you must leave after you went in.");
                    }
                }

                double result = _service.GetTotalEarnings(roundUpHours, familyIdInput, startTime, endTime);

                Console.WriteLine("Family " + familyIdInput + " owes you " + result.ToString("C") + " for your work tonight.");

                Console.Write("Would you like to calculate earnings for another shift? (Y/N)");

                string again = Console.ReadLine();

                if (again.ToUpper().Equals("N"))
                {
                    Console.WriteLine("Goodbye.");
                    isRunning = false;
                }             
            }

        }
    }
}
