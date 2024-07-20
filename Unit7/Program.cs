using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //set sort type
            // 1 = bubble sort
            // 2 = quick sort


            int sortType = 1;

            //small array

            int[] smallArray = getArray(10, 100);

            int[] newSmallArray = new int[smallArray.Length];
            Array.Copy(smallArray,0,newSmallArray,0,newSmallArray.Length);

            int[] quickSmallArray = new int[newSmallArray.Length];
            Array.Copy(newSmallArray,0,quickSmallArray,0,quickSmallArray.Length);

            string size = "bubble small";

            runSorthArray(smallArray, size, sortType);


            //medium array

            int[] mediumArray = getArray(1000, 100);

            int[] newMediumArray = new int[mediumArray.Length];
            Array.Copy(mediumArray, 0, newMediumArray, 0, newMediumArray.Length);

            int[] quickMediumArray = new int[newMediumArray.Length];
            Array.Copy(newMediumArray, 0, quickMediumArray, 0, quickMediumArray.Length);

            size = "bubble medium";

            runSorthArray(mediumArray, size, sortType);


            //large array

            int[] largeArray = getArray(10000, 100);

            int[] newLargeArray = new int [largeArray.Length];
            Array.Copy(largeArray, 0, newLargeArray, 0, newLargeArray.Length);

            int[] quickLargeArray = new int[newLargeArray.Length];
            Array.Copy(newLargeArray, 0, quickLargeArray, 0, quickLargeArray.Length);

            size = "bubble large";

            runSorthArray(largeArray, size, sortType);


            //remove duplicate

            newSmallArray = UniqueElements(newSmallArray);
            size = "unique small array";
            runSorthArray(newSmallArray, size, sortType);

            newMediumArray = UniqueElements(newMediumArray);
            size = "unique medium array";
            runSorthArray(newMediumArray, size, sortType);

            newLargeArray = UniqueElements(newLargeArray);
            size = "unique large array";
            runSorthArray(newLargeArray, size, sortType);


            //set sort type
            // 1 = bubble sort
            // 2 = quick sort


            sortType = 2;

            size = "quck small";

            runSorthArray(smallArray, size, sortType);

            size = "quick medium";

            runSorthArray(smallArray, size, sortType);

            size = "quck large";

            runSorthArray(smallArray, size, sortType);

        }

        private static int[] UniqueElements(int[] array)
        {
            HashSet<int> result = new HashSet<int>();
            int[] tmp = new int[array.Length];
            int index = 0;

            foreach (int i in array) 
            { 
                if (result.Add(i))
                {
                    tmp[index++] =i;
                }
            }

            return result.ToArray();
        }

        private static void runSorthArray(int[] arraySize, string size, int sortType)
        {
            long elapseTime = 0;

            string sort = string.Empty;


            if (sortType ==1)
            {
                sort = "bubble";
            }
            else
            {
                sort = "quick";
            }

            Console.Write($"Array before the {sort} sort");
            Console.WriteLine("");
            for (int i =0; i < arraySize.Length;i++)
            {
                Console.Write(arraySize[i] + " " );
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine("");
            if (sort == "bubble")
            {
                bubbleSort(arraySize);
            }
            else
            {
                quickSort(arraySize, 0, arraySize.Length - 1);
            }
            Console.WriteLine("");
            Console.Write($"Array after the {sort} sort \n");
            for (int i = 0; i < arraySize.Length; i++)
            {
                Console.Write(arraySize[i] + " ");
            }

            stopwatch.Stop();

            elapseTime = stopwatch.ElapsedTicks;
            Console.WriteLine("\n");
            Console.WriteLine($"The run time is for the {size} array in milliseconds is {elapseTime}");
            Console.WriteLine("\n");

            Console.Read();
        }

        private static void quickSort(int[] arraySize, int low, int high)
        {
            if (arraySize ==null || arraySize.Length == 0)
            {
                return;
            }    
            
            if (low >=high)
            {
                return;
            }
            
            
            int middle  = low + (high - low) / 2;
            int pivot = arraySize[middle];

            int l = low;
            int h = high;

            while (l <= h)
            {
                while (arraySize[l] < pivot)
                {
                    l++;
                }
                while (arraySize[h] > pivot)
                {
                    h--;
                }

                if (l <= h)
                {
                    int temp = arraySize[l];
                    arraySize[l] = arraySize[h];
                    arraySize[h] = temp;
                    l++;
                    h--;
                }
            }

            if (low < h)
            {
                quickSort(arraySize,low, h);
            }
            else
            {
                quickSort(arraySize, l, high);
            }
        }

        private static void bubbleSort(int[] arraySize)
        {
           int temp = 0;
           for (int i = 0;i < arraySize.Length;i++) 
           {
                for (int j = 0;j < arraySize.Length -1; j++)
                {
                    if (arraySize[j] > arraySize[j + 1]) 
                    {
                        temp = arraySize[j + 1];
                        arraySize[j + 1] = arraySize[j];
                        arraySize[j] = temp;
                    }
                }
            
           }
        }

        private static int[] getArray(int size, int randomMaxSize)
        {
            int[] array = new int[size]; 

            for (int i = 0; i < array.Length; i++) 
            {
                array[i] = getRandomNumber(1, randomMaxSize);
            }

            return array;
        }
        private static readonly Random random = new Random();
        private static int getRandomNumber(int min, int max)
        {
            lock(random)
            {
                return random.Next(min, max);
            }
        }
    }
}
