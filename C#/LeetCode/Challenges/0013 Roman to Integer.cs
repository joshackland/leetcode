namespace LeetCode.Challenges._0013RomanToInteger;

public class Solution
{
    public int RomanToInt(string s)
    {
        int number = 0;

        for (int i = 0; i < s.Length; i++)
        {
            string currentCharacter = s[i].ToString();

            if (currentCharacter == "M")
            {
                number += 1000;
            }
            else if (currentCharacter == "D") 
            {
                number += 500;
            }
            else if (currentCharacter == "C")
            {
                string nextCharacter = NextCharacter(i, s);

                if (nextCharacter == "M")
                {
                    number += 900;
                    i++;
                }
                else if (nextCharacter == "D")
                {
                    number += 400;
                    i++;
                }
                else
                {
                    number += 100;
                }

            }
            else if (currentCharacter == "L")
            {
                number += 50;
            }
            else if (currentCharacter == "X")
            {
                string nextCharacter = NextCharacter(i, s);

                if (nextCharacter == "C")
                {
                    number += 90;
                    i++;
                }
                else if (nextCharacter == "L")
                {
                    number += 40;
                    i++;
                }
                else
                {
                    number += 10;
                }
            }
            else if (currentCharacter == "V")
            {
                number += 5;
            }
            else if (currentCharacter == "I")
            {
                string nextCharacter = NextCharacter(i, s);

                if (nextCharacter == "X")
                {
                    number += 9;
                    i++;
                }
                else if (nextCharacter == "V")
                {
                    number += 4;
                    i++;
                }
                else
                {
                    number += 1;
                }
            }
        }
        return number;
    }

    private string NextCharacter(int index, string s)
    {
        index++;

        if (index >= s.Length) return string.Empty;

        return s[index].ToString();
    }
}

public static class _0013RomanToInteger
{
    private static List<string> Inputs = new List<string>() { "III", "LVIII", "MCMXCIV" };
    private static List<int> ExpectedOutputs= new List<int>() { 3, 58, 1994 };

    public static void Test()
    {
        var solution = new Solution();

        foreach (var (input, expectedOutput) in Inputs.Zip(ExpectedOutputs))
        {
            var actualOutput = solution.RomanToInt(input);
            Console.WriteLine($"Input: {input}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}