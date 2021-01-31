using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency3
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
            After second await
            Method returned
            Task completed*/

            /*We get line "After second await" first because 
             after await Task.Delay(1000) method DemoCompletedAsync continues executing 
             but if we erase Thread.Sleep(2000) we will get results as in Concurrency2 demo
            */

            /*We end up with two active threads
             
             1) After "await Task.Delay(1000)" in DemoCompletedAsync()
             continuation executes in any thread from thread pool

             2) But after "await task" in MainAsync() task is completed, so
             continuatuon executes synchronously in MainThread!!(because task is completed)
            */
        }

        private static async Task MainAsync()
        {
            Task task = DemoCompletedAsync();
            Thread.Sleep(2000);
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
