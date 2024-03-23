namespace LeetCode.Solutions.Medium;

public class InsertInterval
{
    /*
        57. Insert Interval
        Link: https://leetcode.com/problems/insert-interval/description/?envType=daily-question&envId=2024-03-17

        You are given an array of non-overlapping intervals intervals where intervals[i] = [starti, endi] represent the start and the end of the ith interval and intervals is sorted in ascending order by starti. You are also given an interval newInterval = [start, end] that represents the start and end of another interval.

        Insert newInterval into intervals such that intervals is still sorted in ascending order by starti and intervals still does not have any overlapping intervals (merge overlapping intervals if necessary).

        Return intervals after the insertion.

        Note that you don't need to modify intervals in-place. You can make a new array and return it.

 

        Example 1:

        Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
        Output: [[1,5],[6,9]]
        Example 2:

        Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
        Output: [[1,2],[3,10],[12,16]]
        Explanation: Because the new interval [4,8] overlaps with [3,5],[6,7],[8,10].

    */

    public static int[][] Solution(int[][] intervals, int[] newInterval)
    {
        // create new array of intervals that will be returned
        // iterate through the incoming intervals
        // take all the intervals that ends before the new interval starts
        // add these to results to keep the ascending order, since they do not overlap
        // merge all the overlapping intervals
        // add the intervals that comes after the new interval

        // basically, we need to go through three steps:
        // 1. no overlaps before merging
        // 2. overlapping and merging
        // 3. no overlaps after merging

        // this algorithm is called a linear search
        // Time complexity: O(N), meaning execution time grows linearly with input)
        // Space Complexity: O(1), meaning memory allocation stays the same regardless of input

        if (intervals.Length == 0)
            return [newInterval];

        List<int[]> result = new();
        int i = 0;

        while (i < intervals.Length && intervals[i][1] < newInterval[0])
        {
            result.Add(intervals[i]);
            i++;
        }

        while (i < intervals.Length && intervals[i][0] <= newInterval[1])
        {
            newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
            newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
            i++;
        }

        result.Add(newInterval);

        while (i < intervals.Length)
        {
            result.Add(intervals[i]);
            i++;
        }

        return result.ToArray();
    }
}
