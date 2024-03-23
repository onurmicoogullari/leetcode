using FluentAssertions;

namespace LeetCode.Solutions.Tests.Unit.Medium;

public class InsertInterval
{
    // Arrange
    public static IEnumerable<object[]> TestData
    {
        get
        {
            return new object[][]
            {
                new object[] { new int[][] { [1, 3], [6, 9] }, new int[] { 2, 5 }, new int[][] { [1, 5], [6, 9] } },
                new object[] { new int[][] { [1, 2], [3, 5], [6, 7], [8, 10], [12, 16] }, new int[] { 4, 8 }, new int[][] { [1, 2], [3, 10], [12, 16] } },
                new object[] { new int[][] { [1, 2], [3, 5], [6, 7], [8, 10], [12, 16] }, new int[] { 4, 8 }, new int[][] { [1, 2], [3, 10], [12, 16] } },
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void InsertInterval_ReturnsNonOverlappingIntervalsInAscOrder_WhenNewIntervalIsAdded(
        int[][] intervals, int[] newInterval, int[][] expected)
    {
        // Act
        var result = Solutions.Medium.InsertInterval.Solution(intervals, newInterval);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}
