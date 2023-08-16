namespace LeetCode.Challenges._0058LengthOfLastWord;

public class Solution
{
    public int LengthOfLastWord(string s)
    {
        int output = 0;

        int lastIndex = s.Length - 1;

        while (s[lastIndex] == ' ') lastIndex--;

        while (lastIndex >= 0 && s[lastIndex] != ' ')
        {
            output++;
            lastIndex--;
        }

        return output;
    }
}

public static class _0058LengthOfLastWord
{
    private static List<string> Inputs = new List<string>() 
    {
        "Hello World",
        "   fly me   to   the moon  ",
        "luffy is still joyboy",
    };
    private static List<int> ExpectedOutputs= new List<int>() 
    { 
        5, 
        4, 
        6
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.LengthOfLastWord(input);
            Console.WriteLine($"Input: {input}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}