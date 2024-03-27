using FluentAssertions;

namespace LeetCode.Solutions.Tests.Unit;

public class PalindromeNumberTests
{
    // Arrange
    public static IEnumerable<object[]> TestData
    {
        get
        {
            return new object[][]
            {
                new object[] { 121, true },
                new object[] { -121, false },
                new object[] { 10, false },

            };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void BruteForce_ShouldReturnTrue_IfInputNumberIsPalindrome(int x, bool expected)
    {
        // Act
        bool result = Solutions.Easy.PalindromeNumber.BruteForce(x);

        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void WithoutStringConversion_ShouldReturnTrue_IfInputNumberIsPalindrome(int x, bool expected)
    {
        // Act
        bool result = Solutions.Easy.PalindromeNumber.WithoutStringConversion(x);

        // Assert
        result.Should().Be(expected);
    }
}