namespace LeetCode.Challenges._0005LongestPalindrome;

public class Solution {
    public string LongestPalindrome(string s) {
        string LongestPalindrome = s[0].ToString();

        for (int i = 0; i < s.Length - 1; i++){
            if (s.Length - i < LongestPalindrome.Length) break;
            string currentString = s[i].ToString();

            for (int j = i+1; j < s.Length; j++){
                currentString += s[j].ToString();
                if (currentString.Length <= LongestPalindrome.Length) continue;

                int currentStringLength = currentString.Length;
                
                bool palindrome = true;
                for (int index = 0; index < currentString.Length / 2; index++){
                    if (currentString[index] != currentString[currentString.Length-1-index]){
                        palindrome = false;
                        break;
                    }
                }
                if (palindrome) LongestPalindrome = currentString;
            }
        }

        return LongestPalindrome;
    }
}