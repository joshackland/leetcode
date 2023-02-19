namespace LeetCode.Challenges.ReverseInteger0007;

public class Solution {
    public int Reverse(int x) {     
        bool isNegative = x < 0;

        if (isNegative){
            x = x * -1;
        }

        char[] charArray = x.ToString().ToCharArray();
        Array.Reverse(charArray);
        string strReverseX = new string(charArray);

        int reverseNum = 0;
        bool isNumeric = int.TryParse(strReverseX, out reverseNum);

        if (!isNumeric) return 0;

        return isNegative ? reverseNum * -1 : reverseNum;
    }
}