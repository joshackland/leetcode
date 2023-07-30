namespace LeetCode.Challenges._0037SudokuSolver;

public class Solution
{
    public HashSet<char>[] rowValues;
    public HashSet<char>[] colValues;
    public HashSet<char>[] boxValues;

    public char[][] SolveSudoku(char[][] board)
    {
        rowValues = new HashSet<char>[9];
        colValues = new HashSet<char>[9];
        boxValues = new HashSet<char>[9];

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

                rowValues[row].Add(cell);
                colValues[col].Add(cell);
                boxValues[boxIndex].Add(cell);
            }
        }

        Solve(board, 0, 0);

        return board;
    }

    private bool Solve(char[][] board, int row, int col)
    {
        if (row >= 9 || row == 8 && col > 8) return true;

        char cell = board[row][col];
        while (cell != '.')
        {
            col++;
            if (col == 9)
            {
                row++;
                col = 0;
            }
            if (row >= 9 || row == 8 && col > 8) return true; 
            
            cell = board[row][col];
        }

        int boxIndex = ((row / 3) * 3) + (col / 3);

        bool isValid = false;

        for (int num = 1; num <= 9; num++)
        {
            char cNum = Convert.ToChar(num + 48);

            if (rowValues[row].Contains(cNum)
            || colValues[col].Contains(cNum)
            || boxValues[boxIndex].Contains(cNum)
            )
            {
                continue;
            }

            board[row][col] = cNum;
            rowValues[row].Add(cNum);
            colValues[col].Add(cNum);
            boxValues[boxIndex].Add(cNum);

            isValid = Solve(board, row, col);

            if (isValid)
            {
                return isValid;
            }
            else
            {
                board[row][col] = '.';
                rowValues[row].Remove(cNum);
                colValues[col].Remove(cNum);
                boxValues[boxIndex].Remove(cNum);
            }
        }

        return isValid;
    }
}

public static class _0037SudokuSolver
{
    private static List<char[][]> Boards = new List<char[][]>() 
    { 
        new char[][]
        {
            new char[]{'5','3','.','.','7','.','.','.','.'},
            new char[]{'6','.','.','1','9','5','.','.','.'},
            new char[]{'.','9','8','.','.','.','.','6','.'},
            new char[]{'8','.','.','.','6','.','.','.','3'},
            new char[]{'4','.','.','8','.','3','.','.','1'},
            new char[]{'7','.','.','.','2','.','.','.','6'},
            new char[]{'.','6','.','.','.','.','2','8','.'},
            new char[]{'.','.','.','4','1','9','.','.','5'},
            new char[]{'.','.','.','.','8','.','.','7','.' }
        },
    };
    private static List<char[][]> ExpectedOutputs = new List<char[][]>()
    {
        new char[][]
        {
            new char[]{'5','3','4','6','7','8','9','1','2'},
            new char[]{'6','7','2','1','9','5','3','4','8'},
            new char[]{'1','9','8','3','4','2','5','6','7'},
            new char[]{'8','5','9','7','6','1','4','2','3'},
            new char[]{'4','2','6','8','5','3','7','9','1'},
            new char[]{'7','1','3','9','2','4','8','5','6'},
            new char[]{'9','6','1','5','3','7','2','8','4'},
            new char[]{'2','8','7','4','1','9','6','3','5'},
            new char[]{'3','4','5','2','8','6','1','7','9' }
        }
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Boards.Count; i++)
        {
            var board = Boards[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.SolveSudoku(board);
            Console.WriteLine($"Board: {OutputBoard(board)}, Expected Output: {OutputBoard(expectedOutput)}, Actual Output: {OutputBoard(actualOutput)}");
        }
    }

    private static string OutputBoard(char[][] board)
    {
        string output = "\n";

        foreach (char[] row in board)
        {
            output += $"|{string.Join('|', row)}|\n";
        }

        return output;
    }
}