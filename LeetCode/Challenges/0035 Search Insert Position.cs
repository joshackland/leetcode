namespace LeetCode.Challenges._0035SearchInsertPosition;

public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        int lower = 0;
        int upper = nums.Length - 1;

        if (nums[lower] >= target) return lower;
        if (nums[upper] < target) return nums.Length;
        if (nums[upper] == target) return upper;

        while (lower < upper)
        {
            if (lower == upper-1) return upper;

            int current = upper - ((upper - lower) / 2);

            if (nums[current] == target) return current;
            if (nums[current] < target) lower = current;
            if (nums[current] > target) upper = current;
        }

        return upper;
    }
}

public static class _0035SearchInsertPosition
{
    private static List<int[]> Inputs = new List<int[]>()
    {
        new int [] { 1,3,5,6 },
        new int [] { 1,3,5,6 },
        new int [] { 1,3,5,6 },
    };
    private static List<int> Targets = new List<int>()
    {
        5,
        2,
        7
    };
    private static List<int> ExpectedOutputs= new List<int>()
    {
        2,
        1,
        4
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var target = Targets[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.SearchInsert(input, target);
            Console.WriteLine($"Input: {string.Join(',',input)}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}