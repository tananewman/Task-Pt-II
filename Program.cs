using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks2
{
    class Program
    {
        public static async Task BlockingFunction()
        {
            Console.WriteLine("Welcome to the blocking function in thread {0}", Thread.CurrentThread.ManagedThreadId);
            for (int i = 5; i > 0; i--)
            {
                Console.WriteLine("Sleeping... {0}", i);
                Thread.Sleep(1000);
            }
        }

        public static async Task<HttpResponseMessage> LongerBlockingFunction()
        {
            using (var client = new HttpClient())
            {
                var task = client.GetAsync("https://www.espn.com");
                Console.WriteLine("Hello from longer blocking function! Which is running in thread {0}", Thread.CurrentThread.ManagedThreadId);
                return await task;
            }
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome from thread {0}!", Thread.CurrentThread.ManagedThreadId);
            var myTask = LongerBlockingFunction();
            Console.WriteLine("Hello from the other siiiiiddeee!!! (which is thread {0})", Thread.CurrentThread.ManagedThreadId);
            await myTask;
            Console.WriteLine(await myTask.Result.Content.ReadAsStringAsync());
            Console.WriteLine("We done");

            Console.ReadLine();
        }
    }
}
