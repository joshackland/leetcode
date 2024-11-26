namespace LeetCode.Challenges._00153Sum;

public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {        
        var output = new List<IList<int>>();

        Array.Sort(nums);

        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (i > 1 && nums[i] == nums[i - 1]) continue;

            int low = i + 1;
            int high = nums.Length - 1;

            while (low < high)
            {
                int sum = nums[i] + nums[low] + nums[high];

                if (sum == 0)
                {
                    var numlist = new List<int>() { nums[i], nums[low], nums[high] };
                    bool exists = false;
                    foreach (var nlist in output)
                    {
                        if (nlist[0] == numlist[0] && nlist[1] == numlist[1] && nlist[2] == numlist[2])
                        {
                            exists = true;
                            break;
                        }
                    }

                    if (!exists)
                    {
                        output.Add(numlist);
                    }

                    while (low < high && nums[low] == nums[low + 1])
                    {
                        low++;
                    }
                    while (low < high && nums[high] == nums[high - 1])
                    {
                        high--;
                    }

                    low++;
                    high--;
                }
                else if (sum < 0)
                {
                    low++;
                }
                else
                {
                    high--;
                }
            }
        }

        return output;
    }
}

public static class _00153Sum
{
    private static List<int[]> Inputs = new List<int[]>()
    {
        new int[] { -1, 0, 1, 2, -1, -4 },
        new int[] { 0, 1, 1 },
        new int[] { 0, 0, 0 },
    };
    private static List<List<List<int>>> ExpectedOutputs= new List<List<List<int>>>() 
    { 
        new List<List<int>> { 
            new List<int> { -1, -1, 2 },
            new List<int> { -1, 0, 1 }
        },
        new List<List<int>>(),
        new List<List<int>> {
            new List<int> { 0, 0, 0 },
        }
    };
    public static void Test()
    {
        var solution = new Solution();

        foreach (var (input, expectedOutput) in Inputs.Zip(ExpectedOutputs))
        {
            var actualOutput = solution.ThreeSum(input);
            Console.WriteLine($"Input: {input}, Expected Output: {expectedOutput}, Actual Output: {actualOutput}");
        }
    }
}