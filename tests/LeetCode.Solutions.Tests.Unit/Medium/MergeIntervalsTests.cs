using FluentAssertions;

namespace LeetCode.Solutions.Tests.Unit.Medium;

public class MergeIntervalsTests
{
    // Arrange
    public static IEnumerable<object[]> TestData
    {
        get
        {
            return new object[][]
            {
                new object[] { new int[][] { [8,10], [1,3], [2,6], [15,18] }, new int[][] { [1,6], [8,10], [15,18] } },
                new object[] { new int[][] { [1,4], [4,5] }, new int[][] { [1,5] } },
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Solution_ShouldReturnMergedIntervals_GivenOverlappingIntervals(int[][] intervals, int[][] expected)
    {
        // Act
        int[][] result = Solutions.Medium.MergeIntervals.Solution(intervals);
        
        // Assert
        result.Should().BeEquivalentTo(result);
    }
}