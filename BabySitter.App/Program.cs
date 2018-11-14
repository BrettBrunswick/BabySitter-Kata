using System;

namespace BabySitter.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("When did you start work tonight? ");
            var startTime = Console.ReadLine();
            Console.WriteLine(startTime);
        }
    }
}
