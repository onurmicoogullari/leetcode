using System.Runtime.Serialization;
using FluentAssertions;

namespace LeetCode.Solutions.Tests.Unit.Hard;

public class MedianOfTwoSortedArrays
{
    // Arrange
    public static IEnumerable<object[]> TestData
    {
        get
        {
            return new object[][]
            {
                new object[] { new int[] { 1, 2 },  new int[] { 3, 4 },  2.5 },
                new object[] { new int[] { 1, 3 },  new int[] { 2 },  2.0 },
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void BruteForce_ShouldReturnMedian_GivenTwoSortedArrays(int[] nums1, int[] nums2, double expected)
    {
        // Act
        var result = Solutions.Hard.MedianOfTwoSortedArrays.BruteForce(nums1, nums2);
        
        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void Efficient_ShouldReturnMedian_GivenTwoSortedArrays(int[] nums1, int[] nums2, double expected)
    {
        // Act
        var result = Solutions.Hard.MedianOfTwoSortedArrays.Efficient(nums1, nums2);
        
        // Assert
        result.Should().Be(expected);
    }
}