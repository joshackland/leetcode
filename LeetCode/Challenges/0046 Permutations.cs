using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace LeetCode.Challenges._0046Permutations;

public class Solution
{
    public List<IList<int>> output;
    public IList<IList<int>> Permute(int[] nums)
    {
        output = new List<IList<int>>();

        Permutations(nums.ToList(), new List<int>());

        return output;
    }

    public void Permutations(List<int> nums, List<int> currentPermutation)
    {
        if (nums.Count == 1)
        {
            currentPermutation.Add(nums[0]);
            output.Add(currentPermutation);
            return;
        }

        for (int i = 0; i < nums.Count; i++)
        {
            List<int> copyPermutation = new List<int>(currentPermutation);
            List<int> copyNums = new List<int>(nums);

            copyPermutation.Add(nums[i]);
            copyNums.RemoveAt(i);

            Permutations(copyNums, copyPermutation);
        }
    }
}

public static class _0046Permutations
{
    private static List<int[]> Inputs = new List<int[]>()
    {
        new int[] {1,2,3},
        new int[] {0,1},
        new int[] {1},
    };
    private static List<List<List<int>>> ExpectedOutputs = new List<List<List<int>>>()
    {
        new List<List<int>> 
        {
            new List<int> { 1,2,3 },
            new List<int> { 1,3,2 },
            new List<int> { 2,1,3 },
            new List<int> { 2,3,1 },
            new List<int> { 3,1,2 },
            new List<int> { 3,2,1 },
        },
        new List<List<int>>
        {
            new List<int> { 0,1 },
            new List<int> { 1,0 },
        },
        new List<List<int>>
        {
            new List<int> { 1 },
        },
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.Permute(input);
            Console.WriteLine($"Input: {string.Join(',',input)}, Expected Output: {DisplayOutput(expectedOutput)}, Actual Output: {DisplayOutput(actualOutput)}");
        }
    }

    private static string DisplayOutput(List<List<int>> output)
    {
        string sOutput = "\n";

        foreach(var list in output)
        {
            sOutput += string.Join(',', list) + "\n";
        }

        return sOutput;
    }

    private static string DisplayOutput(IList<IList<int>> output)
    {
        string sOutput = "\n";

        foreach (var list in output)
        {
            sOutput += string.Join(',', list) + "\n";
        }

        return sOutput;
    }
}