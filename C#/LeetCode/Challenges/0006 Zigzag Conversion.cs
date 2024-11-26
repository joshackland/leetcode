namespace LeetCode.Challenges._0006ZigzacConversions;

public class Solution {
    public string Convert(string s, int numRows) {
        string[] rows = new string[numRows];

        int row = 0;
        bool directionDown = true;

        foreach (char c in s){
            rows[row] += c.ToString();

            if (numRows > 1){
                directionDown = row == 0 ? true : row == numRows - 1 ? false : directionDown;

                row = directionDown ? row + 1 : row - 1;
            }
        }

        string output = "";

        foreach (string sRow in rows){
            output += sRow;
        }

        return output;
    }
}