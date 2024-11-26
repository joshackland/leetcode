namespace LeetCode.Challenges._00163SumClosest;

public class Solution
{
    private int NumberDifference(int target, int current)
    {
        return Math.Abs(target - current);
    }

    public int ThreeSumClosest(int[] nums, int target)
    {        
        int output = target > 0 ? int.MinValue : int.MaxValue;

        Array.Sort(nums);

        for (int i = 0; i < nums.Length - 2; i++)
        {
            int low = i + 1;
            int high = nums.Length - 1;

            while (low < high)
            {
                int sum = nums[i] + nums[low] + nums[high];

                if (sum == target)
                {
                    return target;
                }
                else if (sum < target)
                {
                    low++;
                }
                else
                {
                    high--;
                }
                                
                if (output == int.MaxValue || output == int.MaxValue)
                {
                    output = sum;
                    continue;
                }

                int currentDifference = NumberDifference(target, output);
                int sumDifference = NumberDifference(target, sum);

                if (sumDifference < currentDifference) output = sum;
            }
        }

        return output;
    }
}

public static class _00163SumClosest
{
    private static List<int[]> Inputs = new List<int[]>()
    {
        new int[] { -1, 2, 1, -4 },
        new int[] { 0, 0, 0 },
    };
    private static List<int> Targets = new List<int>()
    {
        1,
        1
    };
    private static List<int> ExpectedOutputs = new List<int>() 
    { 
        2,
        0
    };
    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var target = Targets[i];
            var expectedOutput = ExpectedOutputs[i];

            var actualOutput = solution.ThreeSumClosest(input, target); Console.WriteLine($"Input: {input}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}