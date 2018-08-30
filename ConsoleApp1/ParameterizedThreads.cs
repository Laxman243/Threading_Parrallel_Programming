using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ParameterizedThreads
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Method Starting");
            // Ways of creating Threads and executing 
            // First Way
            Thread t = new Thread(Method1);
            t.Start();

            // Second Way 
            ThreadStart obj = new ThreadStart(Method2);
            Thread t1 = new Thread(obj);

            t1.Start();

            // Third Way using Anonymous Methods 
            ThreadStart obj1 = delegate () { Method3(); };
            Thread t2 = new Thread(obj1);
            t2.Start();

            // Fourth Way Using Lamda Expression
            ThreadStart obj3 = () => Method4();
            Thread t3 = new Thread(obj3);
            t3.Start();

            Console.WriteLine("Main Method Existing ....");
            Console.ReadKey();
        }
        static void Method1()
        {
            for (int i = 0; i <= 50; i++)
            {
                Console.WriteLine("Method1 :" + i);
                if (i == 10)
                    Thread.Sleep(5000);
            }
            Console.WriteLine("Method1 Existing ....");
        }
        static void Method2()
        {
            for (int i = 0; i <= 50; i++)
            {
                Console.WriteLine("Method2 :" + i);
                if (i == 9)
                    Thread.Sleep(3000);
            }
            Console.WriteLine("Method2 Existing ....");
        }
        static void Method3()
        {
            for (int i = 0; i <= 50; i++)
            {
                Console.WriteLine("Method3 :" + i);
            }
            Console.WriteLine("Method3 Existing ....");
        }
        static void Method4()
        {
            for (int i = 0; i <= 50; i++)
            {
                Console.WriteLine("Method4 :" + i);
            }
            Console.WriteLine("Method4 Existing ....");
        }
    }

    // =================================================================================================================

    // NOW SEE THE EXAMPLE OF PARAMETERIZD THREADSTART

    class ThreadParameterized
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Method Starting .....");
            //ThreadStart obj = new ThreadStart(Method2);
            // Parameterized Thread ===== Constructor
            ParameterizedThreadStart obj1 = new ParameterizedThreadStart(Method1);
            Thread t = new Thread(obj1);
            Thread t2 = new Thread(Method2);
            t.Start(50);
            t2.Start();

            t.Join();

            for (int i = 0; i <= 50; i++)
            {
                Console.WriteLine("Main Method :" + i );
            }
            Console.WriteLine("Main Method Existing ...");
            Console.Read();
        }
        static void Method1(object max)
        {
            int num = Convert.ToInt32(max);
            for (int i = 0; i <= num; i++)
            {
                Console.WriteLine("Method1 :" + i);
              
            }
            Console.WriteLine("Method1 exiting ... ");
        }
        static void Method2()
        {
            for (int i = 0; i <= 50; i++)
            {
                Console.WriteLine("Method2 :" + i);
            }
            Console.WriteLine("Method2 Exitings ....");
        }
    }

    //=========================================================================================
    //                                  THREAD-LOCKING
    class ThreadLock
    {
        static void Main(string[] args)
        {
            ThreadStart obj = new ThreadStart(Display);
            Thread t = new Thread(obj);
            Thread t1 = new Thread(Display);
            Thread t2 = new Thread(Display);
            t.Start();t1.Start();t2.Start();
            Console.Read();
        }
        static void Display()
        {
            Console.Write("[CSharp is an");
            Thread.Sleep(5000);
             Console.WriteLine("Object Oriented Programming Lnguage]");
        }    
    }

    // ======================================================================================================
    // To Overcome this above problem -- go for Thread-Locking

    class LockThreadExample
    {
        static void Main(string[] args)
        {
            LockThreadExample obj = new LockThreadExample();
            Thread t1 = new Thread(obj.Display);
            Thread t2 = new Thread(obj.Display);
            Thread t3 = new Thread(obj.Display);

            t1.Start(); t2.Start(); t3.Start();

            Console.Read();
        }
        public void Display()
        {
            // provide lock here 
            lock(this)
            {
                Console.Write("[CSharp is an ");
                Thread.Sleep(5000);
                Console.WriteLine("Object Oriented Programming Lnguage]");
            }
        }
    }
    // ====================================================================================================
    //                                          Thread Priorty
    class ThreadPriorityExample
    {
        static int Count;
        static int Count1;
        static void Main(string[] args)
        {
            Thread t1 = new Thread(IncrementMethod1);
            Thread t2 = new Thread(IncrementMethod2);

            t1.Priority = ThreadPriority.Lowest;
            t2.Priority = ThreadPriority.AboveNormal;

            t1.Start();
            t2.Start();

            // now i want to make main thread to sleep for 5 sec
            Console.WriteLine("Main Thread Sleeping");
            Thread.Sleep(5000);
            Console.WriteLine("Main Thread Awake");

            // y i am aborting here because both Method has While loop which will iterate infinite times
            t1.Abort();
            t2.Abort();

            Console.WriteLine("Count :" + Count);
            Console.WriteLine("Count1 :" + Count1);

            Console.ReadKey();
        }
        static void IncrementMethod1()
        {
            while(true)
            {
                Count += 1;
            }
        }
        static void IncrementMethod2()
        {
            while (true)
                Count1 += 1;
        }
    }
    //=========================================================================================================
    // Performance 

    class Performance
    {
        static void Main(string[] args)
        {
            Stopwatch s1 = new Stopwatch();

            Thread t1 = new Thread(Method1);
            Thread t2 = new Thread(Method2);

            // start th estop watch
            s1.Start();
            t1.Start();
            t2.Start();
            s1.Stop();

            t1.Join();
            t2.Join();

            Console.WriteLine(s1.ElapsedMilliseconds);
            Console.Read();
        }
        static void Method1()
        {
            long Count = 0;
            for (int i = 0; i <= 100000000; i++)
            {
                Count++;
            }
            Console.WriteLine("Increment : " + Count);
        } static void Method2()
        {
            long Count1 = 0;
            for (int i = 0; i <= 100000000; i++)
            {
                Count1++;
            }
            Console.WriteLine("increment :" + Count1);
        }
    }
}
