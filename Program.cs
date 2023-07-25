using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_15
{
    internal class Program
    {
        public static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partitioner(array, left, right);
                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }

        private static int Partitioner(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i + 1, right);
            return i + 1;
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("\n");
        }

        //Merge Sort
        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);

        }

        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];
            Array.Copy(arr, left, leftArray, 0, n1);
            Array.Copy(arr, mid + 1, rightArray, 0, n2);
            int i = 0, j = 0, k = left;

            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    arr[k] = leftArray[i];
                    i++;
                }
                else
                {
                    arr[k] = rightArray[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                arr[k] = leftArray[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = rightArray[j];
                j++;
                k++;
            }
        }


        static void Main(string[] args)
        {
            //int[] array1 = { 9, -3, 5, 2, 6, 8, -6, 1, 3 };
            int[] array1 = { 38, 27, 43, 3, 9, 82, 10 };
            int[] array2 = { 38, 27, 43, 3, 9, 82, 10 };

            //Quick Sorting
            Console.WriteLine("Quick sort Before Sorting:");
            Print(array1);

            Console.WriteLine("After Quick Sort:");
            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            QuickSort(array1);
            stopwatch1.Stop();
            Print(array1);

            Console.WriteLine($"Array {array1.Length} Time Taken for Quick Sort is {stopwatch1.Elapsed.TotalMilliseconds} milliseconds\n");
            Console.WriteLine("-----------------------------------------------");
            
            //Merge Sorting
            Console.WriteLine("Merge Sort Before Sorting: \n" + string.Join(",", array2));
            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            MergeSort(array2);
            stopwatch2.Stop();
            Console.WriteLine("\nMerge Sorted Array: \n" + string.Join(",", array2));

            Console.WriteLine($"\nArray {array1.Length} Time Taken for Merge Sort is {stopwatch2.Elapsed.TotalMilliseconds} milliseconds");

            Console.ReadKey();

        }
    }
}
