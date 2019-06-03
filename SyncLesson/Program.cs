using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SyncLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[20];

            Printer printer = new Printer();

            for (int i = 0; i < threads.Length; i++)
            {
                Thread thread = new Thread(printer.Print);
                thread.Name = $"Поток номер {thread.ManagedThreadId}";
                threads[i] = thread;
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            Console.ReadLine();
        }
    }
}
