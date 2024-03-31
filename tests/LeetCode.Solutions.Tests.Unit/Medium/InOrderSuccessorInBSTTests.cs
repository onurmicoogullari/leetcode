using FluentAssertions;
using LeetCode.Solutions.Medium;
using TreeNode = LeetCode.Solutions.Medium.InOrderSuccessorInBST.TreeNode;

namespace LeetCode.Solutions.Tests.Unit.Medium;

public class InOrderSuccessorInBSTTests
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
                    new TreeNode(
                        2, 
                        left: new TreeNode(1), 
                        right: new TreeNode(3)), 
                    new TreeNode(1), 
                    new TreeNode(2)  
                },
                new object[] 
                { 
                    new TreeNode(
                        5, 
                        left: new TreeNode(
                            3,
                            left: new TreeNode(
                                2,
                                left: new TreeNode(1)),
                            right: new TreeNode(4)), 
                        right: new TreeNode(6)), 
                    new TreeNode(6), 
                    null  
                },
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Solution_ShouldReturnInOrderSuccessorToP_IfItExistsInBinarySearchTree(TreeNode root,
        TreeNode p, TreeNode? successor)
    {
        // Act
        TreeNode? result = InOrderSuccessorInBST.Solution(root, p);

        // Assert
        if (successor is null)
        {
            result.Should().BeNull();
        }
        else
        {
            result.val.Should().Be(successor.val);    
        }
    }
}