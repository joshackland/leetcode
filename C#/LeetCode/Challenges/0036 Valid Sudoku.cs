namespace LeetCode.Challenges._0036ValidSudoku;

public class Solution
{
    public bool IsValidSudoku(char[][] board)
    {
        var rowValues = new HashSet<char>[9];
        var colValues = new HashSet<char>[9];
        var boxValues = new HashSet<char>[9];

        for (int i = 0; i < 9; i++)
        {
            rowValues[i] = new HashSet<char>();
            colValues[i] = new HashSet<char>();
            boxValues[i] = new HashSet<char>();
        }

        for (int row = 0; row < board.Length; row++)
        {
            for (int col = 0; col < board[row].Length; col++)
            {
                char cell = board[row][col];

                if (cell == '.') continue;

                int boxIndex = ((row / 3) * 3) + (col / 3);

                if (rowValues[row].Contains(cell)
                    || colValues[col].Contains(cell)
                    || boxValues[boxIndex].Contains(cell)
                   )
                {
                    return false;
                }

                rowValues[row].Add(cell);
                colValues[col].Add(cell);
                boxValues[boxIndex].Add(cell);
            }
        }

        return true;
    }
}

public static class _0036ValidSudoku
{
    private static List<char[][]> Boards = new List<char[][]>() 
    { 
        new char[][]
        {
            new char[]{'5','3','.','.','7','.','.','.','.' },
            new char[]{'6','.','.','1','9','5','.','.','.'},
            new char[]{'.','9','8','.','.','.','.','6','.'},
            new char[]{'8','.','.','.','6','.','.','.','3'},
            new char[]{'4','.','.','8','.','3','.','.','1'},
            new char[]{'7','.','.','.','2','.','.','.','6'},
            new char[]{'.','6','.','.','.','.','2','8','.'},
            new char[]{'.','.','.','4','1','9','.','.','5'},
            new char[]{'.','.','.','.','8','.','.','7','9'}
        },

        new char[][]
        {
            new char[]{'8','3','.','.','7','.','.','.','.'},
            new char[]{'6','.','.','1','9','5','.','.','.'},
            new char[]{'.','9','8','.','.','.','.','6','.'},
            new char[]{'8','.','.','.','6','.','.','.','3'},
            new char[]{'4','.','.','8','.','3','.','.','1'},
            new char[]{'7','.','.','.','2','.','.','.','6'},
            new char[]{'.','6','.','.','.','.','2','8','.'},
            new char[]{'.','.','.','4','1','9','.','.','5'},
            new char[]{'.','.','.','.','8','.','.','7','9'}
        }
    };
    private static List<bool> ExpectedOutputs = new List<bool>() 
    { 
        true,
        false
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Boards.Count; i++)
        {
            var board = Boards[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.IsValidSudoku(board);
            Console.WriteLine($"Board: {board}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}