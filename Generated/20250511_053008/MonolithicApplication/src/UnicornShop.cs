using System;

namespace CommentedCodeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 2, 4, 6, 8, 10 }; // Initialize an integer array with some values

            Console.WriteLine("Original array:");
            foreach (int num in numbers) // Loop through each element in the array and print it
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("\nReversed array:");
            Array.Reverse(numbers); // Reverse the order of elements in the array

            foreach (int num in numbers) // Loop through each element in the reversed array and print it
            {
                Console.WriteLine(num);
            }
        }
    }
}