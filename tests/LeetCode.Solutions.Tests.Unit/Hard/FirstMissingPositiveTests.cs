using FluentAssertions;

namespace LeetCode.Solutions.Tests.Unit.Hard;

public class FirstMissingPositiveTests
{
    // Arrange
    public static IEnumerable<object[]> TestData
    {
        get
        {
            return new object[][]
            {
                new object[] { new int[] { 1, 2, 0 }, 3 },
                new object[] { new int[] { 3, 4, -1, 1}, 2 },
                new object[] { new int[] { 7, 8, 9 ,11 ,12}, 1 },
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Solution_ShouldReturnFirstMissingPositive_GivenArrayOfNumbers(int[] nums, int expected)
    {
        // Act
        int result = Solutions.Hard.FirstMissingPositive.Solution(nums);

        // Assert
        result.Should().Be(expected);
    }
}
