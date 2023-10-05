using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        // Cache the values for performance/fun.
        private static readonly Dictionary<int, int> Factorials = new () { {0,1}, {1, 1}};
        public static int GetFactorial(int n) {
            // TODO this will fail above n == 20
            var maxFactorial = Factorials.Count - 1 ;
            if (maxFactorial > n)
            {
                return Factorials[n];
            }
            var result = Factorials[maxFactorial];
            for (var i = maxFactorial; i <= n; i++)
            {
                result *= i;
                Factorials[i] = result;
            }

            return result;
        }

        public static string FormatSeparators(params string[] items)
        {
            // No Oxford comma
            return  $"{string.Join(", ", items.SkipLast(1))} and {items.Last()}";
        }
    }
}