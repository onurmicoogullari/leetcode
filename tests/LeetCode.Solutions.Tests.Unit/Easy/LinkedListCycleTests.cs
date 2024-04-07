using FluentAssertions;

namespace LeetCode.Solutions.Tests.Unit.Easy;
using ListNode = Solutions.Easy.LinkedListCycle.ListNode;

public class LinkedListCycleTests
{
    // Arrange
    public static IEnumerable<object[]> TestData
    {
        get
        {
            // Test case 1
            ListNode t1n1 = new ListNode( 3);
            ListNode t1n2 = new ListNode( 2);
            ListNode t1n3 = new ListNode( 0);
            ListNode t1n4 = new ListNode( 4);

            t1n1.next = t1n2;
            t1n2.next = t1n3;
            t1n3.next = t1n4;
            t1n4.next = t1n2;
            
            // Test case 2
            ListNode t2n1 = new ListNode( 1);
            ListNode t2n2 = new ListNode( 2);

            t2n1.next = t2n2;
            t2n2.next = t2n1;
            
            
            return new object[][]
            {
                new object[] { t1n1, true },
                new object[] { t2n1, true },
                new object[] { new ListNode( 1), false },
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void BruteForce_ReturnsTrue_IfLinkedListContainsCycles(ListNode head, bool expected)
    {
        // Act
        bool result = Solutions.Easy.LinkedListCycle.BruteForce(head);
        
        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void Efficient_ReturnsTrue_IfLinkedListContainsCycles(ListNode head, bool expected)
    {
        // Act
        bool result = Solutions.Easy.LinkedListCycle.Efficient(head);
        
        // Assert
        result.Should().Be(expected);
    }
}