using System;

namespace CommentedCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 2, 4, 6, 8, 10 }; // Initialize an array of numbers

            Console.WriteLine("Original array: ");
            foreach (int num in numbers) // Loop through each number in the array
            {
                Console.Write(num + " "); // Print the number to the console
            }

            Array.Reverse(numbers); // Reverse the order of the numbers in the array

            Console.WriteLine("\nReversed array: ");
            foreach (int num in numbers) // Loop through each number in the reversed array
            {
                Console.Write(num + " "); // Print the reversed number to the console
            }
        }
    }
}