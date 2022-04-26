using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickSort
{
    public class QuickSortSingleThread
    {
        public static async void SerialQuicksort(long[] elements, long left, long right)
        {
            long i = left, j = right;
            var pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0) i++;
                while (elements[j].CompareTo(pivot) > 0) j--;

                if (i <= j)
                {
                    // Swap
                    var tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            List<Task> tasks = new List<Task>();
            // Recursive calls
            if (left < j)
            {
                //Console.WriteLine($"{j-left}");
                if (j - left > 1000)
                {
                    tasks.Add(Task.Run(() => SerialQuicksort(elements, left, j)));

                }
                else
                    SerialQuicksort(elements, left, j);

            }

            if (i < right)
            {
                if (right - i > 1000)
                {
                    tasks.Add(Task.Run(() => SerialQuicksort(elements, i, right)));

                }
                else
                    SerialQuicksort(elements, i, right);
            }

            Task.WaitAll(tasks.ToArray());

        }
    }
}
