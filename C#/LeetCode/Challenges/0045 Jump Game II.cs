namespace LeetCode.Challenges._0045JumpGameII;

public class Solution
{
    public int Jump(int[] nums)
    {
        if (nums.Length <= 1 || nums[0] == 0) return 0;

        int steps = 1;
        int currentIndex = 0;
        int lastIndex = nums.Length - 1;

        while (currentIndex < lastIndex)
        {
            int currentNum = nums[currentIndex];

            if (currentIndex + currentNum >= lastIndex) return steps;

            int nextIndex = -1;
            int nextMaxJump = 0;

            for (int i = 1; i <= currentNum; i++)
            {
                if (i + nums[currentIndex + i] > nextMaxJump)
                {
                    nextIndex = i + currentIndex;
                    nextMaxJump = i + nums[currentIndex + i];
                }
            }

            if (nextIndex == -1) return 0;

            steps++;
            currentIndex = nextIndex;
        }

        return steps;
    }
}

public static class _0045JumpGameII
{
    private static List<int[]> Inputs = new List<int[]>() 
    { 
        new int[] { 2, 3, 1, 1, 4},
        new int[] { 2, 3, 0, 1, 4}
    };
    private static List<int> ExpectedOutputs= new List<int>() 
    { 
        2,
        2
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.Jump(input);
            Console.WriteLine($"Input: {string.Join(',',input)}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}