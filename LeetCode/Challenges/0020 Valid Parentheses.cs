namespace LeetCode.Challenges._0020ValidParentheses;

public class Solution
{
    public bool IsValid(string s)
    {
        Stack<char> openingParentheses = new Stack<char>();

        foreach (char c in s)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                openingParentheses.Push(c);
            }
            else
            {
                if (openingParentheses.Count == 0) return false;
                var opening = openingParentheses.Pop();

                if (opening == '(' && c != ')'
                    || opening == '{' && c != '}'
                    || opening == '[' && c != ']') return false;
            }
        }

        if (openingParentheses.Count > 0) return false;

        return true;
    }
}

public static class _0020ValidParentheses
{
    private static List<string> Inputs = new List<string>() { "()", "()[]{}", "(]" };
    private static List<bool> ExpectedOutputs = new List<bool>() { true, true, false };
    public static void Test()
    {
        var solution = new Solution();

        foreach (var (input, expectedOutput) in Inputs.Zip(ExpectedOutputs))
        {
            var actualOutput = solution.IsValid(input);
            Console.WriteLine($"Input: {input}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}