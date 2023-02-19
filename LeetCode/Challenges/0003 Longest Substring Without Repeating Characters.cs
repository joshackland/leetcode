namespace LeetCode.Challenges.LongestSubstringWithoutRepeatingCharacters0003;
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int count = 0;
        
        int currentCount = 0;
        var currentLetters = new List<char>();
        int startingIndex = 0;

        for (int i = 0; i < s.Length; i++){
            if (currentCount == 0){
                startingIndex = i+1;
            }
            if (currentLetters.Contains(s[i])){
                if (count < currentCount){
                    count = currentCount;
                }
                currentLetters = new List<char>();
                i = startingIndex-1;
                currentCount = 0;
            }
            else {
                currentCount++;
                currentLetters.Add(s[i]);
            }
        }

        if (count < currentCount){
            return currentCount;
        }

        return count;
    }
}