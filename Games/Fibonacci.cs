using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    public class Fibonacci
    {
        public Fibonacci()
        {

        }
        public long BruteForceFibonacci(long nr)
        {
            if (nr < 3)
            {
                return 1;
            }
            else
            {
                return BruteForceFibonacci(nr - 1) +
                    BruteForceFibonacci(nr - 2);
            }
        }
        /*
         * This code defines the nth Fibonacci number, 
         * using memoization to avoid redundant recursive calls. 
         * The memoization table is implemented as a Dictionary<int, int> object,
         * which maps each value of n to its corresponding Fibonacci number. 
         * The Fib method checks if the memoization table already 
         * contains the desired Fibonacci number before proceeding with the computation. 
         * If the memoization table does not contain the value, 
         * the method computes the Fibonacci number as usual, 
         * adds it to the memoization table for future use, and returns the result.
         */
        private Dictionary<long, long> memoized = new Dictionary<long, long>();

        public long MemoizedFibonacci(int n)
        {
            // prevent obsolete recursive call
            if (memoized.ContainsKey(n))
            {
                return memoized[n];
            }
            if (n <= 2)
            {
                return 1;
            }
            long result = MemoizedFibonacci(n - 1) +
                MemoizedFibonacci(n - 2);
            memoized[n] = result;
            return result;
        }


    }
}
