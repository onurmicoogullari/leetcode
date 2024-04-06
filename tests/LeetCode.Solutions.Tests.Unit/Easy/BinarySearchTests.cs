using FluentAssertions;

namespace LeetCode.Solutions.Tests.Unit.Easy;

public class BinarySearchTests
{
    // Arrange
    public static IEnumerable<object[]> TestData
    {
        get
        {
            return new object[][]
            {
                new object[] { new int[] { -1, 0, 3, 5, 9, 12 }, 9, 4 },
                new object[] { new int[] { -1, 0, 3, 5, 9, 12 }, 2, -1 },
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Solution_ShouldReturnIndexOfTarget_GivenArrayWhereItExists(int[] nums, int target, int expected)
    {
        // Act
        int result = Solutions.Easy.BinarySearch.Solution(nums, target);
        
        // Assert
        result.Should().Be(expected);
    }
}