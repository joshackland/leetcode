namespace LeetCode.Challenges.RemoveDuplicatesFromSortedArray0026;

public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        int total = 0;
        int currentNumber = int.MinValue;

        foreach (int x in nums)
        {
            if (currentNumber != x)
            {
                total++;
                nums[total-1] = x;
            };
            currentNumber = x;
        }

        return total;
    }
}

public static class RemoveDuplicatesFromSortedArray0026
{
    private static List<int[]> Inputs = new List<int[]>()
    { 
        new int[] {1,1,2},
        new int[] {0,0,1,1,1,2,2,3,3,4},
    };
    private static List<int> ExpectedOutputs= new List<int>() { 2,5 };

    public static void Test()
    {
        var solution = new Solution();

        foreach (var (input, expectedOutput) in Inputs.Zip(ExpectedOutputs))
        {
            var actualOutput = solution.RemoveDuplicates(input);
            Console.WriteLine($"Input: {string.Join(',',input)}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}