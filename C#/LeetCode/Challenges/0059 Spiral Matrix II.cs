using System.Data;

namespace LeetCode.Challenges._0059SpiralMatrixII;

public class Solution
{
    public int[][] GenerateMatrix(int n)
    {
        var output = new int[n][];

        for (int i = 0; i < n; i++)
        {
            output[i] = new int[n];
        }

        int top = 0;
        int right = output[0].Length - 1;
        int bottom = output.Length - 1;
        int left = 0;

        int num = 1;

        while (top <= bottom && left <= right)
        {
            for (int i = left; i <= right; i++)
            {
                output[top][i] = num++;
            }
            top++;

            for (int i = top; i <= bottom; i++)
            {
                output[i][right] = num++;
            }
            right--;

            if (top <= bottom)
            {
                for (int i = right; i >= left; i--)
                {
                    output[bottom][i] = num++;
                }
                bottom--;
            }

            if (left <= right)
            {
                for (int i = bottom; i >= top; i--)
                {
                    output[i][left] = num++;
                }
                left++;
            }
        }

        return output;
    }
}

public static class _0059SpiralMatrixII
{
    private static List<int> Inputs = new List<int>()
    {
        3,
        1
    };
    private static List<int[][]> ExpectedOutputs = new List<int[][]>()
    {
        new int[][]
        {
            new int[] {1, 2, 3 },
            new int[] {8, 9, 4 },
            new int[] {7, 6, 5 },
        },
        new int[][]
        {
            new int[] {1 },
        }
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.GenerateMatrix(input);
            Console.WriteLine($"Input: {input}, Expected Output: {DisplayOutput(expectedOutput)}, Actual Output: {DisplayOutput(actualOutput)}");
        }
    }

    private static string DisplayOutput(int[][] matrix)
    {
        string output = "\n";

        foreach (var row in matrix)
        {
            output += string.Join(',', row) + "\n";
        }

        return output;
    }
}