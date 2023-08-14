namespace LeetCode.Challenges._0052NQueensII;

public class Solution
{
    public int TotalNQueens(int n)
    {
        if (n == 1) 
        {
            return 1;
        }

        char[][] board = new char[n][];

        for (int i = 0; i < n; i++)
        {
            board[i] = new char[n];
            for(int j = 0; j < n; j++)
            {
                board[i][j] = '.';
            }
        }

        return SolveBoard(board, 0, 0);
    }

    private int SolveBoard(char[][]board, int row, int count)
    {
        if (row == board.Length)
        {
            var solved = new List<string>();

            foreach (var bRow in board)
            {
                solved.Add(string.Join("", bRow));
            }

            return count + 1;
        }

        for (int col = 0; col < board.Length; col++)
        {
            if (IsSafe(board, row, col))
            {
                board[row][col] = 'Q';
                count = SolveBoard(board, row + 1, count);
                board[row][col] = '.';
            }
        }

        return count;
    }

    private bool IsSafe(char[][] board, int row, int col) 
    {
        for (int i = 0; i < row; i++)
        {
            if (board[i][col] == 'Q') return false;

            int leftDiagonal = col - (row - i);
            int righttDiagonal = col + (row - i);

            if (leftDiagonal >= 0 && board[i][leftDiagonal] == 'Q') return false;
            if (righttDiagonal < board.Length && board[i][righttDiagonal] == 'Q') return false;
        }

        return true;
    }
}

public static class _0052NQueensII
{
    private static List<int> Inputs = new List<int>() 
    { 
        4,
        1
    };
    private static List<int> ExpectedOutputs = new List<int>()
    {
        2,
        1
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.TotalNQueens(input);
            Console.WriteLine($"Input: {input}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}