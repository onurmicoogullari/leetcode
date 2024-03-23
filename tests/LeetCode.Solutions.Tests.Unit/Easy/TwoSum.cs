using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LeetCode.Solutions.Tests.Unit.Easy;

public class TwoSum
{
    // Arrange
    public static IEnumerable<object[]> TestData
    {
        get
        {
            return new object[][]
            {
                new object[] { new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 } },
                new object[] { new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 } },
                new object[] { new int[] { 3, 3 }, 6, new int[] { 0, 1 } },
                new object[] { new int[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 }, 11, new int[] { 5, 11 } },
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void TwoSum_ReturnsIndicies_WhenGivenNumsWithTwoValuesThatSumsUpToTarget(
        int[] nums, int target, int[] expected)
    {
        // Act
        var result = Solutions.Easy.TwoSum.Solution(nums, target);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void TwoSum_ThrowsException_WhenGivenNumsWithoutTwoValuesThatSumsUpToTarget()
    {
        // Arrange
        int[] nums = [1, 6, 4, 3];
        int target = 27;

        // Act
        var result = () => Solutions.Easy.TwoSum.Solution(nums, target);

        // Assert
        result.Should().Throw<ArgumentException>("There is no two values in 'nums' that sums up to the value of 'target'.");
    }
}
