namespace LeetCode.Challenges._0060PermutationSequence;

public class Solution
{ 
    public class Permutation
    {
        public int k;
        public int PermutationCount;
    }
    public string GetPermutation(int n, int k)
    {
        int[] nums = new int[n];

        for (int i = 0; i < n; i++)
        {
            nums[i] = i+1;
        }

        string output = Permutations(nums.ToList(), new List<int>(), new Permutation { k = k, PermutationCount = 0 });

        return output;
    }

    public string Permutations(List<int> nums, List<int> currentPermutation, Permutation p)
    {
        string permutation = "";

        if (nums.Count == 1)
        {
            currentPermutation.Add(nums[0]);
            p.PermutationCount++;
            return string.Join("", currentPermutation);
        }

        for (int i = 0; i < nums.Count; i++)
        {
            List<int> copyPermutation = new List<int>(currentPermutation);
            List<int> copyNums = new List<int>(nums);

            copyPermutation.Add(nums[i]);
            copyNums.RemoveAt(i);

            permutation = Permutations(copyNums, copyPermutation, p);

            if (p.PermutationCount == p.k) return permutation;
        }

        return permutation;
    }
}

public static class _0060PermutationSequence
{
    private static List<int> Inputs = new List<int>()
    {
        3,
        4,
        3
    };
    private static List<int> Ks = new List<int>()
    {
        3, 
        9, 
        1
    };
    private static List<string> ExpectedOutputs = new List<string>()
    {
        "213",
        "2314",
        "123"
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var k = Ks[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.GetPermutation(input, k);
            Console.WriteLine($"Input: {input}, K: {k}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}