using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace LeetCode.Challenges._0031NextPermutation;

public class Solution
{
    public void NextPermutation(int[] nums)
    {
        if (nums.Length == 1)
        {
            Console.WriteLine($"LENGTH ONE OUTPUT: {string.Join(',', nums)}");
            return;
        }

        Dictionary<int,int> numbers = new Dictionary<int,int>();

        foreach(int num in nums)
        {
            if (!numbers.ContainsKey(num)) numbers[num] = 0;
            numbers[num]++;
        }

        if (numbers.Count <= 1)
        {
            Console.WriteLine($"ONE NUMBER OUTPUT: {string.Join(',', nums)}");
            return;
        }

        var greatestPermutation = GetGreatestPermutation(numbers);

        bool isGreatest = true;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != greatestPermutation[i])
            {
                isGreatest = false;
                break;
            }
        }

        if (isGreatest)
        {
            nums = GetLowestPermutation(numbers, nums);
            Console.WriteLine($"HIGHEST -> LOWEST OUTPUT: {string.Join(',', nums)}");
            return;
        }

        nums = IncrementPermutation(nums);

        Console.WriteLine($"OUTPUT: {string.Join(',',nums)}");
    }
    private int[] IncrementPermutation(int[] nums)
    {
        int swapIndex = -1;
        for (int i = nums.Length - 1; i > 0; i--)
        {
            bool currentLower = nums[i - 1] < nums[i];

            if (currentLower)
            {
                swapIndex = i - 1;
                break;
            }
        }

        int temp = nums[swapIndex];

        int nextNum = int.MaxValue;
        int nextNumIndex = -1;

        for (int i = swapIndex+1; i < nums.Length; i++)
        {
            if (nums[i] < nextNum && temp < nums[i])
            {
                nextNum = nums[i];
                nextNumIndex = i;
            }

            if (nextNum == temp + 1) break;
        }

        nums[swapIndex] = nextNum;
        nums[nextNumIndex] = temp;

        for (int i = swapIndex + 1; i < nums.Length; i++)
        {
            int lowest = int.MaxValue;
            int lowestIndex = -1;

            for (int j = i; j < nums.Length; j++)
            {
                if (nums[j] < lowest)
                {
                    lowest = nums[j];
                    lowestIndex = j;
                }
            }

            temp = nums[i];
            nums[i] = lowest;
            nums[lowestIndex] = temp;
        }

        return nums;
    }

    private int[] GetGreatestPermutation(Dictionary<int, int> numbers)
    {
        Dictionary<int, int> numsCopy = numbers.ToDictionary(entry => entry.Key,
                                               entry => entry.Value);
        int total = 0;

        foreach (var pair in numsCopy)
        {
            total += pair.Value;
        }

        int[] greatest = new int[total];
        int index = 0;

        while (numsCopy.Count > 0)
        {
            int highest = int.MinValue;
            foreach (var pair in numsCopy)
            {
                if (pair.Key > highest) highest = pair.Key;
            }

            for (int i = 0; i < numsCopy[highest]; i++)
            {
                greatest[index] = highest;
                ++index;
            }

            numsCopy.Remove(highest);
        }
        return greatest;
    }

    private int[] GetLowestPermutation(Dictionary<int, int> numbers, int[] nums)
    {
        Dictionary<int, int> numsCopy = numbers.ToDictionary(entry => entry.Key,
                                               entry => entry.Value);
        int total = 0;

        foreach (var pair in numsCopy)
        {
            total += pair.Value;
        }

        int index = 0;

        while (numsCopy.Count > 0)
        {
            int low = int.MaxValue;
            foreach (var pair in numsCopy)
            {
                if (pair.Key < low) low = pair.Key;
            }

            for (int i = 0; i < numsCopy[low]; i++)
            {
                nums[index] = low;
                ++index;
            }

            numsCopy.Remove(low);
        }
        return nums;
    }
}

public static class _0031NextPermutation
{
    private static List<int[]> Inputs = new List<int[]>()
    {   
        new int[] {2,3,1},
        new int[] {1,3,2},
        new int[] {1,2,3},
        new int[] {2,3,1},
        new int[] {3,2,1},
        new int[] {1,1,5},
    };
    private static List<int[]> ExpectedOutputs = new List<int[]>()
    {
        new int[] {3,1,2},
        new int[] {2,1,3},
        new int[] {1,3,2},
        new int[] {3,1,2},
        new int[] {1,2,3},
        new int[] {1,5,1},
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var expectedOutput = ExpectedOutputs[i];
            Console.WriteLine($"Input: {string.Join(',', input)}");
            solution.NextPermutation(input);
            Console.WriteLine($"Expected Output: {string.Join(',', expectedOutput)}");
        }
    }
}