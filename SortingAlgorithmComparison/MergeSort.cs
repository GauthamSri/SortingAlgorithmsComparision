using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithmComparison
{
    class MergeSort
    {
        public static void mergeSort(int[] nos)
        {
            int arrayLength = nos.Length;

            if (arrayLength < 2)
                return;
            int mid = arrayLength / 2;

            int[] left = new int[mid];
            int[] right = new int[arrayLength - mid];

            if (mid == 1)
                left[0] = nos[0];

            for (int i = 0; i < mid; i++)
            {
                left[i] = nos[i];
            }

            for (int i = mid; i < arrayLength; i++)
            {
                right[i - mid] = nos[i];
            }

            mergeSort(left);
            mergeSort(right);
            Merge(left, right, nos);

        }

        private static void Merge(int[] left, int[] right, int[] nos)
        {
            int leftLen = left.Length, rightLen = right.Length;
            int i = 0, j = 0, k = 0;

            while (i < leftLen && j < rightLen)
            {
                if (left[i] < right[j])
                {
                    nos[k] = left[i];
                    i++;
                }
                else
                {
                    nos[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < leftLen)
            {
                nos[k] = left[i];
                i++;
                k++;
            }

            while (j < rightLen)
            {
                nos[k] = right[j];
                j++;
                k++;
            }
        }
    }
}
