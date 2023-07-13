namespace LeetCode.Challenges.GenerateParentheses0022;

public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        var output = new List<string>();
        var currentParentheses = CreateInitial(n);

        for (int i = 0; i < currentParentheses.Length; i++)
        {
            if (i < n)
            {
                currentParentheses[i] = '(';
            }
            else
            {
                currentParentheses[i] = ')';
            }
        }

        output.Add(new string(currentParentheses));

        for (int i = 0; i < n-1; i++)
        {
            currentParentheses = CreateInitial(n);
            output = MoveParentheses(currentParentheses, i, output);
        }


        return output;
    }

    private char[] CreateInitial(int n)
    {
        var currentParentheses = new char[n * 2];

        for (int i = 0; i < currentParentheses.Length; i++)
        {
            if (i < n)
            {
                currentParentheses[i] = '(';
            }
            else
            {
                currentParentheses[i] = ')';
            }
        }
        return currentParentheses;
    }

    private List<string> MoveParentheses(char[] currentParentheses, int iteration, List<string> output)
    {
        int rightIndex = int.MaxValue;

        for (int i = currentParentheses.Length -1; i > 0; i--)
        {
            if (currentParentheses[i] == '(')
            {
                rightIndex = i;
                break;
            }
        }

        char[] previousParentheses = new char[currentParentheses.Length];

        Array.Copy(currentParentheses, previousParentheses, currentParentheses.Length);

        while (rightIndex + iteration < currentParentheses.Length - 2)
        {
            Array.Copy(previousParentheses, currentParentheses, currentParentheses.Length);

            for(int i = 0; i < iteration + 1; i++)
            {
                int currentIndex = rightIndex - i;
                currentParentheses[currentIndex + 1] = '(';
                currentParentheses[currentIndex] = ')';
            }

            Array.Copy(currentParentheses, previousParentheses, currentParentheses.Length);
            output.Add(new string(currentParentheses));
            rightIndex++;

            for (int i = iteration - 1; i >=0; i--)
            {
                Array.Copy(previousParentheses, currentParentheses, currentParentheses.Length);
                output = MoveParentheses(currentParentheses, i, output);
            }
        }

        if (iteration > 0)
        {
            output = MoveParentheses(currentParentheses, iteration - 1, output);
        }

        return output;
    }
}

public static class GenerateParentheses0022
{
    private static List<int> Inputs = new List<int>() { 4, 3, 1 };
    private static List<List<string>> ExpectedOutputs = new List<List<string>>()
    {
        new List<string>
        {
        "(((())))","((()()))","((())())","((()))()","(()(()))","(()()())","(()())()","(())(())","(())()()","()((()))","()(()())","()(())()","()()(())","()()()()"
        },
        new List<string>
        {
            "((()))",
            "(()())",
            "(())()",
            "()(())",
            "()()()"
        },
        new List<string>
        {
            "()"
        },
    };

    public static void Test()
    {
        var solution = new Solution();

        foreach (var (input, expectedOutput) in Inputs.Zip(ExpectedOutputs))
        {
            var actualOutput = solution.GenerateParenthesis(input);
            Console.WriteLine($"Input: {input}, Expected Output: {string.Join(',', expectedOutput)}, Actual Output: {string.Join(',', actualOutput)}");
        }
    }
}