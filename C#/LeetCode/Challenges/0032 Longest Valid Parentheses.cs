namespace LeetCode.Challenges._0032LongestValidParentheses;

public class Solution
{
    public int LongestValidParentheses(string s)
    {
        if (s.Length <= 1) return 0;

        bool[] matching = new bool[s.Length];

        Stack<int> openingIndexes = new Stack<int>();

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];

            if (c == '(')
            {
                openingIndexes.Push(i);
            }
            else
            {
                if (openingIndexes.Count != 0)
                {
                    int openingIndex = openingIndexes.Pop();
                    matching[i] = true;
                    matching[openingIndex] = true;
                }
            }
        }

        int longest = 0;
        int current = 0;
        foreach(bool match in  matching)
        {
            if (match)
            {
                current++;
                if (current > longest)
                {
                    longest = current;
                }
            }
            else
            {
                current = 0;
            }
        }

        return longest;
    }
}

public static class _0032LongestValidParentheses
{
    private static List<string> Inputs = new List<string>()
    {
        ")((()())()()((((()",
        "(()",
        ")()())",
        ""
    };
    private static List<int> ExpectedOutputs= new List<int>()
    {
        10,
        2,
        4,
        0
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.LongestValidParentheses(input);
            Console.WriteLine($"Input: {input}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}