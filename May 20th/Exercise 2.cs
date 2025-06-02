using System;
using System.Linq;
class SearchComparision
{
    public static(int position, int comparisions)
        LinearSearch(int[] arr, int key)
    {
        int comparisions = 0;
        for(int i = 0; i < arr.Length; i++)
        {
            comparisions++;
            if (arr[i] == key)
            {
                return (i, comparisions);
            }
        }
        return (-1, comparisions);
    }
    public static(int positions, int comparisions)
        BinarySearch(int[] arr, int key)
    {
        int left = 0;
        int right = arr.Length - 1;
        int comparisions = 0;
        while(left <= right)
        {
            comparisions++;
            int mid = left + (right - left)  /  2;
            if (arr[mid] == key)
            {
                return (mid, comparisions);
            }
            else if (arr[mid] < key)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return (-1, comparisions);
    }
    static void Main()
    {
        Random rand = new Random();
        int[] numbers = Enumerable.Range(1, 200).OrderBy(x => rand.Next()).Take(50).OrderBy(x => x).ToArray();
        Console.WriteLine("Generated Sorted Array :");
        Console.WriteLine(string.Join(",", numbers));
        Console.WriteLine();
        int key = numbers[rand.Next(numbers.Length)];
        Console.WriteLine($"Searching for : {key}");
        var (linearPos, linearComps) = LinearSearch(numbers, key);
        var (binaryPos, binaryComps) = BinarySearch(numbers, key);

        Console.WriteLine("\nLinear Search :");
        Console.WriteLine($"Position : {linearPos}, Comparisions : {linearComps}");
        Console.WriteLine("\nBinary Search :");
        Console.WriteLine($"Position : {binaryPos}, Comparisions : {binaryComps}");

        Console.WriteLine("\nEfficiency Comparisions :");
        Console.WriteLine($"Binary search was {linearComps / binaryComps}x more efficient for this search");
        Console.WriteLine($"Binary search required {Math.Log2(numbers.Length):F1}comparisions at most (log2n)");
        Console.WriteLine($"Linear search required up to {numbers.Length} comparisions in worst case(n)");


    }

}