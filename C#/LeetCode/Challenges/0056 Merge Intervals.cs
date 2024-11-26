using System.Runtime.Serialization.Formatters;

namespace LeetCode.Challenges._0056MergeIntervals;

public class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        var output = new List<int[]>();

        var startingNums = new Dictionary<int, int>();

        for (int i = 0; i < intervals.Length; i++)
        {
            int start = intervals[i][0];
            int end = intervals[i][1];
            if (!startingNums.ContainsKey(start)) startingNums[start] = -1;

            startingNums[start] = Math.Max(startingNums[start], end);
        }

        var orderedStart = startingNums.Keys.ToList();
        orderedStart.Sort();

        for (int i = 0; i < orderedStart.Count; i++)
        {
            int start = orderedStart[i];
            int highestEnd = startingNums[start];

            var removeIndex = new List<int>();

            for (int j = i+1; j < orderedStart.Count; j++)
            {
                if (orderedStart[j] <= highestEnd)
                {
                    removeIndex.Add(j);
                    highestEnd = Math.Max(highestEnd, startingNums[orderedStart[j]]);
                }
                else break;
            }

            for (int j = removeIndex.Count - 1; j >= 0; j--)
            {
                int removeNum = orderedStart[j];
                orderedStart.RemoveAt(j);
                startingNums.Remove(removeNum);
            }

            output.Add(new int[] { start, highestEnd });
        }

        return output.ToArray();
    }
}

public static class _0056MergeIntervals
{
    private static List<int[][]> Inputs = new List<int[][]>() 
    { 
        new int[][]
        {
            new int[] { 1, 3 },
            new int[] { 2, 6 },
            new int[] { 8, 10 },
            new int[] { 15, 18 },
        },
        new int[][]
        {
            new int[] { 1, 4 },
            new int[] { 4, 5 },
        },
    };
    private static List<int[][]> ExpectedOutputs= new List<int[][]>()
    {
        new int[][]
        {
            new int[] { 1, 6 },
            new int[] { 8, 10 },
            new int[] { 15, 18 },
        },
        new int[][]
        {
            new int[] { 1, 5 },
        },
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.Merge(input);
            Console.WriteLine($"Input: {DisplayOuput(input)}, Expected Output: {DisplayOuput(expectedOutput)}, Actual Output: {DisplayOuput(actualOutput)}");
        }
    }

    private static string DisplayOuput(int[][] output)
    {
        string sOutput = "\n[";

        foreach ( var i in output )
        {
            sOutput += $"[{string.Join(',', i)}]";
        }

        sOutput += "]";
        return sOutput;
    }
}