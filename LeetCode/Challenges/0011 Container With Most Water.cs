namespace LeetCode.Challenges.ContainerWithMostWater0011;

public class Solution
{
    public int MaxArea(int[] height)
    {
        int area = 0;
        for (int i = 0; i < height.Length -1; i++) 
        {
            if (height[i] * height.Length - i < area) continue;

            for (int j = i+1; j < height.Length; j++)
            {
                int smallest = height[i] < height[j] ? height[i] : height[j];
                int distance = j - i;
                int currentArea = smallest * distance;

                if (currentArea > area) 
                { 
                    area = currentArea;
                }
            }    
        }
        return area;
    }
}

public static class ContainerWithMostWater0011
{
    private static List<int[]> Inputs = new List<int[]>() { new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 } } ;
    private static List<int> ExpectedOutputs = new List<int>() { 49 };

    public static void Test()
    {
        var solution = new Solution();

        foreach (var (input, expectedOutput) in Inputs.Zip(ExpectedOutputs))
        {
            var actualOutput = solution.MaxArea(input);
            Console.WriteLine($"Input: {input}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}