using System;
using System.Collections.Generic;

namespace basic13
{
    class Program
    {        
        static void Main(string[] args)
        {
            
            List<object> List = new List<object>() {1, 5, 10, -2};
            
           
            for (int i=1; i<List.Count; i++) {
                if ((int)List[i] < 0) {
                    List[i] = "Dojo";
                }
            }
            foreach (var num in List) {
                 Console.WriteLine(num);
            }
                    
            
        }
    }
}
/*  1.)
            for (int i=1; i<=255; i++) {
                Console.WriteLine(i);
    2.)
            for (int i=1; i<=255; i++) {
                if (i % 2 != 0) {
                    Console.WriteLine(i);
                }
    3.) 
            int sum = 0;
            for (int i=1; i<=255; i++) {
                if (i % 2 != 0) {
                    sum += i;
                    Console.WriteLine("New number: " + i + " & Sum: " + sum);
                }
    4.)
            int[] numArr2 = {1,3,5,7,9,13};
            for (int i=0; i<numArr2.Length; i++) {
                    Console.WriteLine("Array: " + i + " & value: " + numArr2[i]);
            }
    5.) 
            int[] numArr2 = {13,-3,5,-6};
            int max = numArr2[0];
            for (int i=1; i<numArr2.Length; i++) {
                if (numArr2[i] > max) {
                    max = numArr2[i];
                    //Console.WriteLine("Array: " + i + " & value: " + numArr2[i]);
                }
            }
            Console.WriteLine("Max: " + max);
    6.)
            int[] numArr2 = {13,-3,5,-6};
            int avg = numArr2[0];
            for (int i=1; i<numArr2.Length; i++) {
                    avg += numArr2[i];
                    //Console.WriteLine("Array: " + i + " & value: " + numArr2[i]);
            }
            avg = avg/numArr2.Length;
            Console.WriteLine("Avg: " + avg);
    7.)
            List<int> nums = new List<int>();
            
            for (int i=1; i<256; i++) {
                if (i % 2 != 0) {
                    nums.Add(i);
                    Console.WriteLine(i);
                }
            }
            
            Console.WriteLine("Nums.Length: " + nums.Count);
    8.)
            int[] numArr2 = {1, -9, 9, 3, 0, 5, 7, -5};
            int y = -1;
            int count = 0;

            for (int i=0; i<numArr2.Length; i++) {
                if (numArr2[i] > y) {
                    Console.WriteLine(numArr2[i]);
                    count ++; 
                }
            }
            
            Console.WriteLine(count);
    9.)
            int[] numArr2 = {1, 5, 10, -2};
            
            for (int i=0; i<numArr2.Length; i++) {
                numArr2[i] *= numArr2[i];
                Console.WriteLine(numArr2[i]);
            }
            Console.WriteLine(numArr2.Length);

    10.)
            int[] numArr2 = {1, 5, 10, -2};
            
            for (int i=0; i<numArr2.Length; i++) {
                
                if (numArr2[i] < 0){
                    numArr2[i] = 0;
                }
                Console.WriteLine(numArr2[i]);
            }
            
            Console.WriteLine(numArr2.Length);
    11.)
            int[] numArr2 = {1, 5, 10, -2};

            int avg = numArr2[0];
            int min = numArr2[0];
            int max = numArr2[0];
            
            for (int i=1; i<numArr2.Length; i++) {
                    if (numArr2[i] < min) {
                        min = numArr2[i];
                    }
                    else if (numArr2[i] >  max) {
                        max = numArr2[i];    
                    }
                    avg += numArr2[i];
                    
            }
            
            avg = avg/numArr2.Length;
            Console.WriteLine("Avg: " + avg + " Min: " + min + " Max: " + max);

    12.)
            int[] numArr2 = {1, 5, 10, -2};
            
           
            for (int i=1; i<numArr2.Length; i++) {
                numArr2[i-1] = numArr2[i];

            }
            numArr2[numArr2.Length-1] = 0;
            foreach (int num in numArr2) {
                 Console.WriteLine(num);
            }

    13.)
            List<object> List = new List<object>() {1, 5, 10, -2};
            
            for (int i=1; i<List.Count; i++) {
                if ((int)List[i] < 0) {
                    List[i] = "Dojo";
                }
            }
            foreach (var num in List) {
                 Console.WriteLine(num);
            }


*/