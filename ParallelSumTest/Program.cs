using System.Diagnostics;
using ThreadState = System.Threading.ThreadState;

namespace ParallelSumTest
{
    internal class Program
    {
        const long max = (long)1E9;

        static long[] sumArray = new long[10];

        static void SerialSum()
        {
            long sum = 0;
            for (int i = 1; i <= max; i++)
            {
                sum += i;
            }

            Console.WriteLine($"Serial sum: {sum}");
        }

        static void ParallelSum(long start, long end, int index)
        {
            long sum = 0;
            for (long i = start + 1; i <= end; i++)
            {
                sum += i;
            }

            sumArray[index] = sum;
        }
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            SerialSum();
            sw.Stop();
            Console.WriteLine("Serial time: " + sw.ElapsedMilliseconds + "ms");

            sw.Restart();

            // calc parallel with 10 threads
            Thread t1 = new Thread(() => ParallelSum(0, max / 10, 0));
            Thread t2 = new Thread(() => ParallelSum(max / 10, 2 * max / 10, 1));
            Thread t3 = new Thread(() => ParallelSum(2 * max / 10, 3 * max / 10, 2));
            Thread t4 = new Thread(() => ParallelSum(3 * max / 10, 4 * max / 10, 3));
            Thread t5 = new Thread(() => ParallelSum(4 * max / 10, 5 * max / 10, 4));
            Thread t6 = new Thread(() => ParallelSum(5 * max / 10, 6 * max / 10, 5));
            Thread t7 = new Thread(() => ParallelSum(6 * max / 10, 7 * max / 10, 6));
            Thread t8 = new Thread(() => ParallelSum(7 * max / 10, 8 * max / 10, 7));
            Thread t9 = new Thread(() => ParallelSum(8 * max / 10, 9 * max / 10, 8));
            Thread t10 = new Thread(() => ParallelSum(9 * max / 10, max, 9));

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();
            t6.Start();
            t7.Start();
            t8.Start();
            t9.Start();
            t10.Start();

            //while (
            //    t1.ThreadState == ThreadState.Running ||
            //    t2.ThreadState == ThreadState.Running ||
            //    t3.ThreadState == ThreadState.Running ||
            //    t4.ThreadState == ThreadState.Running ||
            //    t5.ThreadState == ThreadState.Running ||
            //    t6.ThreadState == ThreadState.Running ||
            //    t7.ThreadState == ThreadState.Running ||
            //    t8.ThreadState == ThreadState.Running ||
            //    t9.ThreadState == ThreadState.Running ||
            //    t10.ThreadState == ThreadState.Running
            //    ) ;

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            t5.Join();
            t6.Join();
            t7.Join();
            t8.Join();
            t9.Join();
            t10.Join();

            long finalSum = sumArray.Sum();

            Console.WriteLine("Parallel sum: " + finalSum);

            sw.Stop();
            Console.WriteLine("Parallel time: " + sw.ElapsedMilliseconds + "ms");
        }
    }
}