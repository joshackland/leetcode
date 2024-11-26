namespace LeetCode.Challenges._0057InsertInterval;

public class Solution
{
    public int[][] Insert(int[][] intervals, int[] newInterval)
    {
        if (intervals.Length == 0) return new int[][] { newInterval };

        var output = new List<int[]>();

        int low = int.MaxValue;
        int high = int.MinValue;
        bool added = false;

        for (int i = 0; i < intervals.Length; i++)
        {
            if (intervals[i][1] < newInterval[0])
            {
                output.Add(intervals[i]);

                if (i + 1 == intervals.Length && !added) output.Add(newInterval);
                continue;
            }
            else if (intervals[i][0] > newInterval[1])
            {
                if (!added)
                {
                    if (low < int.MaxValue)
                    {
                        output.Add(new int[] {low, high});
                    }
                    else
                    {
                        output.Add(newInterval);
                    }
                    added = true;
                }

                output.Add(intervals[i]);
                continue;
            }

            if (low == int.MaxValue) low = Math.Min(newInterval[0], intervals[i][0]);

            high = Math.Max(newInterval[1], intervals[i][1]);

            if (i + 1 == intervals.Length) output.Add(new int[] { low, high });
        }

        return output.ToArray();
    }
}

public static class _0057InsertInterval
{
    private static List<int[][]> Inputs = new List<int[][]>()
    {
        new int[][]
        {
            new int[] { 1, 3 },
            new int[] { 6, 9 },
        },
        new int[][]
        {
            new int[] { 1, 2 },
            new int[] { 3, 5 },
            new int[] { 6, 7 },
            new int[] { 8, 10 },
            new int[] { 12, 16 },
        },
    };
    private static List<int[]> Intervals = new List<int[]>
    {
        new int[]{ 2, 5 },
        new int[]{ 4, 8 },
    };
    private static List<int[][]> ExpectedOutputs = new List<int[][]>()
    {
        new int[][]
        {
            new int[] { 1, 5 },
            new int[] { 6, 9 },
        },
        new int[][]
        {
            new int[] { 1, 2 },
            new int[] { 3, 10 },
            new int[] { 12, 16 },
        },
    };
    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var interval = Intervals[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.Insert(input, interval);
            Console.WriteLine($"Input: {DisplayOuput(input)}, Expected Output: {DisplayOuput(expectedOutput)}, Actual Output: {DisplayOuput(actualOutput)}");
        }
    }

    private static string DisplayOuput(int[][] output)
    {
        string sOutput = "\n[";

        foreach (var i in output)
        {
            sOutput += $"[{string.Join(',', i)}]";
        }

        sOutput += "]";
        return sOutput;
    }
}