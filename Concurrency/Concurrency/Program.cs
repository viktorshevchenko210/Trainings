using System;
using System.Threading.Tasks;

namespace Concurrency
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
            Console.ReadKey();
            /*As a result we get:
            Before first await
            Between awaits
            Method returned
            After second await
            Task completed*/

            /* We end up with two active threads
             
              1) After "await Task.Delay(1000)" in DemoCompletedAsync()  
              continuation executes in any thread from thread pool

              2) After await in MainAsync() 
              continuation executes in any thread from thread pool as well
            */
        }

        private static async Task MainAsync()
        {
            Task task = DemoCompletedAsync();
            Console.WriteLine("Method returned");
            await task;
            Console.WriteLine("Task completed");
        }

        private static async Task DemoCompletedAsync()
        {
            Console.WriteLine("Before first await");
            await Task.FromResult(10);
            Console.WriteLine("Between awaits");
            await Task.Delay(1000);
            Console.WriteLine("After second await");
        }
    }
}
