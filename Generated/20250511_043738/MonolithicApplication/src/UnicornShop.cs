// Initialize an array of integers with some values
int[] numbers = { 2, 5, 8, 3, 9, 4 };

// Create a new List to store the numbers
List<int> evenNumbers = new List<int>();

// Loop through each number in the array
foreach (int number in numbers)
{
    // Check if the number is even by dividing it by 2 and checking the remainder
    if (number % 2 == 0)
    {
        // If the number is even, add it to the evenNumbers list
        evenNumbers.Add(number);
    }
}

// Print out the even numbers
foreach (int evenNumber in evenNumbers)
{
    Console.WriteLine(evenNumber);
}