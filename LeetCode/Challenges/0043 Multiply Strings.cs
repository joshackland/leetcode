namespace LeetCode.Challenges._0043MultiplyStrings;

public class Solution
{
    public string Multiply(string num1, string num2)
    {
        if (num1 == "0" || num2 == "0") return "0";

        //this should be a string
        //then you use index in string to then do math
        //this will reduce memory usage
        var number = new List<int>();

        for (int i = num1.Length - 1; i >= 0; i--) 
        { 
            int n1 = Convert.ToInt32(num1.Substring(i, 1));
            int n1Position = num1.Length - 1 - i;

            for (int j = num2.Length - 1; j >= 0; j--)
            {
                int n2 = Convert.ToInt32(num2.Substring(j, 1));
                int n2Position = num2.Length - 1 - j;

                int product = n1 * n2;
                int position = n1Position + n2Position;

                while (number.Count - 1 < position)
                {
                    number.Add(0);
                }

                number[position] += product;

                while (number[position] >= 10)
                {
                    number[position] -= 10;

                    if (number.Count <= position + 1)
                    {
                        number.Add(0);
                    }

                    number[position + 1]++;
                }
            }
        }

        string output = string.Empty;

        for (int i = number.Count - 1; i >= 0; i--)
        {
            output += number[i].ToString();
        }

        return output;
    }
}

public static class _0043MultiplyStrings
{
    private static List<string> Num1s = new List<string>() 
    { 
        "2",
        "123",
    };
    private static List<string> Num2s = new List<string>() 
    { 
        "3",
        "456",
    };
    private static List<string> ExpectedOutputs= new List<string>() 
    { 
        "6",
        "56088",
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Num1s.Count; i++)
        {
            var num1 = Num1s[i];
            var num2 = Num2s[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.Multiply(num1, num2);
            Console.WriteLine($"Num1: {num1}, Num2: {num1}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}