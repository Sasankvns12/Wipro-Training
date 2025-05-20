using System;
using System.Diagnostics;
class SortingAlgorithms
{
    public static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
    public static void SelectionSort(int[] arr)
    {
        int n = arr.Length;
        for(int i = 0; i < n-1; i++)
        {
            int minIndex = i;
            for(int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }
            int temp = arr[minIndex];
            arr[minIndex] = arr[i];
            arr[i] = temp;
        }
    }
    public static void InsertionSort(int[] arr)
    {
        int n = arr.Length;
        for(int i = 1; i < n; ++i)
        {
            int key = arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j = j - 1;
            }
            arr[j + 1] = key;
        }
    }
    public static void PrintArray(int[] arr)
    {
        foreach(var num in arr)
        {
            Console.WriteLine(num + " ");
        }
        Console.WriteLine();
    }
    public static int[] GenerateRandomArray(int size, int min, int max)
    {
        Random random = new Random();
        int[] arr = new int[size];
        for(int i = 0; i < size; i++)
        {
            arr[i] = random.Next(min, max + 1);
        }
        return arr;
    }
    static void Main()
    {
        int[] OriginalArray = GenerateRandomArray(20, 1, 100);
        Console.WriteLine("Original Array :");
        PrintArray(OriginalArray);
        Console.WriteLine();
        
        int[] bubbleArray = (int[])OriginalArray.Clone();
        Stopwatch bubbleWatch = Stopwatch.StartNew();
        BubbleSort(bubbleArray);
        bubbleWatch.Stop();
        Console.WriteLine("Bubble Sort :");
        PrintArray(bubbleArray);
        Console.WriteLine($"Time taken : {bubbleWatch.ElapsedTicks} ticks\n");

        int[] SelectionArray = (int[])OriginalArray.Clone();
        Stopwatch selectionWatch = Stopwatch.StartNew();
        SelectionSort(SelectionArray);
        selectionWatch.Stop();
        Console.WriteLine("Selection Sort :");
        PrintArray(SelectionArray);
        Console.WriteLine($"Time taken : {selectionWatch.ElapsedTicks} ticks\n");

        int[] InsertionArray = (int[])OriginalArray.Clone();
        Stopwatch insertionWatch = Stopwatch.StartNew();
        InsertionSort(InsertionArray);
        insertionWatch.Stop();
        Console.WriteLine("Insertion Sort :");
        PrintArray(InsertionArray);
        Console.WriteLine($"Time taken : {insertionWatch.ElapsedTicks} ticks\n");

        Console.WriteLine("Time Complexity Analysis :");
        Console.WriteLine("Bubble Sort : O(n^2) - Worst and Average Cases");
        Console.WriteLine("Selection Sort : O(n^2) - All Cases");
        Console.WriteLine("Insertion Sort : O(n^2) - Worst and Average case, O(n) - Best case (already sorted)");

    }
}