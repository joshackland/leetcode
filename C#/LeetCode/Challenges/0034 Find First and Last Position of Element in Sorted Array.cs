namespace LeetCode.Challenges._0034FindFirstAndLastPositionOfElementInSortedArray;

public class Solution
{
    public int[] SearchRange(int[] nums, int target)
    {
        int[] indexes = new int[] { -1, -1 };

        if (nums.Length == 0) return indexes;

        int lower = 0;
        int upper = nums.Length - 1;
        int current = upper - ((upper - lower) / 2);

        if (nums[lower] != target && nums[upper] != target) 
        {
            while (current != lower && current != upper)
            {
                if (nums[current] == target)
                {
                    indexes[0] = current;
                    indexes[1] = current;
                    break;
                }

                if (nums[current] < target)
                {
                    lower = current;
                }
                else
                {
                    upper = current;
                }

                current = upper - ((upper - lower) / 2);
            }
        }
        else
        {
            if (nums[lower] == target)
            {
                indexes[0] = lower;
                indexes[1] = lower;
            }
            else
            {
                indexes[0] = upper;
                indexes[1] = upper;
            }
        }

        

        if (indexes[0] == -1) return indexes;

        for (int i = indexes[0]; i >= 0; i--)
        {
            if (nums[i] == target)
            {
                indexes[0] = i;
            }
            else
            {
                break;
            }
        }

        for (int i = indexes[1]; i < nums.Length; i++)
        {
            if (nums[i] == target)
            {
                indexes[1] = i;
            }
            else
            {
                break;
            }
        }

        return indexes;
    }
}

public static class _0034FindFirstAndLastPositionOfElementInSortedArray
{
    private static List<int[]> Inputs = new List<int[]>()
    {
        new int [] { 0,1,2,3,4,4,4 },
        new int [] { 5, 7, 7, 8, 8, 10 },
        new int [] { 5, 7, 7, 8, 8, 10 },
        new int [] {  },
    };
    private static List<int> Targets = new List<int>()
    {
        2,
        8,
        6,
        0
    };
    private static List<int[]> ExpectedOutputs= new List<int[]>()
    {
        new int [] { 2,2 },
        new int [] { 3,4 },
        new int [] { -1,-1 },
        new int [] { -1,-1 },
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var target = Targets[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.SearchRange(input, target);
            Console.WriteLine($"Input: {string.Join(',',input)}, Expected Output: {string.Join(',', expectedOutput)}, Actual Output: {string.Join(',', actualOutput)}");
        }
    }
}