using FluentAssertions;

namespace LeetCode.Solutions.Tests.Unit.Easy;

public class LongestCommonPrefixTests
{
    // Arrange
    public static IEnumerable<object[]> TestData
    {
        get
        {
            return new object[][]
            {
                new object[] { new string[] { "flower", "flow", "flight" }, "fl" },
                new object[] { new string[] { "dog", "racecar", "car"} , "" },
                new object[] { new string[] { "a" } , "a" },
                new object[] { new string[] { "flower", "flower", "flower", "flower" } , "flower" },
                new object[] { new string[] { "ab", "a" } , "a" },
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void BruteForce_ShouldReturnLongestCommonPrefix_GivenAnArrayOfStrings(string[] strs, string expected)
    {
        // Act
        string result = Solutions.Easy.LongestCommonPrefix.BruteForce(strs);
        
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void Compact_ShouldReturnLongestCommonPrefix_GivenAnArrayOfStrings(string[] strs, string expected)
    {
        // Act
        string result = Solutions.Easy.LongestCommonPrefix.Efficient(strs);
        
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}