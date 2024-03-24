using FluentAssertions;

namespace LeetCode.Solutions.Tests.Unit.Medium;

public class LongestSubstringWithoutRepeatingCharactersTests
{
    // Arrange
    public static IEnumerable<object[]> TestData
    {
        get
        {
            return new object[][]
            {
                new object[] { "abcabcbb",  3 },
                new object[] { "bbbbb",  1 },
                new object[] { "pwwkew",  3 },
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void LengthOfLongestSubstring_ReturnsCorrectLengthForGivenInput_BruteForce(string input, int length)
    {
        // Act
        var result = Solutions.Medium.LongestSubstringWithoutRepeatingCharacters.BruteForceSolution(input);

        // Assert
        result.Should().Be(length);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void LengthOfLongestSubstring_ReturnsCorrectLengthForGivenInput_SlidingWindow(string input, int length)
    {
        // Act
        var result = Solutions.Medium.LongestSubstringWithoutRepeatingCharacters.SlidingWindowSolution(input);

        // Assert
        result.Should().Be(length);
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void LengthOfLongestSubstring_ReturnsCorrectLengthForGivenInput_Fastest(string input, int length)
    {
        // Act
        var result = Solutions.Medium.LongestSubstringWithoutRepeatingCharacters.FastestSolution(input);

        // Assert
        result.Should().Be(length);
    }
}