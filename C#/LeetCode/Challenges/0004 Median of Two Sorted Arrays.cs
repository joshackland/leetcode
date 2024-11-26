namespace LeetCode.Challenges._0004MedianOfTwoSortedArrays;

public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int length = nums1.Length + nums2.Length;
        int indexStop = (int)Math.Ceiling((double)length / 2) - 1;

        int nums1Index = 0;
        int nums2Index = 0;

        for (int i = 0; i < length; i++)
        {
            bool smallestIsNums1 = false;
            if (nums2Index >= nums2.Length || nums1Index < nums1.Length && nums1[nums1Index] < nums2[nums2Index]){
                nums1Index++;
                smallestIsNums1 = true;
            } else {
                nums2Index++;
            }

            if (i == indexStop){
                if (length % 2 == 0){
                    int evenNum1 = smallestIsNums1 ? nums1[nums1Index - 1] : nums2[nums2Index - 1];

                    int evenNum2 = nums2Index >= nums2.Length || nums1Index < nums1.Length && nums1[nums1Index] < nums2[nums2Index] ? nums1[nums1Index] : nums2[nums2Index];
                    return ((double)evenNum1 + (double)evenNum2) / 2;
                }
                else {
                    if (smallestIsNums1){
                        return nums1[nums1Index - 1];
                    } else {
                        return nums2[nums2Index - 1];
                    }
                }
            }
        }
        return 0;
    }
}