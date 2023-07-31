namespace LeetCode.Challenges._0039CombinationSum;

public class Solution
{
    public List<IList<int>> output;
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        output = new List<IList<int>>();

        Array.Sort(candidates);

        Sum(0, candidates.ToList(), target, new List<int>());

        return output;
    }

    public void Sum(int sum, List<int> candidates, int target, List<int> combination)
    {
        var candidatesCopy = new List<int>(candidates);

        foreach (int candidate in candidates)
        {
            List<int> combinationCopy = new List<int>(combination);
            int sumcopy = sum + candidate;

            if (sumcopy > target) return;

            combinationCopy.Add(candidate);

            if (sumcopy == target)
            {
                output.Add(combinationCopy);
                return;
            }

            Sum(sumcopy, candidatesCopy, target, combinationCopy);
            candidatesCopy.RemoveAt(0);
        }
    }
}

public static class _0039CombinationSum
{
    private static List<int[]> Inputs = new List<int[]>()
    {
        new int[] { 8,7,4,3 },
        new int[] { 2, 3, 6, 7 },
        new int[] { 2, 3, 5 },
        new int[] { 2 },
    };
    private static List<int> Targets = new List<int>()
    {
        11,
        7,
        8,
        1
    };
    private static List<List<List<int>>> ExpectedOutputs= new List<List<List<int>>>() 
    { 
        new List<List<int>>
        {
            new List<int> { 8, 3 },
            new List<int> { 7, 4 },
            new List<int> { 4, 4, 3 },
        },
        new List<List<int>>
        {
            new List<int> { 2, 2, 3 },
            new List<int> { 7 },
        },
        new List<List<int>>
        {
            new List<int> { 2, 2, 2, 2 },
            new List<int> { 2, 3, 3 },
            new List<int> { 3, 5 },
        },
        new List<List<int>>
        {
        },
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var target = Targets[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.CombinationSum(input, target);
            Console.WriteLine($"Input: {string.Join(',',input)}, Target: {target}, Expected Output: {JoinLists(expectedOutput)}, Actual Output: {JoinLists(actualOutput)}");
        }
    }

    private static string JoinLists(List<List<int>> list)
    {
        string output = "\n";

        foreach (var nums in list)
        {
            output += string.Join(',', nums) + "\n";
        }

        return output;
    }
    private static string JoinLists(IList<IList<int>> list)
    {
        string output = "\n";

        foreach (var nums in list)
        {
            output += string.Join(',', nums) + "\n";
        }

        return output;
    }
}