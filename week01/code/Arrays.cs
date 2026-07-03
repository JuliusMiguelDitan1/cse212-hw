public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Create a double array that can hold the number of multiples requested.
        // The size of the array should be equal to length.
        double[] multiples = new double[length];

        // Step 2: Use a loop to go through each index of the array.
        // The loop starts at 0 and continues until it reaches count - 1.
        for (int i = 0; i < length; i++)
        {
            // Step 3: Calculate the multiple.
            // Since array indexes start at 0, use i + 1 to get the correct multiplier.
            multiples[i] = number * (i + 1);
        }

        // Step 4: Return the completed array of multiples.
        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Create the starting index, this ensure that it starts at the right index.
        int startIndex = data.Count - amount;
        // Step 2: Set the list to store the rotated list of numbers.
        List<int> rotatedItems = new List<int>();
        //Step 3: This place the last values of the list into the back.
        for (int i=startIndex; i<data.Count; i++)
        {
            rotatedItems.Add(data[i]);
        }
        //Step 4: Continues adding numbers to the list from 
        for (int i=0; i<startIndex; i++)
        {
            rotatedItems.Add(data[i]);
        }
        // Step 5: Clear the original list because the function does not return a new list.
        data.Clear();

        // Step 6: Copy the rotated values back into the original list.
        for (int i = 0; i < rotatedItems.Count; i++)
        {
            data.Add(rotatedItems[i]);
        }
    }
}
