using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {
          public static string TossCoin(Random rand) 
        {    
            string [] numArr2 = {"Todd","Tiffany","Charlie","Geneva","Sydney"};
            Random rnd=new Random();
            string[] MyRandomArray = numArr2.OrderBy(x => rnd.Next()).ToArray();    
            

        }
        public static double TossMultipleCoins(int val) {
            
            int countHds = 0;

            int i = 1;

            Random rand = new Random();
             Console.WriteLine(rand);

            while (i <= val) {
                string result = TossCoin(rand); 
                Console.WriteLine(result);
                if (result == "Heads") {
                    countHds++;
                }
                i++;
            }

            Console.WriteLine(countHds);
            Console.WriteLine(val);
            double ratio = countHds / val;
            return ratio;
             
        }
        static void Main(string[] args)
        {       
            double ratio = TossMultipleCoins(5);
            Console.WriteLine(ratio); 
                
        } 
       
    }
}

/*
            Random Array
            int[] numArr = new int[10];            
            
            Random rand = new Random();

            for(int i=0; i < numArr.Length; i++) {
                int k = rand.Next(0,9);
                numArr[i] = k;
            } 

            int min = numArr[0];
            int max = numArr[0];
            int sum = numArr[0];

            for (int i=1; i<numArr.Length; i++) {
                sum += numArr[i];
                if (numArr[i] < min) {
                    min = numArr[i];
                }
                else if (numArr[i] >  max) {
                    max = numArr[i];    
                }
            }
            foreach (var num in numArr) {
                 Console.WriteLine(num);
            }
            Console.WriteLine(sum);    

          
        Coin tossing assignment, but reandom doesn't seem to be working right.  
          public static string TossCoin(Random rand) 
        {    
            int k = rand.Next(0,1);
            Console.WriteLine(k);
            if (k == 1) {
                return "Heads";
            } else {
                return "Tails";
            }
        }
    
        public static double TossMultipleCoins(int val) {
            
            int countHds = 0;

            int i = 1;

            Random rand = new Random();
             Console.WriteLine(rand);

            while (i <= val) {
                string result = TossCoin(rand); 
                Console.WriteLine(result);
                if (result == "Heads") {
                    countHds++;
                }
                i++;
            }

            Console.WriteLine(countHds);
            Console.WriteLine(val);
            double ratio = countHds / val;
            return ratio;
             
        }
        static void Main(string[] args)
        {       
            double ratio = TossMultipleCoins(5);
            Console.WriteLine(ratio); 
                
        } 
       
    }
}

 */
