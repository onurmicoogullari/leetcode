using FluentAssertions;

namespace LeetCode.Solutions.Tests.Unit.Easy;
using ListNode = Solutions.Easy.ReverseLinkedList.ListNode;

public class ReverseLinkedListTests
{
    // Arrange
    public static IEnumerable<object[]> TestData
    {
        get
        {
            return new object[][]
            {
                new object[] { 
                    new ListNode(
                        val: 1,
                        next: new ListNode(
                            val: 2,
                            next: new ListNode(
                                val: 3,
                                next: new ListNode(
                                    val: 4,
                                    next: new ListNode(
                                        val: 5,
                                        next: null))))),
                    
                    new ListNode(
                        val: 5,
                        next: new ListNode(
                            val: 4,
                            next: new ListNode(
                                val: 3,
                                next: new ListNode(
                                    val: 2,
                                    next: new ListNode(
                                        val: 1,
                                        next: null)))))},
                
                new object[] { 
                    new ListNode(
                        val: 1,
                        next: new ListNode(
                            val: 2,
                            next: null)),
                    
                    new ListNode(
                        val: 2,
                        next: new ListNode(
                            val: 1,
                            next: null)),},
                
                new object[] { null, null }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Iteratively_ReturnsReversedLinkedList_GivenLinkedList(ListNode head, ListNode expected)
    {
        // Act
        ListNode result = Solutions.Easy.ReverseLinkedList.Iteratively(head);
        
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void Recursively_ReturnsReversedLinkedList_GivenLinkedList(ListNode head, ListNode expected)
    {
        // Act
        ListNode result = Solutions.Easy.ReverseLinkedList.Recursively(head);
        
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}