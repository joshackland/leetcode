namespace LeetCode.Challenges.RemoveElement0027;

public class Solution
{
    public int RemoveElement(int[] nums, int val)
    {
        int total = 0;

        foreach (int x in nums)
        {
            if (x != val)
            {
                nums[total] = x;
                total++;
            };            
        }

        return total;
    }
}

public static class RemoveElement0027
{
    private static List<int[]> Inputs = new List<int[]>()
    { 
        new int[] {3,2,2,3},
        new int[] {0,1,2,2,3,0,4,2},
    };
    private static List<int> Vals = new List<int>() { 3,2 };
    private static List<int> ExpectedOutputs= new List<int>() { 2,5 };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var val = Vals[i];
            var expectedOutput = ExpectedOutputs[i];

            var actualOutput = solution.RemoveElement(input, val);
            Console.WriteLine($"Input: {string.Join(',',input)}, Val: {val}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}