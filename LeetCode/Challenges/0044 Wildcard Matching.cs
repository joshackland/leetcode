namespace LeetCode.Challenges._0044WildcardMatching;

public class Solution {
    public bool IsMatch(string s, string p) {
        if (p == "*") return true;

        int sLocation = 0;
        int pLocation = 0;

        int pStar = -1;
        int lastMatch = -1;


        while(sLocation < s.Length)
        {
            char sChar = s[sLocation];

            if (pLocation < p.Length && (p[pLocation] == '?' || sChar == p[pLocation]))
            {
                sLocation++;
                pLocation++;
            }
            else if (pLocation < p.Length && p[pLocation] == '*')
            {
                pStar = pLocation;
                lastMatch = sLocation;
                pLocation++;
            }
            else if (pStar == -1)
            {
                return false;
            }
            else
            {
                pLocation = pStar + 1;
                sLocation = lastMatch + 1;
                lastMatch = sLocation;
            }
        }

        while (pLocation < p.Length && p[pLocation] == '*') pLocation++;

        return pLocation == p.Length;
    }
}


public static class _0044WildcardMatching
{
    private static List<string> Ss = new List<string>()
    {
        "aa",
        "aa",
        "cb",
    };
    private static List<string> Ps = new List<string>()
    {
        "a",
        "*a",
        "?a",
    };
    private static List<bool> ExpectedOutputs = new List<bool>()
    {
        false,
        true,
        false
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Ss.Count; i++)
        {
            var s = Ss[i];
            var p = Ps[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.IsMatch(s, p);
            Console.WriteLine($"S: {s}, P: {p}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}