using System;

public class Program
{
    public static void Main()
    {
        int[] numbers = { 2, 4, 6, 8, 10 };
        int target = 6;

        bool found = false; // Initialize a flag to keep track of whether the target element is found

        foreach (int num in numbers) // Loop through each element in the numbers array
        {
            if (num == target) // Check if the current element is equal to the target
            {
                found = true; // Update the flag to indicate that the target element is found
                break; // Exit the loop since the target element is found
            }
        }

        if (found) // Check if the target element was found
        {
            Console.WriteLine("Target element found in the array."); // Print a message indicating that the target element was found
        }
        else
        {
            Console.WriteLine("Target element not found in the array."); // Print a message indicating that the target element was not found
        }
    }
}