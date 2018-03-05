using System;
using System.Collections.Generic;

namespace BoxUnbox
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> items = new List<object> { 7, 28, -1, true, "chair" };
            int sum = 0;
            foreach (var item in items) {
                Console.WriteLine(item);
                if (item is int) {
                    sum += (int)item;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
