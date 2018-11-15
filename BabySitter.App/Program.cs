using System;
using System.Collections.Generic;

namespace BabySitter.App
{
    class Program
    {

        private const string INTRODUCTION = "";

        static void Main(string[] args)
        {
            BabySitterService service = new BabySitterService();
            Console.WriteLine("When did you leave work tonight?: ");
            var startTime = Console.ReadLine();
            Console.WriteLine(startTime);
        }
    }
}
