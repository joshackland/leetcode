using System.Runtime.CompilerServices;

namespace LeetCode.Challenges._0048RotateImage;

public class Solution
{
    public int[][] Rotate(int[][] matrix)
    {
        int length = matrix.Length;

        for (int i = 0; i < length / 2; i++)
        {
            for (int j = i; j < length - 1 - i; j++) 
            {
                int temp = matrix[i][j];
                matrix[i][j] = matrix[length - 1 - j][i];
                matrix[length - 1 - j][i] = matrix[length - 1 - i][length - 1 - j];
                matrix[length - 1 - i][length - 1 - j] = matrix[j][length - 1 - i];
                matrix[j][length - 1 - i] = temp;
            }
        }

        return matrix;
    }
}

public static class _0048RotateImage
{
    private static List<int[][]> Inputs = new List<int[][]>() 
    { 
        new int[][]
        {
            new int [] { 1, 2, 3 },
            new int [] { 4, 5, 6 },
            new int [] { 7, 8, 9 },
        },
        new int[][]
        {
            new int [] { 5, 1, 9, 11 },
            new int [] { 2, 4, 8, 10 },
            new int [] { 13, 3, 6, 7 },
            new int [] { 15, 14, 12, 16 },
        },
    };
    private static List<int[][]> ExpectedOutputs= new List<int[][]>()
    {
        new int[][]
        {
            new int [] { 7, 4, 1 },
            new int [] { 8, 5, 2 },
            new int [] { 9, 6, 3 },
        },
        new int[][]
        {
            new int [] { 15, 13, 2, 5 },
            new int [] { 14, 3, 4, 1 },
            new int [] { 12, 6, 8, 9 },
            new int [] { 16, 7, 10, 11 },
        },
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.Rotate(input);
            Console.WriteLine($"Input: {PrintMatrix(input)}, Expected Output: {PrintMatrix(expectedOutput)}, Actual Output: {PrintMatrix(actualOutput)}");
        }
    }

    private static string PrintMatrix(int[][] matrix)
    {
        string output = "\n";

        foreach ( var row in matrix)
        {
            output += string.Join(',', row) + "\n";
        }

        return output;
    }
}