using System;

namespace BabySitter.App
{
    class Program
    {
        
        static void Main(string[] args)
        {
            BabySitterService service = new BabySitterService();

            Console.Write("When did you start work tonight? ");
            var startTime = Console.ReadLine();
            Console.WriteLine(startTime);
        }
    }
}
