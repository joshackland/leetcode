using System.Dynamic;

namespace LeetCode.Challenges._0053MaximumSubarray;

public class Solution
{
    public int MaxSubArray(int[] nums)
    {
        int max = nums[0];
        int currentMax = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            currentMax = Math.Max(nums[i], currentMax + nums[i]);
            max = Math.Max(max, currentMax);
        }        

        return max;
    }
}

public static class _0053MaximumSubarray
{
    private static List<int[]> Inputs = new List<int[]>()
    {
        new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4},
        new int[] { 1 },
        new int[] { 5, 4, -1, 7, 8},
        new int[] { 1,2,-1,-2,2,1,-2,1,4,-5,4 },
        new int[] { 2,0,-3,2,1,0,1,-2 }
    };
    private static List<int> ExpectedOutputs= new List<int>() 
    { 
        6,
        1, 
        23,
        6,
        4
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.MaxSubArray(input);
            Console.WriteLine($"Input: {string.Join(',', input)}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}