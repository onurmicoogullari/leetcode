using FluentAssertions;

namespace LeetCode.Solutions.Tests.Unit.Easy;

public class ValidParenthesesTests
{
    // Arrange
    public static IEnumerable<object[]> TestData
    {
        get
        {
            return new object[][]
            {
                new object[] { "()", true },
                new object[] { "()[]{}", true },
                new object[] { "(]", false },
                new object[] { "[", false },
                new object[] { "]", false },
            };
        }
    }
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void Solution1_ShouldReturnTrue_IfParenthesesAreValid(string s, bool expected)
    {
        // Act
        bool result = Solutions.Easy.ValidParentheses.Solution1(s);
        
        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void Solution2_ShouldReturnTrue_IfParenthesesAreValid(string s, bool expected)
    {
        // Act
        bool result = Solutions.Easy.ValidParentheses.Solution1(s);
        
        // Assert
        result.Should().Be(expected);
    }
}