// Initialize an array of integers with some values
int[] numbers = { 2, 4, 6, 8, 10 };

// Initialize a variable to hold the sum of the numbers in the array
int sum = 0;

// Loop through each element in the array
for (int i = 0; i < numbers.Length; i++)
{
    // Add the current element to the sum
    sum += numbers[i];
}

// Display the sum of all the numbers in the array
Console.WriteLine("The sum of the numbers is: " + sum);