using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
       // private static Dictionary<int, int> Factorials = new Dictionary<int, int>() { {0,1}, {1, 1}};
        public static int GetFactorial(int n) {
            // TODO this will fail above n == 20
            if (n == 0 || n == 1)
            {
                return 1;
            }
            
            var result = 1;
            for (var i = 2; i <= n; i++)
            {
                result *= i;
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