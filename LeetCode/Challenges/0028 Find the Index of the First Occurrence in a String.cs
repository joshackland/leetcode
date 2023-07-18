namespace LeetCode.Challenges.FindTheIndexOfTheFirstOccurrenceInAString0028
    ;

public class Solution
{
    public int StrStr(string haystack, string needle)
    {
        int needleLength = needle.Length;

        for (int i = 0; i <= haystack.Length - needleLength; i++)
        {
            if (haystack.Substring(i, needleLength) == needle) return i;
        }

        return -1;
    }
}

public static class FindTheIndexOfTheFirstOccurrenceInAString0028
{
    private static List<string> Haystacks = new List<string>() 
    { 
        "stadbutsad",
        "leetcode"
    };
    private static List<string> Needles = new List<string>()
    {
        "sad",
        "leeto"
    };
    private static List<int> ExpectedOutputs= new List<int>() { 0, -1 };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Haystacks.Count; i++) 
        {
            var haystack = Haystacks[i];
            var needle = Needles[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.StrStr(haystack, needle);
            Console.WriteLine($"Haystack: {haystack}, Needle: {needle}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}