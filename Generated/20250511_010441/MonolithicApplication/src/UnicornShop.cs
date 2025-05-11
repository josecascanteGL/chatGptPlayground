using System;

public class Program
{
    public static void Main()
    {
        // Initializing an integer array with 10 elements
        int[] numbers = new int[10];
        
        // Generating random numbers and storing them in the array
        Random rand = new Random();
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = rand.Next(1, 101);
        }
        
        // Printing the original array
        Console.WriteLine("Original Array:");
        foreach (int num in numbers)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
        
        // Sorting the array in ascending order
        Array.Sort(numbers);
        
        // Printing the sorted array
        Console.WriteLine("Sorted Array:");
        foreach (int num in numbers)
        {
            Console.Write(num + " ");
        }
    }
}