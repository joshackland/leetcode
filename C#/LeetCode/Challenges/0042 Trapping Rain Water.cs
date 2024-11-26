namespace LeetCode.Challenges._0042TrappingRainWater;

public class Solution
{
    public int Trap(int[] height)
    {
        int length = height.Length;
        if (length < 3) return 0;

        int[] left = new int[length];
        int[] right = new int[length];

        left[0] = height[0];
        for (int i = 1; i < length - 1; i++)
        {
            left[i] = Math.Max(height[i], left[i-1]);
        }

        right[length - 1] = height[length - 1];
        for (int i = length - 2; i > 0; i--)
        {
            right[i] = Math.Max(height[i], right[i + 1]);
        }

        int totalWater = 0;
        for(int i = 1; i <= length - 2; i++)
        {
            int smallestHeight = Math.Min(left[i], right[i]);

            if (height[i] < smallestHeight)
            {
                totalWater += smallestHeight - height[i];
            }
        }

        return totalWater;
    }
}

public static class _0042TrappingRainWater
{
    private static List<int[]> Inputs = new List<int[]>() 
    { 
        new int [] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 },
        new int [] { 4,2,0,3,2,5 },
    };
    private static List<int> ExpectedOutputs= new List<int>() 
    { 
        6,
        9
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.Trap(input);
            Console.WriteLine($"Input: {string.Join(',',input)}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}