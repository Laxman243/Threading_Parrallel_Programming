using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // Single Threaded Program 
    class Program
    {
        // Every program has one thread i.e Main Thread.

        static void Main(string[] args)
        {
            
            // static method you can call it directly by their name OR use the class name as a reference to call
            Method1();
            Method2();
            for(int i = 0; i <= 10; i++)
            {
                Console.WriteLine("Main Method :" + i);
            }
            Console.WriteLine("Main Method Execution Completed");
            Console.Read();
        }

        // Created two methods to see the execution flow of Main Thread -> how it executed the methods
        // in Sequence order 

        static void Method1()
        {
            for(int i = 0; i <= 10; i++)
            {
                Console.WriteLine("Method1  : " + i);
            }
        }
        static void Method2()
        {
            for(int i =0; i <=10; i++)
            {
                Console.WriteLine("Method2  :" + i);
            }
        }
        /*the output you will get from this program will show you behaviour of Main Thread 
 it executes the logic one after another.
 in sequenctial order the execution will takes place
 */
    }

    // ============================================================================================================


    // NOW LETS CREATE THE DIFFERENTS THREADS TO EXECUTE EACH METHOD INDIVISUAL 

    class ThreadTest
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Three Threads Created for each Method to execute");
            
            // Creating the thread
            Thread t1 = new Thread(Method1); // First Thread is created and we passed the method name as the parameter in the thread
            Thread t2 = new Thread(Method2); // Second Thread is created
            Thread t3 = new Thread(Method3); // Third Thread is Created

            // now starts the threads to complete their execution

            t1.Start();
            t2.Start();
            t3.Start();

            Console.WriteLine("Main Method is Existing ...");
            Console.Read();

        }
        static void Method1()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("Method1 :" + i);
            }
            Console.WriteLine("Method1 Existing ....");
        }
        static void Method2()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("Method2 :" + i);
            }
            Console.WriteLine("Method2 Existing ....");
        }
        static void Method3()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("Method3 :" + i);
            }
            Console.WriteLine("Method3 Existing ....");
        }
    }
    /* Each time you compile this program you will get different outputs 
     We can't predict the execution of the threads.
     Because the thread execution time is allocated by CPU.
     in these case all 3 threads has the same priority.
     */

     // ========================================================================================================

    //NOW LETS IMPLEMENT SOME THINGS ON THIS PROGRAMS

    class ThreadTest1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Execution Starts from Here i .e Main Method  ....");

            // first create the object of the class because we have all three Non-Static methods
            ThreadTest1 obj = new ThreadTest1();

            // Threads Creation

            Thread t1 = new Thread(obj.Method1);
            Thread t2 = new Thread(obj.Method2);
            Thread t3 = new Thread(obj.Method3);

            // now starts the threads
            t1.Start();
            t2.Start();
            t3.Start();

            Console.WriteLine("Main Method Existing ....");
            Console.Read();

        }
        public void Method1()
        {
            for (int i = 0; i <= 50; i++)
            {
                Console.WriteLine("Method1 : " + i);
                if (i == 10) // here this thread will sleep for 5 sec when i == 10; while this will sleeping other thread will be contineuing thier execution 
                Thread.Sleep(5000);
            }
            Console.WriteLine("Method1 Existing ....");
        }
        public void Method2()
        {
            for (int i = 0; i <= 50; i++)
            {
                Console.WriteLine("Method2 : " + i);
            }
            Console.WriteLine("Method2 Existing ....");
        }
        public void Method3()
        {
            for (int i = 0; i <= 50; i++)
            {
                Console.WriteLine("Method3 : " + i);
            }
            Console.WriteLine("Method3 Existing ....");
        }
    }

    //===========================================================================================================

    // NOE LETS SEE THE EXAMPLE OF DELEGATS WHICH IS INTERNALLY CALLS THE METHHODS 

    class ThreadProgram
    {
        static void Method1()
        {
            for (int i = 0; i <= 50; i++)
            {
                Console.WriteLine("Method1 :" + i);
            }
            Console.WriteLine("Method1 Existing ....");
        }
        static void Method2()
        {
            for (int i = 0; i <= 50; i++)
            {
                Console.WriteLine("Method2 :" + i);
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
        static void Main(string[] args)
        {
            // now create the delegate --> delegate is a type safe function pointer .
            ThreadStart obj = new ThreadStart(Method1);
            Thread t1 = new Thread(obj);

            // ThreadStart Delegate 
            ThreadStart obj1 = new ThreadStart(Method2);
            Thread t2 = new Thread(obj1);

            // Threadstart delegate
            ThreadStart obj3 = new ThreadStart(Method3);
            Thread t3 = new Thread(obj3);

            // start the threads 
            t1.Start();
            t2.Start();
            t3.Start();

            for (int i = 0; i <= 50; i++)
            {
                Console.WriteLine("From Main Method : " + i);
            }
            Console.WriteLine("Main Method Existing ....");
            Console.ReadKey();
        }
    }
}

