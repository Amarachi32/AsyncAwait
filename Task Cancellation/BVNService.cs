using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Cancellation
{
   internal class BVNService
    {

        /*I created a custom CancellationTokenSourceClass
         so I can add a prop to tell if task was manually cancelled
        i.e to differentiate between timeout operation and intentional cancellation.
         */

        private static readonly CustomCancellationTokenSource CancellationTokenSource = new CustomCancellationTokenSource();
        // private static readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public static async Task BeginBackUp(int timeout)
        {

            // Creating a task to listen to keyboard key press
            var keyBoardPrompt = Prompt();


            try
            {
                Console.WriteLine("----Starting-----");
                CancellationTokenSource.CancelAfter(timeout);
                await BackUpRecords(500, CancellationTokenSource.Token);

            }
            catch (TaskCanceledException)
            {
                if (!CancellationTokenSource.WasManuallyCancelled)
                {
                    Console.WriteLine("Timeout!");
                }
                Console.WriteLine($"Backup was cancelled");
                
            }
            finally
            {
                CancellationTokenSource.Dispose();
            }

            await keyBoardPrompt;

        }


        private static Task Prompt()
        {

            // Creating a task to listen to keyboard keypress
           return Task.Run(() =>
            {
                Console.WriteLine("Press enter to cancel");
                Console.ReadKey();

                // Cancel the task
                CancellationTokenSource.Cancel();
            });
        }



        /*If for any reason, the long running operation takes too long to execute
         * or we do not need its result anymore,
         * we might want to cancel it.
         * In order to do that we need to
         * pass a CancellationToken to the long running method.
         */



        /*Checking if the method needs to stop is done by reading
         *the IsCancellationRequested property.
         *It is also possible to use the ThrowIfCancellationRequested
         * method which will throw an OperationCanceledException.
         */

        private static Task  BackUpRecords(int size, CancellationToken cancellationToken, int delay = 1000)
        {
            Task task = null;

            // Start a task and return it
           return task = Task.Run(() =>
            {
                // Loop for a defined number of iterations
                for (var i = 0; i < size; i++)
                {
                    // Check if a cancellation is requested, if yes,
                    // throw a TaskCanceledException.

                    if (cancellationToken.IsCancellationRequested)
                        throw new TaskCanceledException(task);

                    Console.WriteLine($"Backing Up Record-{i}...");

                    // Do something that takes times like a Thread.Sleep
                    Task.Delay(delay <= 100 ? 100 : delay);
                }

            }, cancellationToken);
        }
    }
}
