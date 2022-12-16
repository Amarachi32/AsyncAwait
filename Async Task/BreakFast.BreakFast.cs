using System;
using System.Threading.Tasks;


namespace Async_Task
{
    internal partial class BreakFast
    {
        public static async Task PrepareAsync()
        {
            PourMiloTea();
            Console.WriteLine("Tea is ready");

            var egg = FryEggsAsync(2);
            var beef = FryBeefAsync(3);


            var butteredToast = ButteredToast(4); // More than 2 slices will explode the toaster

            // var toast = ToastBreadAsync(2);
            // ApplyButter(await toast);


            //Error Handling
            try
            {
                await butteredToast;
                Console.WriteLine("toast is ready");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
              
            }
           

            await egg;
            Console.WriteLine("eggs are ready");

            await beef;
            Console.WriteLine("beef is ready");

            Console.WriteLine("Breakfast is ready!");
        }


        //Example of "Composition With Tasks"
        private static async Task<Toast> ButteredToast(int number)
        {
            var toast = await ToastBreadAsync(number);
            BreakFast.ApplyButter(toast);
            return null;
        }
        private static async Task<Toast> ToastBreadAsync(int slices)
        {
           

            for (var slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }

            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            if (slices > 2)
            {
                Console.WriteLine("☄ ☄ ☄");
                throw new InvalidOperationException("The toaster is on fire");
            }
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Beef> FryBeefAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of beef in the pan");
            Console.WriteLine("cooking first side of beef...");
            await Task.Delay(3000);
            for (var slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of beef");
            }

            Console.WriteLine("cooking the second side of beef...");
            await Task.Delay(3000);
            Console.WriteLine("Put beef on plate");

            return new Beef();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }
    }
}