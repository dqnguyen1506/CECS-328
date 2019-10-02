using System;
using System.Linq;
namespace Lab_1
{
    
    class Program
    {
        public static void exchange(int[] data, int m, int n)
        {
            int temporary;

            temporary = data[m];
            data[m] = data[n];
            data[n] = temporary;
        }
        public static void IntArrayBubbleSort(int[] data)
        {
            int i, j;
            int N = data.Length;

            for (j = N - 1; j > 0; j--)
            {
                for (i = 0; i < j; i++)
                {
                    if (data[i] > data[i + 1])
                        exchange(data, i, i + 1);
                }
            }
        }
        public static int linearSearch(int[] a, int key)
        {
            for(int i = 0; i < a.Length; i++)
            {
                if (a[i] == key)
                {
                    //Console.WriteLine("(linearSearch) Found the key: " + key + " at index: " + i);
                    return i;
                }
            }
            return 0;
           
        }
        public static int binarySearch(int[] a, int key)
        {
            int min = 0;
            int max = a.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (key == a[mid])
                {
                    return ++mid;
                }
                else if (key < a[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return 0;
        }
        static void Main(string[] args)
        {
            bool finished = false;
            while (!finished)
            {
                Console.WriteLine("Enter a positive integer: ");
                int n = Convert.ToInt32(Console.ReadLine());
                int[] a = new int[n];
                Random rnd = new Random();
                //generate n random integers
                //between -1000 and 1000
                //and save them  in an array a
                for (int i = 0; i < n; i++)
                {
                    //pick a random number between -1000 and 1000
                    int randNum = rnd.Next(-1000, 1001);
                    a[i] = randNum;
                }
                //use bubble sort to sort the list
                IntArrayBubbleSort(a);
                //start the timer
                var watch = System.Diagnostics.Stopwatch.StartNew();
                //linear search
                for (int i = 0; i < 100; i++)
                {
                    int randElement = rnd.Next(0, n);
                    int key = a[randElement];
                    int index;
                    index = binarySearch(a, key);
                }
                //Stop the timer
                watch.Stop();
                double elapsedMs = watch.ElapsedMilliseconds;
                double avgTime = elapsedMs / 100;
                Console.WriteLine("------LinearSearch------");
                Console.WriteLine("Elapsed time: " + elapsedMs + "ms");
                Console.WriteLine("Average time: " + avgTime + "ms");

                
                Console.WriteLine("Keep Going?: ");
                string answer = Console.ReadLine();
                if(answer.ToLower() == "n")
                {
                    finished = true;
                }
            }
            
             
        }
    }
}
