using FluentAssertions;

namespace LeetCode.Solutions.Tests.Unit.Easy;
using ListNode = Solutions.Easy.MergeTwoSortedLists.ListNode;

public class MergeTwoSortedListsTests
{
    // Arrange
    public static IEnumerable<object[]> TestData
    {
        get
        {
            return new object[][]
            {
                new object[]
                {
                    new ListNode(
                        val: 1,
                        next: new ListNode(
                            val: 2,
                            next: new ListNode(
                                val: 4,
                                next: null))),
                    
                    new ListNode(
                        val: 1,
                        next: new ListNode(
                            val: 3,
                            next: new ListNode(
                                val: 4,
                                next: null))),
                    
                    new ListNode(
                        val: 1,
                        next: new ListNode(
                            val: 1,
                            next: new ListNode(
                                val: 2,
                                next: new ListNode(
                                    val: 3,
                                    next: new ListNode(
                                        val: 4,
                                        next: new ListNode(
                                            val: 4,
                                            next: null)))))),
                },
                new object[] { null, null, null },
                new object[] { null, new ListNode(val: 0, next: null), new ListNode(val: 0, next: null) },
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Solution_ShouldReturnMergedList_GivenTwoSortedLinkedLists(ListNode list1, ListNode list2,
        ListNode expected)
    {
        // Act
        ListNode result = Solutions.Easy.MergeTwoSortedLists.Solution(list1, list2);
        
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}