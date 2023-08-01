namespace LeetCode.Challenges._0041FirstMissingPositive;

public class Solution
{
    public int FirstMissingPositive(int[] nums)
    {
        const int exist = 0;
        const int notexist = -1;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] < 1 || nums[i] > nums.Length) nums[i] = notexist;
        }

        for (int i = 0;i < nums.Length; i++)
        {
            if (nums[i] == notexist || nums[i] == exist) continue;

            int index = nums[i] - 1;
            nums[i] = notexist;

            while (index >= exist)
            {
                var temp = nums[index] - 1;
                nums[index] = exist;
                index = temp;
            }
        }

        for (int i= 0; i < nums.Length; i++)
        {
            if (nums[i] != exist) return i+1;
        }

        return nums.Length + 1;
    }
}

public static class _0041FirstMissingPositive
{
    private static List<int[]> Inputs = new List<int[]>()
    {
        new int[] { 1, 2, 0 },
        new int[] { 3, 4, -1, 1 },
        new int[] { 7, 8, 9, 11, 12 }
    };
    private static List<int> ExpectedOutputs = new List<int>()
    {
        3,
        2,
        1
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.FirstMissingPositive(input);
            Console.WriteLine($"Input: {string.Join(',',input)}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}