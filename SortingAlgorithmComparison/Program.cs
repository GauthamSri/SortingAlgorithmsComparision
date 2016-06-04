using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithmComparison
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Enter the input size");
            int size = Convert.ToInt32(Console.ReadLine());

            int[] input = new int[size];
            int[] inputForHeapSort = new int[size];
            int[] inputForMergeSort = new int[size];
            int[] inputForInPlaceQuickSort = new int[size];
            int[] inputForModifiedQuickSort = new int[size];
            Random rnd = new Random();

            for (int i = 0; i < size; i++)
            {

                int no = rnd.Next(0, size);
                input[i] = no;
            }

            CompareAlgorithmsForGivenArray(input);
            

            specialCase();
           
            Console.Read();
        }

        public static void specialCase()
        {
            Console.WriteLine("Special Cases: ");
            Console.WriteLine("Enter the input size: (less than 8000 for special case):");
            int size = Convert.ToInt32(Console.ReadLine());

            List<int> nos = new List<int>();
            Random rnd = new Random();

            for (int i = 0; i < size; i++)
            {

                int no = rnd.Next(0, size);
                nos.Add(no);
            }

            Console.WriteLine("Special Cases 1: passing Sorted array ");
            int[] sortedArray = nos.OrderBy(t => t).ToArray();

            CompareAlgorithmsForGivenArray(sortedArray);

            int[] inverselySortedArray = nos.OrderByDescending(t => t).ToArray();

            Console.WriteLine("Inversely Sorted Array");

            CompareAlgorithmsForGivenArray(inverselySortedArray);
        }

        public static void CompareAlgorithmsForGivenArray(int[] input)
        {
            int arraySize = input.Length;
            int[] inputForHeapSort = new int[arraySize];
            int[] inputForMergeSort = new int[arraySize];
            int[] inputForInPlaceQuickSort = new int[arraySize];
            int[] inputForModifiedQuickSort = new int[arraySize];

            Console.WriteLine("Input array size: {0}", arraySize);


            long heapsortExecTime = 0;
            for (int i = 0; i < 10; i++)
            {
                Array.Copy(input, inputForHeapSort, input.Length);
                //PrintArray(inputForHeapSort);
                Stopwatch stopwatchHeapSort = Stopwatch.StartNew();
                HeapSort.heapSort(inputForHeapSort);
                stopwatchHeapSort.Stop();
                heapsortExecTime = heapsortExecTime + stopwatchHeapSort.ElapsedMilliseconds;
                //PrintArray(inputForHeapSort); Use this method to print the sorted array
            }

            long mergesortExecTime = 0;
            for (int i = 0; i < 10; i++)
            {
                Array.Copy(input, inputForMergeSort, input.Length);
                Stopwatch stopwatchMergeSort = Stopwatch.StartNew();
                MergeSort.mergeSort(inputForMergeSort);
                stopwatchMergeSort.Stop();
                mergesortExecTime = mergesortExecTime + stopwatchMergeSort.ElapsedMilliseconds;
            }


            long quicksortExecTime = 0;
            for (int i = 0; i < 10; i++)
            {
                Array.Copy(input, inputForInPlaceQuickSort, input.Length);
                Stopwatch stopwatchQuickSort = Stopwatch.StartNew();
                InPlaceQuickSort.Sort(inputForInPlaceQuickSort);
                stopwatchQuickSort.Stop();
                quicksortExecTime = quicksortExecTime + stopwatchQuickSort.ElapsedMilliseconds;
            }


            long mQuicksortExecTime = 0;
            for (int i = 0; i < 10; i++)
            {
                Array.Copy(input, inputForModifiedQuickSort, input.Length);
                if (inputForModifiedQuickSort.Length < 15)
                {
                    Stopwatch stopwatchInsertionSort = Stopwatch.StartNew();
                    InsertionSort.Sort(inputForModifiedQuickSort);
                    stopwatchInsertionSort.Stop();
                    mQuicksortExecTime = mQuicksortExecTime + stopwatchInsertionSort.ElapsedMilliseconds;
                }
                else
                {
                    Stopwatch stopwatchMQuickSort = Stopwatch.StartNew();
                    ModifiedQuickSort.Sort(inputForModifiedQuickSort);
                    stopwatchMQuickSort.Stop();
                    mQuicksortExecTime = mQuicksortExecTime + stopwatchMQuickSort.ElapsedMilliseconds;
                }

            }

            //Console.WriteLine("Execution Time total: " + heapsortExecTime + " " + mergesortExecTime + " " + quicksortExecTime + " " + mQuicksortExecTime + " ");
            Console.WriteLine("Average Execution Time of HeapSort for 10 times: {0}", heapsortExecTime / 10.0);
            Console.WriteLine("Average Execution Time of MergeSort for 10 times: {0}", mergesortExecTime / 10.0);
            Console.WriteLine("Average Execution Time of InPlaceQuickSort for 10 times: {0}", quicksortExecTime / 10.0);
            Console.WriteLine("Average Execution Time of ModifiedQuickSort for 10 times: {0}", mQuicksortExecTime / 10.0);
        }

        //Use this method to print and see any array
        public void PrintArray(int[] input)
        {
            foreach (var t in input)
            {
                Console.Write(t + " ");
            }
        }
    }
}
