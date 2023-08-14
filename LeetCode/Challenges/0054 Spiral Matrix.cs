namespace LeetCode.Challenges._0054SpiralMatrix;

public class Solution
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        var output = new List<int>();

        int top = 0;
        int right = matrix[0].Length - 1;
        int bottom = matrix.Length - 1;
        int left = 0;

        while (top <= bottom && left <= right)
        {
            for (int i = left; i <= right; i++) 
            {
                output.Add(matrix[top][i]);
            }
            top++;

            for (int i = top; i <= bottom; i++)
            {
                output.Add(matrix[i][right]);
            }
            right--;

            if (top <= bottom)
            {
                for (int i = right; i >= left; i--)
                {
                    output.Add(matrix[bottom][i]);
                }
                bottom--;
            }

            if (left <= right)
            {
                for (int i = bottom; i >= top; i--)
                {
                    output.Add(matrix[i][left]);
                }
                left++;
            }
        }

        return output;
    }
}

public static class _0054SpiralMatrix
{
    private static List<int[][]> Inputs = new List<int[][]>() 
    { 
        new int[][]
        {
            new int[] {1, 2, 3 },
            new int[] {4, 5, 6 },
            new int[] {7, 8, 9 },
        },
        new int[][]
        {
            new int[] {1, 2, 3, 4 },
            new int[] {5, 6, 7, 8 },
            new int[] {9, 10, 11, 12 },
        }
    };
    private static List<List<int>> ExpectedOutputs= new List<List<int>>() 
    { 
        new List<int>{1, 2, 3, 6, 9, 8, 7, 4, 5},
        new List<int>{1, 2, 3, 4, 8, 12,11, 10, 9, 5, 6,7},
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.SpiralOrder(input);
            Console.WriteLine($"Expected Output: {string.Join(',', expectedOutput)}, Actual Output: {string.Join(',', actualOutput)}");
        }
    }
}