using FluentAssertions;

namespace LeetCode.Solutions.Tests.Unit.Easy;

public class RomanToInteger
{
    // Arrange
    public static IEnumerable<object[]> TestData
    {
        get
        {
            return new object[][]
            {
                new object[] { "III", 3 },
                new object[] { "LVIII", 58 },
                new object[] { "MCMXCIV", 1994 },
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void BruteForce_ShouldReturnIntegerRepresentation_WhenGivenRomanNumerals(string s, int expected)
    {
        // Act
        int result = Solutions.Easy.RomanToInteger.BruteForce(s);
        
        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void Compact_ShouldReturnIntegerRepresentation_WhenGivenRomanNumerals(string s, int expected)
    {
        // Act
        int result = Solutions.Easy.RomanToInteger.Compact(s);
        
        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void Efficient_ShouldReturnIntegerRepresentation_WhenGivenRomanNumerals(string s, int expected)
    {
        // Act
        int result = Solutions.Easy.RomanToInteger.Efficient(s);
        
        // Assert
        result.Should().Be(expected);
    }
}