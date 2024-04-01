namespace LeetCode.Solutions.Medium;

public static class MergeIntervals
{
    /*
        56. Merge Intervals
        Link: https://leetcode.com/problems/merge-intervals/description/
        
        Given an array of intervals where intervals[i] = [starti, endi], merge all overlapping intervals, and return an array of the non-overlapping intervals that cover all the intervals in the input. 
       
        Example 1:
       
            Input: intervals = [[1,3],[2,6],[8,10],[15,18]]
            Output: [[1,6],[8,10],[15,18]]
            Explanation: Since intervals [1,3] and [2,6] overlap, merge them into [1,6].
            
        Example 2:
       
            Input: intervals = [[1,4],[4,5]]
            Output: [[1,5]]
            Explanation: Intervals [1,4] and [4,5] are considered overlapping.
        
        Constraints:
       
            1 <= intervals.length <= 104
            intervals[i].length == 2
            0 <= starti <= endi <= 104 
    */

    public static int[][] Solution(int[][] intervals)
    {
        intervals = intervals.OrderBy(interval => interval[0]).ToArray();
        List<int[]> result = new List<int[]>();

        for (int i = 0; i < intervals.Length; i++)
        {
            if (result.Count == 0 || result.Last()[1] < intervals[i][0])
            {
                result.Add(intervals[i]);
            }
            else
            {
                result.Last()[1] = Math.Max(result.Last()[1], intervals[i][1]);
            }
        }

        return result.ToArray();
    }
}