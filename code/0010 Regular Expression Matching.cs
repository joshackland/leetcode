public class Solution {
    public bool IsMatch(string s, string p) {
        int sLocation = 0;
        int pLocation = 0;

        while (sLocation <= s.Length) {
            if (pLocation == p.Length) {
                return sLocation == s.Length;
            }
            if (pLocation + 1 < p.Length && p[pLocation + 1] == '*') {
                char c = p[pLocation];
                pLocation += 2;
                while (pLocation + 1 < p.Length && c == p[pLocation] && p[pLocation+1] == '*')
                {
                    pLocation += 2;
                }
                while (sLocation < s.Length && (s[sLocation] == c || c == '.')) {
                    if (IsMatch(s.Substring(sLocation), p.Substring(pLocation))) {
                        return true;
                    }
                    sLocation++;
                }
            } else {
                if (sLocation == s.Length || (s[sLocation] != p[pLocation] && p[pLocation] != '.')) {
                    return false;
                }
                sLocation++;
                pLocation++;
            }
        }
        return false;
    }
}
