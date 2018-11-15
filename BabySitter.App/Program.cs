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

            string familyId = "";
            string startTime = "";
            string endTime = "";

            do 
            {
                Console.Write("What family did you work for tonight? (A, B, or C): ");
                familyId = Console.ReadLine();
                
            } while (!service.IsValidFamily(familyId));

            do 
            {
                Console.WriteLine("When did you start work? (Accepted formats: '12:00', '02:00', '17:00' '01:00PM', '10:00 AM'): ");
                startTime = Console.ReadLine();
                
            } while (!service.IsInputTimeFormatValid(startTime));

            do 
            {
                Console.WriteLine("When did you leave work? (Accepted formats: '12:00', '02:00', '17:00' '01:00PM', '10:00 AM'): ");
                endTime = Console.ReadLine();
                
            } while (!service.IsInputTimeFormatValid(endTime));
        }
    }
}
