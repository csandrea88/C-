using System;
using System.Collections.Generic;

namespace collections
{
    class Program
    
    {
        static void Main(string[] args)
        
        {
            /* 
           
            int[] numArr = {0,1,2,3,4,5,6,7,8,9};
            string[] namesarr = new string[4] { "Tim","Martin","Nikki","Sara"};
            bool[] boolarr = new bool[10] {true,false,true,false,true,false,true,false,true,false}
            
            int [,] array2D = new int[10,10];
            for (int i=0; i < 10; i++) {
                for (int k=0; k < 10; k++) {
                    array2D[i,k] = (i+1) * (k+1);
                Console.WriteLine(array2D[i,k]);
                }

            List<string> flavors = new List<string>() {"Chocolate","Chip Mint","Fudge Swirl","Snickers","Resses"};
            Console.WriteLine(flavors.Count);
            flavors.RemoveAt(2);
            Console.WriteLine(flavors.Count);
            }
            */

            string[] namesarr = {"Tim","Martin","Nikki","Sara"};
            
            List<string> flavors = new List<string>() {"Chocolate","Chip Mint","Fudge Swirl","Snickers","Resses"};
            
            Dictionary<string,string> profile = new Dictionary<string,string>();
            
            Random rand = new Random();

            for(int i=0; i < namesarr.Length ;i++) {
                int k = rand.Next(0,4);
                profile.Add(namesarr[i], flavors[k]);
            } 

            foreach (var entry in profile)
            {
            Console.WriteLine(entry.Key + " - " + entry.Value);
            }


            
        }
    }
}
