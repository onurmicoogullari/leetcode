using FluentAssertions;

namespace LeetCode.Solutions.Tests.Unit.Easy;

public class ValidAnagramTests
{
    // Arrange
    public static IEnumerable<object[]> TestData
    {
        get
        {
            return new object[][]
            {
                new object[] { "anagram", "nagaram", true },
                new object[] { "rat", "car", false },
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void BruteForce_ShouldReturnTrue_WhenInputsAreValidAnagrams(string s, string t, bool expected)
    {
        // Act
        bool result = Solutions.Easy.ValidAnagram.BruteForce(s, t);
        
        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void BySorting_ShouldReturnTrue_WhenInputsAreValidAnagrams(string s, string t, bool expected)
    {
        // Act
        bool result = Solutions.Easy.ValidAnagram.BySorting(s, t);
        
        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void ByAsci_ShouldReturnTrue_WhenInputsAreValidAnagrams(string s, string t, bool expected)
    {
        // Act
        bool result = Solutions.Easy.ValidAnagram.ByAsci(s, t);
        
        // Assert
        result.Should().Be(expected);
    }
}