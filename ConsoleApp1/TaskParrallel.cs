using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    class TaskParrallel
    {
        static void Main(string[] args)
        {
            var t1 = new Task(() => DoWork(1, 1000));
            t1.Start();
            var t2 = new Task(() => DoWork(2, 3000));
            t2.Start();
            var t3 = new Task(() => DoWork(3, 1500));
            t3.Start();

            Console.WriteLine("Press any key to exit...");
            Console.Read();
        }
        static void DoWork(int id, int sleep)
        {
            Console.WriteLine("Task {0} is beginning...", id);
            Thread.Sleep(sleep);
            Console.WriteLine("Task {0} is Completed...", id);
        }
    }
    // ==================================================================================================

    class ParralleTask2
    {
        static void Main(string[] args)
        {
            var t1 = new Task(() => DoWork(1, 1000)); // initializing the task with id
            var t2 = new Task(() => DoWork(2, 2000));
            t1.Start();
            t2.Start();
            Console.WriteLine("Press Any key to exit...");
            Console.Read();

        }
        static void DoWork(int id , int sleep)
        {
            Console.WriteLine("Task {0} is beginning...", id);
            Thread.Sleep(1000);
            Console.WriteLine("Task {0} is Completed...", id);
        }
        static void DoMoreWork(int id, int sleep)
        {
            Console.WriteLine("Task {0} is beginning...", id);
            Thread.Sleep(3000);
            Console.WriteLine("Task {0} is Completed");
        }
    }

    class TaskFactoryExample
    {
        static void Main(string[] args)
        {
            // Creating task factory
            Task t1 = Task.Factory.StartNew(() => DoWork(1, 1000)).ContinueWith((prev) => DoMoreWork(1, 2000));
            Task t2 = Task.Factory.StartNew(() => DoWork(2, 2000));
            Console.Read();
        }
        static void DoWork(int id, int sleep)
        {
            Console.WriteLine("Task {0} is beginning...", id);
            Thread.Sleep(1000);
            Console.WriteLine("Task {0} is Completed...", id);
        }
        static void DoMoreWork(int id, int sleep)
        {
            Console.WriteLine("Task {0} is beginning...", id);
            Thread.Sleep(2000);
            Console.WriteLine("Task {0} is Completed", id);
        }
    }
    class Example
    {
        static void Main(string[] args)
        {
            
            int[] arr = new int[] {1,2,3,4,5,6,7,8,9,10 };
            
            Parallel.For(0, 10, i =>
            {
                Console.WriteLine("i :" + i);
                Thread.Sleep(2000);
               
            });          
            Console.Read();
        }

    }
    class Programs
    {
         static void Main(string[] args)
        {
            // Creating task factory
           // Task t1 = Task.Factory.StartNew(() => DoWork(1, 1000)).ContinueWith((prev) => DoMoreWork(1, 2000));
            //Task t2 = Task.Factory.StartNew(() => DoWork(2, 2000));

            // MutualExecution
            MutualExecution obj = new MutualExecution();
            Task t3 = new Task(obj.XWork);
            Task t4 = new Task(obj.YWork);
            t3.Start();
            t4.Start();
            Console.Read();
        }
        static void DoWork(int id, int sleep)
        {
            Console.WriteLine("Task {0} is beginning...", id);
            Thread.Sleep(1000);
            Console.WriteLine("Task {0} is Completed...", id);
        }
        static void DoMoreWork(int id, int sleep)
        {
            Console.WriteLine("Task {0} is beginning...", id);
            Thread.Sleep(2000);
            Console.WriteLine("Task {0} is Completed", id);
        }
    }
    //============================================================
    class MutualExecution
    {
        public void XWork()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("i :" + i);
                if (i == 5)
                    Thread.Sleep(5000);
            }
                Console.WriteLine("XWork Exiting...");
        }
        public  void YWork()
        {
            Console.WriteLine("YWork running...");
            Thread.Sleep(6000);
            Console.WriteLine("YWork exiting...");
        }
    }
}
