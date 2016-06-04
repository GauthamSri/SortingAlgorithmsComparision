using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithmComparison
{
    class ModifiedQuickSort
    {
        public static void Sort(int[] nos)
        {
              QuickSort(nos,0,nos.Length-1);

        }

        private static void QuickSort(int[] nos, int start, int end)
        {
            if (start >= end)
                return;

            int pivotIndex = Partition(nos, start, end);
            QuickSort(nos, start, pivotIndex - 1);
            QuickSort(nos, pivotIndex + 1, end);
        }

        private static int Partition(int[] arr, int start, int end)
        {
            int pivot = MedianOfThreePivot(arr, start, end);
            end = end - 1;
            int pIndex = start;
            for (int i = start; i < end; i++)
            {
                if (arr[i] <= pivot)
                {
                    Swap(arr, i, pIndex);
                    pIndex++;
                }
            }

            Swap(arr, pIndex, end);
          
            return pIndex;
        }

        private static void Swap(int[] array, int left, int right)
        {
            int tmp = array[right];
            array[right] = array[left];
            array[left] = tmp;
        }

        private static int MedianOfThreePivot(int[] arr, int start, int end)
        {
            int mid = (start + end) / 2;

            if (arr[mid] < arr[start])
                Swap(arr, start, mid);
            if (arr[end] < arr[start])
                Swap(arr, start, end);
            if (arr[end] < arr[mid])
                Swap(arr, mid, end);
            Swap(arr, mid, end - 1);
            return arr[end - 1];
        }

    }

}
