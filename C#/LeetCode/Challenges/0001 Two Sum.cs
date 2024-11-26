namespace LeetCode.Challenges._0001TwoSum;

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        for (int i = 0; i < (nums.Length - 1); i++) {
            for (int j = i + 1; j < nums.Length; j++) {
                if (nums[i] + nums[j] == target) {
                    return new int[2] { i, j };
                }
            }
        }
        return new int[0];
    }
}