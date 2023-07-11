namespace LeetCode.Challenges._4Sum0018;

public class Solution
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {        
        var output = new List<IList<int>>();

        Array.Sort(nums);

        for (int lower = 0; lower < nums.Length - 3; lower++)
        {
            if (lower > 1 && nums[lower] == nums[lower - 1]) continue;

            for (int upper = nums.Length -1; upper >= lower + 3; upper--)
            {
                if (upper < nums.Length - 1 && nums[upper] == nums[upper + 1]) continue;

                int low = lower + 1;
                int high = upper - 1;

                while (low < high)
                {
                    long sum = (long)nums[lower] + (long)nums[low] + (long)nums[high] + (long)nums[upper];

                    if (sum == target)
                    {
                        var numlist = new List<int>() { nums[lower], nums[low], nums[high], nums[upper] };
                        bool exists = false;
                        foreach (var nlist in output)
                        {
                            if (nlist[0] == numlist[0] 
                                && nlist[1] == numlist[1] 
                                && nlist[2] == numlist[2]
                                && nlist[3] == numlist[3])
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
                    else if (sum < target)
                    {
                        low++;
                    }
                    else
                    {
                        high--;
                    }
                }
            }
        }

        return output;
    }
}

public static class _4Sum0018
{
    private static List<int[]> Inputs = new List<int[]>()
    {
        new int[] { 1, 0, -1, 0, -2, 2 },
        new int[] { 2, 2, 2, 2, 2 },
    };
    private static List<int> Targets = new List<int>()
    {
        0,
        8
    };
    private static List<List<List<int>>> ExpectedOutputs= new List<List<List<int>>>() 
    { 
        new List<List<int>> {
            new List<int> { -2, -1, 1, 2 },
            new List<int> { -2, 0, 0, 2 },
            new List<int> { -1, 0, 0, 1 }
        },
        new List<List<int>> {
            new List<int> { 2, 2, 2, 2 },
        }
    };
    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = Inputs[i];
            var target = Targets[i];
            var expectedOutput = ExpectedOutputs[i];

            string expected = "";
            foreach (var list in expectedOutput)
                expected += string.Join(',', list) + " --- ";
            
            var actualOutput = solution.FourSum(input, target);
            string actual = "";
            foreach (var list in actualOutput)
                actual += string.Join(',', list) + " --- ";

            Console.WriteLine($"Input: {string.Join(',', input)}, Expected Output: {expected}, Actual Output: {actual}");
        }
    }
}