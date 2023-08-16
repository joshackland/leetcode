namespace LeetCode.Challenges._0055JumpGame;

public class Solution
{
    public bool CanJump(int[] nums)
    {
        if (nums.Length <= 1) return true;
        else if (nums[0] == 0) return false;

        int steps = 1;
        int currentIndex = 0;
        int lastIndex = nums.Length - 1;

        while (currentIndex < lastIndex)
        {
            int currentNum = nums[currentIndex];

            if (currentIndex + currentNum >= lastIndex) return true;

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

            if (nextIndex == -1) return false;

            steps++;
            currentIndex = nextIndex;
        }

        return steps > 0;
    }
}

public static class _0055JumpGame
{
    private static List<int[]> Inputs = new List<int[]>() 
    { 
        new int[] { 2, 3, 1, 1, 4},
        new int[] { 3, 2, 1, 0, 4}
    };
    private static List<bool> ExpectedOutputs= new List<bool>() 
    { 
        true,
        false
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.CanJump(input);
            Console.WriteLine($"Input: {string.Join(',',input)}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}