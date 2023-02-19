namespace LeetCode.Challenges.Template0000;

public class Solution
{
    public int Template(int x)
    {
        return x + 1;
    }
}

public static class Template0000
{
    private static List<int> Inputs = new List<int>() { 1, 2, 3 };
    private static List<int> ExpectedOutputs= new List<int>() { 2, 3, 4 };

    public static void Test()
    {
        var solution = new Solution();

        foreach (var (input, expectedOutput) in Inputs.Zip(ExpectedOutputs))
        {
            var actualOutput = solution.Template(input);
            Console.WriteLine($"Input: {input}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}