using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Async_Task
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // var timer1 = new Stopwatch(); // System.Diagnostics NameSpace
            // timer1.Start();
            //
            //
            // var armatureChef = new ArmatureChef(name: "Caleb");
            // armatureChef.MakeBreakFast();
            // Console.WriteLine($"Mode of Operation: Synchronous\nTime Taken: {timer1.ElapsedMilliseconds} milliseconds");

            Console.WriteLine("-----------------------------------------------\n-----------------------------------------------");
            var timer2 = new Stopwatch(); // System.Diagnostics NameSpace
            timer2.Start();
            var proChef = new ProChef(name: "David");
            await proChef.MakeBreakFast();
            Console.WriteLine($"Mode of Operation: Asynchronous\nTime Taken: {timer2.ElapsedMilliseconds} milliseconds");
        }

    }
}
