using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace futureAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            int yy = Add(4,5);
            Console.WriteLine(yy);
            Console.WriteLine(IsOdd(5));

            
            BuildWebHost(args).Run();

        }

        public static int Add(int x, int y) 
        {
            return x + y;
        }

        public static bool IsOdd(int value)
        {
            return value % 2 == 1;
        }
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
