namespace LeetCode.Challenges.DivideTwoIntegers0029;

public class Solution
{
    public int Divide(int dividend, int divisor)
    {
        bool isPositive = dividend > 0 && divisor > 0 || dividend < 0 && divisor < 0;

        long absDividend = Math.Abs((long)dividend);
        long absDivisor = Math.Abs((long)divisor);

        if (absDivisor > absDividend) return 0;

        if (absDivisor == 1)
        {
            if (!isPositive) absDividend *= -1;

            if (absDividend < Int32.MinValue) return Int32.MinValue;
            else if (absDividend > Int32.MaxValue) return Int32.MaxValue;

            return Convert.ToInt32(absDividend);
        }

        int quotient = 0;

        while (absDivisor <= absDividend)
        {
            long tempDivisor = absDivisor;
            long multiple = 1;

            while ((tempDivisor << 1) <= absDividend)
            {
                tempDivisor <<= 1;
                multiple <<= 1;
            }

            absDividend -= tempDivisor;

            if (isPositive)
            {
                if (quotient > Int32.MaxValue - multiple) return Int32.MaxValue;
                quotient += Convert.ToInt32(multiple);
            }
            else
            {
                if (quotient < Int32.MinValue + multiple) return Int32.MinValue;
                quotient -= Convert.ToInt32(multiple);
            }
        }

        return quotient;
    }
}

public static class DivideTwoIntegers0029
{
    private static List<int> Dividends = new List<int>() {2, 10, 7 };
    private static List<int> Divisors = new List<int>() {2, 3, -3 };
    private static List<int> ExpectedOutputs= new List<int>() {1, 3, -2, };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Dividends.Count; i++)
        {
            var dividend = Dividends[i];
            var divisor = Divisors[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.Divide(dividend, divisor);
            Console.WriteLine($"Dividend: {dividend}, Divisor: {divisor}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}