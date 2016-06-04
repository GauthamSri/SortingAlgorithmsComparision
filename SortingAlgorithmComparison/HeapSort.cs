using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithmComparison
{
    class HeapSort
    {
        public static void heapSort(int[] nos)
        {
            int arrayLength = nos.Length, temp;

            for (int i = arrayLength / 2 - 1; i >= 0; i--)
            {
                ReOrder(nos, i, arrayLength - 1);
            }

            for (int i = arrayLength - 1; i > 0; i--)
            {
                temp = nos[0];
                nos[0] = nos[i];
                nos[i] = temp;
                ReOrder(nos, 0, i - 1);
            }

        }

        private static void ReOrder(int[] array, int root, int bottom)
        {
            int tracker, maxChild, temp;
            tracker = 0;
            while ((root * 2 <= bottom) && (tracker == 0))
            {
                if (root * 2 == bottom)
                    maxChild = root * 2;
                else if (array[root * 2] > array[root * 2 + 1])
                    maxChild = root * 2;
                else
                    maxChild = root * 2 + 1;
                if (array[root] < array[maxChild])
                {
                    temp = array[root];
                    array[root] = array[maxChild];
                    array[maxChild] = temp;
                    root = maxChild;
                }
                else
                    tracker = 1;
            }

        }
    }
}
