/// <summary>
/// The Program class contains methods to convert a string by replacing each letter
/// with its preceding letter in the English alphabet, print numbers with special rules,
/// and find the index of the smallest integer in an array that balances the sum of integers
/// on its left and right sides.
/// </summary>
class Program
{
    /// <summary>
    /// The entry point of the program.
    /// </summary>
    static void Main()
    {
        // Example input string
        string input = "example";
        
        // Convert the input string and store the result
        string result = ConvertString(input);
        
        // Output the result to the console
        Console.WriteLine(result);
    }

    /// <summary>
    /// Converts each letter in the input string to its preceding letter in the English alphabet.
    /// Non-letter characters remain unchanged.
    /// </summary>
    /// <param name="input">The input string to be converted.</param>
    /// <returns>A new string with each letter replaced by its preceding letter.</returns>
    static string ConvertString(string input)
    {
        // StringBuilder to build the resulting string
        StringBuilder sb = new StringBuilder();

        // Iterate through each character in the input string
        foreach (char c in input)
        {
            // Check if the character is a letter
            if (char.IsLetter(c))
            {
                // Convert the letter to its preceding letter
                char newChar = (char)(c - 1);
                sb.Append(newChar);
            }
            else
            {
                // Append non-letter characters unchanged
                sb.Append(c);
            }
        }

        // Return the resulting string
        return sb.ToString();
    }

    /// <summary>
    /// Prints numbers from 1 to n with special rules for multiples of 3 and 5.
    /// </summary>
    /// <param name="n">The upper limit of the range to print.</param>
    static void PrintFizzBuzz(int n)
    {
        for (int i = 1; i <= n; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }

    /// <summary>
    /// Finds the index of the smallest integer in the array where the sum of the integers
    /// on its left side is equal to the sum of the integers on its right side.
    /// </summary>
    /// <param name="arr">The input integer array.</param>
    /// <returns>The index of the smallest integer that balances the array, or -1 if no such index exists.</returns>
    static int FindBalancedIndex(int[] arr)
    {
        int totalSum = 0;
        foreach (int num in arr)
        {
            totalSum += num;
        }

        int leftSum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            totalSum -= arr[i];

            if (leftSum == totalSum)
            {
                return i;
            }

            leftSum += arr[i];
        }

        return -1;
    }
}

/// <summary>
/// Prints numbers from 1 to n with special rules for multiples of 3 and 5.
/// </summary>
/// <param name="n">The upper limit of the range to print.</param>
static void PrintFizzBuzz(int n)
{
    for (int i = 1; i <= n; i++)
    {
        if (i % 3 == 0 && i % 5 == 0)
        {
            Console.WriteLine("FizzBuzz");
        }
        else if (i % 3 == 0)
        {
            Console.WriteLine("Fizz");
        }
        else if (i % 5 == 0)
        {
            Console.WriteLine("Buzz");
        }
        else
        {
            Console.WriteLine(i);
        }
    }
}

/// <summary>
/// Finds the index of the smallest integer in the array where the sum of the integers
/// on its left side is equal to the sum of the integers on its right side.
/// </summary>
/// <param name="arr">The input integer array.</param>
/// <returns>The index of the smallest integer that balances the array, or -1 if no such index exists.</returns>
static int FindBalancedIndex(int[] arr)
{
    int totalSum = 0;
    foreach (int num in arr)
    {
        totalSum += num;
    }

    int leftSum = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        totalSum -= arr[i];

        if (leftSum == totalSum)
        {
            return i;
        }

        leftSum += arr[i];
    }

    return -1;
}

/// <summary>
/// Finds the index of the smallest integer in the list where the sum of the integers
/// on its left side is equal to the sum of the integers on its right side.
/// </summary>
/// <param name="list">The input integer list.</param>
/// <returns>The index of the smallest integer that balances the list, or -1 if no such index exists.</returns>
static int FindBalancedIndex(List<int> list)
{
    int totalSum = list.Sum();
    int leftSum = 0;

    for (int i = 0; i < list.Count; i++)
    {
        totalSum -= list[i];

        if (leftSum == totalSum)
        {
            return i;
        }

        leftSum += list[i];
    }

    return -1;
}

