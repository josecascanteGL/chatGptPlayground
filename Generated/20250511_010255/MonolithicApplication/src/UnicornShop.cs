
using System;

namespace CommentsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5 };

            Console.WriteLine("Original Array:");
            PrintArray(numbers);

            Array.Reverse(numbers); // Reverse the array in-place

            Console.WriteLine("\nReversed Array:");
            PrintArray(numbers);
        }

        // Method to print elements of an array
        static void PrintArray(int[] arr)
        {
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
        }
    }
}