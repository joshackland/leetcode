public class Solution {
    public bool IsPalindrome(int x) {
        if (x < 0) return false;

        string strX = x.ToString();

        for (int i = 0; i < strX.Length / 2; i++){
            if (strX[i] != strX[strX.Length -1 - i]) return false;
        }

        return true;
    }
}