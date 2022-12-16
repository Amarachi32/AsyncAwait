using System;
using System.Threading.Tasks;

namespace Async_Task
{
    internal static partial class BreakFast
    {

        public static void Prepare()
        {
            PourMiloTea();
            Console.WriteLine("Tea is ready");

            FryEggs(2);
            Console.WriteLine("eggs are ready");

            FryBeef(3);
            Console.WriteLine("beef is ready");

            var toast = ToastBread(2);
            ApplyButter(toast);

            Console.WriteLine("toast is ready");

            Console.WriteLine("Breakfast is ready!");
        }
        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static Toast ToastBread(int slices)
        {
            for (var slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static Beef FryBeef(int slices)
        {
            Console.WriteLine($"putting {slices} slices of beef in the pan");
            Console.WriteLine("cooking first side of beef...");
            Task.Delay(3000).Wait();
            for (var slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of beef");
            }
            Console.WriteLine("cooking the second side of beef...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put beef on plate");

            return new Beef();
        }

        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static MiloTea PourMiloTea()
        {
            Console.WriteLine("Pouring Milo");
            return new MiloTea();
        }
    }

}