using FluentAssertions;

namespace LeetCode.Solutions.Tests.Unit.Easy;

public class ContainsDuplicateTests
{
    // Arrange
    public static IEnumerable<object[]> TestData
    {
        get
        {
            return new object[][]
            {
                new object[] { new int[] {1, 2, 3, 1}, true },
                new object[] { new int[] {1, 2, 3, 4}, false },
                new object[] { new int[] {1, 1, 1, 3, 3, 4, 3, 2, 4, 2}, true },
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Solution_ShouldReturnTrue_IfNumsContainsDuplicates(int[] nums, bool expected)
    {
        // Act
        bool result = Solutions.Easy.ContainsDuplicate.Solution(nums);
        
        // Assert
        result.Should().Be(expected);
    }
}