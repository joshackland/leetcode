namespace LeetCode.Challenges._0033SearchInRotatedSortedArray;

public class Solution
{
    public int Search(int[] nums, int target)
    {
        int lower = 0;
        int higher = nums.Length - 1;


        while (true)
        {
            if (nums[lower] == target) return lower;
            if (nums[higher] == target) return higher;

            int index = higher - ((higher - lower) / 2);

            if (index == lower || index == higher) return -1;

            int num = nums[index];

            if (num == target) return index;

            if (target > nums[lower] && target < nums[higher])
            {
                if (target < num)
                {
                    higher = index;
                }
                else
                {
                    lower = index;
                }
            }
            else
            {
                if (target < num)
                {
                    if (target < nums[higher] && num > nums[higher])
                    {
                        lower = index;
                    }
                    else
                    {
                        higher = index;
                    }
                }
                else
                {
                    if (target > nums[lower] && num < nums[lower])
                    {
                        higher = index;
                    }
                    else
                    {
                        lower = index;
                    }
                }
            }
        }
    }
}

public static class _0033SearchInRotatedSortedArray
{
    private static List<int[]> Inputs = new List<int[]>()
    {
        new int[] { 7,8,1,2,3,4,5,6 },
        new int[] { 2,3,4,5,6,7,8,9,1 },
        new int[] { 4,5,6,7,0,1,2 },
        new int[] { 4, 5, 6, 7, 0, 1, 2 },
        new int[] { 4, 5, 6, 7, 0, 1, 2 },
        new int[] { 1 },
    };
    private static List<int> Targets = new List<int>()
    {
        2,
        9,
        5,
        0,
        3,
        0
    };
    private static List<int> ExpectedOutputs= new List<int>()
    {
        3,
        7,
        1,
        4,
        -1,
        -1,
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var target = Targets[i];
            var expectedOutput = ExpectedOutputs[i];
            var actualOutput = solution.Search(input, target);
            Console.WriteLine($"Input: {string.Join(',',input)}, Target: {target}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}