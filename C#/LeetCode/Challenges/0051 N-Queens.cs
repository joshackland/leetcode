namespace LeetCode.Challenges._0051NQueens;

public class Solution
{
    public IList<IList<string>> SolveNQueens(int n)
    {
        var output = new List<IList<string>>();
        if (n == 1) 
        {
            output.Add(new List<string>() { "Q" });
            return output;
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

        SolveBoard(board, output, 0);

        return output;
    }

    private void SolveBoard(char[][]board, List<IList<string>> output, int row)
    {
        if (row == board.Length)
        {
            var solved = new List<string>();

            foreach (var bRow in board)
            {
                solved.Add(string.Join("", bRow));
            }
            output.Add(solved);
            return;
        }

        for (int col = 0; col < board.Length; col++)
        {
            if (IsSafe(board, row, col))
            {
                board[row][col] = 'Q';
                SolveBoard(board, output, row + 1);
                board[row][col] = '.';
            }
        }
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

public static class _0051NQueens
{
    private static List<int> Inputs = new List<int>() 
    { 
        4,
        1
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var actualOutput = solution.SolveNQueens(input);
            Console.WriteLine($"Input: {input}, Output: {DisplayOutput(actualOutput)}");
        }
    }

    private static string DisplayOutput(IList<IList<string>> input)
    {
        string output = "\n";

        foreach (var item in input)
        {
            output += string.Join(',',item) + "\n";
        }

        return output;
    }
}