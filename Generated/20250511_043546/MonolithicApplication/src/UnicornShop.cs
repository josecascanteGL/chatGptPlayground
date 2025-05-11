```c#
using System;

class Program
{
    static void Main()
    {
        int[] numbers = { 2, 4, 6, 8, 10 };
        int target = 8;
        int result = BinarySearch(numbers, target);
        Console.WriteLine("Index of target number: " + result);
    }

    static int BinarySearch(int[] array, int target)
    {
        int min = 0;
        int max = array.Length - 1;

        while (min <= max)
        {
            int mid = (min + max) / 2;
            int guess = array[mid];

            if (guess == target)
            {
                return mid;
            }
            else if (guess < target)
            {
                min = mid + 1;
            }
            else
            {
                max = mid - 1;
            }
        }

        return -1; // Target not found in array
    }
}
```

```c#
// This program demonstrates the binary search algorithm to find a target number in a sorted array.
// The Main method initializes an array of numbers and a target value, then calls the BinarySearch method.
// The BinarySearch method takes an array and a target value as input and returns the index of the target value in the array.

// Initialize an array of numbers and a target value
int[] numbers = { 2, 4, 6, 8, 10 };
int target = 8;

// Call the BinarySearch method to find the index of the target value in the array
int result = BinarySearch(numbers, target);
Console.WriteLine("Index of target number: " + result);

// BinarySearch method that implements the binary search algorithm
int BinarySearch(int[] array, int target)
{
    // Initialize min and max indices for the search range
    int min = 0;
    int max = array.Length - 1;

    // Continue searching until the min index is less than or equal to the max index
    while (min <= max)
    {
        // Calculate the middle index of the search range
        int mid = (min + max) / 2;
        int guess = array[mid]; // Get the value at the middle index

        // Check if the middle value is equal to the target value
        if (guess == target)
        {
            return mid; // Return the index of the target value
        }
        // If the middle value is less than the target value, adjust the search range to the right half
        else if (guess < target)
        {
            min = mid + 1;
        }
        // If the middle value is greater than the target value, adjust the search range to the left half
        else
        {
            max = mid - 1;
        }
    }

    return -1; // Return -1 if the target value is not found in the array
}
```