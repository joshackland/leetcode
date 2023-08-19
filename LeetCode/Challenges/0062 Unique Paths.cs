namespace LeetCode.Challenges._0062UniquePaths;

public class Solution
{
    public int UniquePaths(int m, int n)
    {
        int[,] grid = new int[m, n];

        for (int i = 0; i < m; i++)
        {
            grid[i, 0] = 1;
        }

        for (int i = 0; i < n; i++)
        {
            grid[0, i] = 1;
        }

        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                grid[i, j] = grid[i, j - 1] + grid[i-1, j];
            }
        }

        return grid[m-1,n-1];
    }
}

public static class _0062UniquePaths
{
    private static List<int> Ms = new List<int>() 
    { 
        3,
        3
    };
    private static List<int> Ns = new List<int>()
    {
        7,
        2
    };
    private static List<int> ExpectedOutputs= new List<int>() 
    { 
        28,
        3
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Ms.Count; i++)
        {
            var m = Ms[i];
            var n = Ns[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.UniquePaths(m, n);
            Console.WriteLine($"M: {m}, N: {n}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}