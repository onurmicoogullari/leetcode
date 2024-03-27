namespace LeetCode.Solutions.Hard;

public static class MedianOfTwoSortedArrays
{
    /*
        4. Median of Two Sorted Arrays
        Link: https://leetcode.com/problems/median-of-two-sorted-arrays/description/
        Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
       
        The overall run time complexity should be O(log (m+n)).
           
        Example 1:
           
            Input: nums1 = [1,3], nums2 = [2]
            Output: 2.00000
            Explanation: merged array = [1,2,3] and median is 2.
           
        Example 2:
           
            Input: nums1 = [1,2], nums2 = [3,4]
            Output: 2.50000
            Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.
           
        Constraints:
           
            nums1.length == m
            nums2.length == n
            0 <= m <= 1000
            0 <= n <= 1000
            1 <= m + n <= 2000
            -106 <= nums1[i], nums2[i] <= 106
     */
    
    public static double BruteForce(int[] nums1, int[] nums2)
    {
        int[] result = nums1.Concat(nums2).ToArray();
        Array.Sort(result);
        int n = result.Length;

        if (result.Length % 2 == 0)
        {
            int pos = n / 2;
            return (double)(result[pos - 1] + result[pos]) / 2;
        }

        return Math.Floor((double)result[n / 2]);
    }

    public static double Efficient(int[] nums1, int[] nums2)
    {
        if (nums1.Length == 0 && nums2.Length == 0)
        {
            return 0.0;   
        }
        
        int[] mergedNums = MergeSortedArrays(nums1, nums2);
        int length = mergedNums.Length;

        if (length % 2 == 0)
        {
            int position = length / 2;
            return (double)(mergedNums[(length / 2) - 1] + mergedNums[position]) / 2;
        }

        return Math.Floor((double)mergedNums[length / 2]);
    }

    private static int[] MergeSortedArrays(int[] nums1, int[] nums2)
    {
        int[] mergedNums = new int[nums1.Length + nums2.Length];

        int i = 0;
        int j = 0;
        int k = 0;

        while (i < nums1.Length && j < nums2.Length)
        {
            if (nums1[i] < nums2[j])
            {
                mergedNums[k] = nums1[i];
                i++;
            }
            else
            {
                mergedNums[k] = nums2[j];
                j++;
            }

            k++;
        }

        while (i < nums1.Length)
        {
            mergedNums[k] = nums1[i];
            i++;
            k++;
        }

        while (j < nums2.Length)
        {
            mergedNums[k] = nums2[j];
            j++;
            k++;
        }

        return mergedNums;
    }
}