using FluentAssertions;

namespace LeetCode.Solutions.Tests.Unit.Medium;

public class LargestPalindromicNumberTests
{
    // Arrange
    public static IEnumerable<object[]> TestData
    {
        get
        {
            return new object[][]
            {
                new object[] { "444947137", "7449447" },
                new object[] { "00009", "9" },
                new object[] { "000090009", "900000009" },
                new object[] { "00000000000000000000", "0" },
                new object[] { "111", "111" },
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void BruteForce_ReturnsLargestPalindromicNumber_GivenStringOfDigits(string num, string expected)
    {
        // Act
        string result = Solutions.Medium.LargestPalindromicNumber.BruteForce(num);
        
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void Efficient_ReturnsLargestPalindromicNumber_GivenStringOfDigits(string num, string expected)
    {
        // Act
        string result = Solutions.Medium.LargestPalindromicNumber.Efficient(num);
        
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}