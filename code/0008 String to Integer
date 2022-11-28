public class Solution {
    public int MyAtoi(string s) {
        int output = 0;
        bool isPositive = true;
        string strOutput = "";
        bool numFound = false;
        bool symbolFound = false;
        
        s = s.TrimStart();

        if (s == "") return 0;

        foreach (char c in s){
            if ("0123456789".Contains(c)){
                strOutput += c.ToString();
                numFound = true;
                symbolFound = true;
            }
            else if("-+".Contains(c)){
                if (!symbolFound){
                    if (c == '-'){
                        strOutput += c.ToString();
                    }
                    symbolFound = true;
                }
                else if (numFound) break;
                else return 0;
            }
            else if (!numFound) return 0;
            else break;
        }
        
        if (!numFound) return 0;

        double num = Convert.ToDouble(strOutput);

        if (num > Int32.MaxValue){
            output = Int32.MaxValue;
        }
        else if (num < Int32.MinValue){
            output = Int32.MinValue;
        }
        else {
            output = Convert.ToInt32(num);
        }

        return output;
    }
}