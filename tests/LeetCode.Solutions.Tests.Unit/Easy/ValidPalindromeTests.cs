using FluentAssertions;

namespace LeetCode.Solutions.Tests.Unit.Easy;

public class ValidPalindromeTests
{
    // Arrange
    public static IEnumerable<object[]> TestData
    {
        get
        {
            return new object[][]
            {
                new object[] { "A man, a plan, a canal: Panama", true },
                new object[] { "race a car", false },
                new object[] { " ", true },
                new object[] { ".,", true },
            };  
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void BruteForce_ShouldReturnTrue_GivenValidPalindrome(string s, bool expexted)
    {
        // Act
        bool result = Solutions.Easy.ValidPalindrome.BruteForce(s);
        
        // Assert
        result.Should().Be(expexted);
    }
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void Effective_ShouldReturnTrue_GivenValidPalindrome(string s, bool expexted)
    {
        // Act
        bool result = Solutions.Easy.ValidPalindrome.Effective(s);
        
        // Assert
        result.Should().Be(expexted);
    }
}