using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelSumTest
{
    internal class ParallelSum
    {
        long max;
        int threadCount;

        public ParallelSum(long max, int threadCount)
        {
            this.max = max;
            this.threadCount = threadCount;
        }

        public long Sum(out int elapsedTime)
        {

        }
    }
}
