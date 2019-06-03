using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SyncLesson
{
    public class Printer
    {
        private int number = -1;
        private object lockObject = new object();

        public void Print()
        {
            lock (lockObject) {
                var currentThread = Thread.CurrentThread;
                Console.WriteLine($"{currentThread.Name} начал свою работу");

                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(5 * new Random().Next(100));
                    Console.Write(i + " " + "(" + number + ")");
                    number = currentThread.ManagedThreadId;
                }

                Console.WriteLine($"\n{currentThread.Name} завершил свою работу");
            }
        }
    }
}