/// <summary>
/// Finds the number of ways to group ranges into two groups such that any two ranges
/// that have at least one common integer belong to the same group.
/// </summary>
/// <param name="ranges">A list of integer ranges represented as lists of two integers.</param>
/// <returns>The number of ways to group the ranges, modulo 10^9 + 7.</returns>
static int CountWaysToGroupRanges(List<List<int>> ranges)
{
    const int MOD = 1000000007;
    int rows = ranges[0][0];
    int cols = ranges[0][1];
    ranges.RemoveAt(0);
    int n = ranges.Count;
    int[] parent = new int[n];

    // Initialize each range as its own parent
    for (int i = 0; i < n; i++)
    {
        parent[i] = i;
    }

    // Find the root of the set containing x
    int Find(int x)
    {
        if (parent[x] != x)
        {
            parent[x] = Find(parent[x]);
        }
        return parent[x];
    }

    // Union the sets containing x and y
    void Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);
        if (rootX != rootY)
        {
            parent[rootX] = rootY;
        }
    }

    // Union ranges that overlap
    for (int i = 0; i < n; i++)
    {
        for (int j = i + 1; j < n; j++)
        {
            if (ranges[i][1] >= ranges[j][0] && ranges[i][0] <= ranges[j][1])
            {
                Union(i, j);
            }
        }
    }

    // Count the number of unique groups
    HashSet<int> uniqueGroups = new HashSet<int>();
    for (int i = 0; i < n; i++)
    {
        uniqueGroups.Add(Find(i));
    }

    // Calculate the number of ways to group the ranges
    int ways = 1;
    for (int i = 0; i < uniqueGroups.Count; i++)
    {
        ways = (ways * 2) % MOD;
    }

    return ways;
static int CountWaysToGroupRanges(List<List<int>> ranges)
{
    const int MOD = 1000000007;
    ranges.RemoveAt(0); // Remove the first element which is the total number of ranges
    ranges.RemoveAt(0); // Remove the second element which is always 2
    int n = ranges.Count;
    int[] parent = new int[n];

    // Initialize each range as its own parent
    for (int i = 0; i < n; i++)
    {
        parent[i] = i;
    }

    // Find the root of the set containing x
    int Find(int x)
    {
        if (parent[x] != x)
        {
            parent[x] = Find(parent[x]);
        }
        return parent[x];
    }

    // Union the sets containing x and y
    void Union(int x, int y)
    {
        int rootX = Find(x);
        int rootY = Find(y);
        if (rootX != rootY)
        {
            parent[rootX] = rootY;
        }
    }

    // Union ranges that overlap
    for (int i = 0; i < n; i++)
    {
        for (int j = i + 1; j < n; j++)
        {
            if (ranges[i][1] >= ranges[j][0] && ranges[i][0] <= ranges[j][1])
            {
                Union(i, j);
            }
        }
    }

    // Count the number of unique groups
    HashSet<int> uniqueGroups = new HashSet<int>();
    for (int i = 0; i < n; i++)
    {
        uniqueGroups.Add(Find(i));
    }

    // Calculate the number of ways to group the ranges
    int ways = 1;
    for (int i = 0; i < uniqueGroups.Count; i++)
    {
        ways = (ways * 2) % MOD;
    }

    return ways;
}

/// <summary>
/// Generates a button with specified text and click event handler.
/// </summary>
/// <param name="text">The text to display on the button.</param>
/// <param name="clickHandler">The event handler to execute when the button is clicked.</param>
/// <returns>A Button object with the specified properties.</returns>
static Button GenerateButton(string text, EventHandler clickHandler)
{
    Button button = new Button();
    button.Text = text;
    button.Click += clickHandler;
    return button;
}
