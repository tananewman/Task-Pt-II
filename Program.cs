using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tasks2
{
    class Program
    {
        public static async Task BlockFunction()
        {
            Console.WriteLine("Welcome to the blocking function in thread {0}", Thread.CurrentThread.ManagedThreadId);
            for (int i = 5; i > 0; i--)
            {
                Console.WriteLine("Sleeping... {0}", i);
                Thread.Sleep(1000);
            }
        }

        //static async Task TaskRunner()
        //{
        //    Console.WriteLine("Hey from task runner, the thread id I'm running on is {0}", Thread.CurrentThread.ManagedThreadId);
        //    var task = Task.Run(HelloWorldTask);
        //    Thread.Sleep(20);

        //    Console.WriteLine("Kicked off task: task status is {0} on thread {1}.", task.Status, Thread.CurrentThread.ManagedThreadId);

        //    await task;

        //    Console.WriteLine("Task status is now {0}", task.Status);

        //    Console.WriteLine("Leaving main!!");
        //}

        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome from thread {0}!", Thread.CurrentThread.ManagedThreadId);
            var myTask = BlockFunction();
            Console.WriteLine("Hello from the other siiiiiddeee!!! (which is thread {0})", Thread.CurrentThread.ManagedThreadId);
            await myTask;
            Console.WriteLine("We done");

            Console.ReadLine();
        }
    }
}
