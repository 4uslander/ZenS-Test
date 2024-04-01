using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Read the input numbers and convert them to an array of integers.
        int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        // Calculate the sum of all numbers.
        long totalSum = arr.Sum(item => (long)item);

        // Calculate the minimum and maximum sums by excluding one number at a time.
        long minSum = totalSum - arr.Max();
        long maxSum = totalSum - arr.Min();

        // Print the results.
        Console.WriteLine($"{minSum} {maxSum}");
    }
}
