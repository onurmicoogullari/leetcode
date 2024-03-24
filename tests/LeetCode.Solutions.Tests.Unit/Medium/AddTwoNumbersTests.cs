using FluentAssertions;
using LeetCode.Solutions.Medium;

namespace LeetCode.Solutions.Tests.Unit.Medium;

public class AddTwoNumbersTests
{
    // Arrange
    public static IEnumerable<object[]> TestData
    {
        get
        {
            return new object[][]
            {
                new object[] { new ListNode(2, new ListNode(4, new ListNode(3))), new ListNode(5, new ListNode(6, new ListNode(4))), new ListNode(7, new ListNode(0, new ListNode(8)))},

                new object[] { new ListNode(0), new ListNode(0), new ListNode(0)},

                new object[] { new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))))))), new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))), new ListNode(8, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(0, new ListNode(0, new ListNode(0, new ListNode(1))))))))},
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void AddTwoNumbers_ReturnsLinkedListWithSumOfNumbers_GivenTwoLinkedListOfNumbers(
        ListNode l1, ListNode l2, ListNode expected)
    {
        // Act
        var result = Solutions.Medium.AddTwoNumbers.Solution(l1, l2);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}
