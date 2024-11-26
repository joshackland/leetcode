namespace LeetCode.Challenges._0038CountAndSay;

public class Solution
{
    public string CountAndSay(int n)
    {
        if (n == 1) return "1";

        string num = "1";

        for (int i = 2; i <= n; i++)
        {
            List<int> numbers = new List<int>();
            int currentNum = Convert.ToInt32(num.Substring(0, 1));
            numbers.Add(1);
            numbers.Add(currentNum);

            for (int j = 1; j < num.Length; j++)
            {
                currentNum = Convert.ToInt32(num.Substring(j, 1));
                int length = numbers.Count;
                if (currentNum == numbers[length - 1])
                {
                    numbers[length - 2]++;
                }
                else
                {
                    numbers.Add(1);
                    numbers.Add(currentNum);
                }
            };

            num = string.Join("", numbers);
        }

        return num;
    }
}

public static class _0038CountAndSay
{
    private static List<int> Inputs = new List<int>() 
    { 
        1,
        4
    };
    private static List<string> ExpectedOutputs= new List<string>()
    {
        "1",
        "1211"
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.CountAndSay(input);
            Console.WriteLine($"Input: {input}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}