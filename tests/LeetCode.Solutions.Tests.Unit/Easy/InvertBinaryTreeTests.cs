using FluentAssertions;

namespace LeetCode.Solutions.Tests.Unit.Easy;
using TreeNode = Solutions.Easy.InvertBinaryTree.TreeNode;

public class InvertBinaryTreeTests
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
                        val: 4,
                        left: new TreeNode(
                            val: 2,
                            left: new TreeNode(val: 1),
                            right: new TreeNode(val: 3)),
                        right: new TreeNode(
                            val: 7,
                            left: new TreeNode(val: 6),
                            right: new TreeNode(val: 9))), 
                    
                    new TreeNode(
                        val: 4,
                        left: new TreeNode(
                            val: 7,
                            left: new TreeNode(val: 9),
                            right: new TreeNode(val: 6)),
                        right: new TreeNode(
                            val: 2,
                            left: new TreeNode(val: 3),
                            right: new TreeNode(val: 1))), 
                },
                new object[] 
                { 
                    new TreeNode(
                        val: 2,
                        left: new TreeNode(val: 1),
                        right: new TreeNode(val: 3)), 
                    
                    new TreeNode(
                        val: 2,
                        left: new TreeNode(val: 3),
                        right: new TreeNode(val: 1)), 
                },
                new object[] { null, null}
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Recursive_Inverts_GivenBinaryTree(TreeNode root, TreeNode expected)
    {
        // Act
        TreeNode result = Solutions.Easy.InvertBinaryTree.Recursive(root);
        
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [MemberData(nameof(TestData))]
    public void Iterative_Inverts_GivenBinaryTree(TreeNode root, TreeNode expected)
    {
        // Act
        TreeNode result = Solutions.Easy.InvertBinaryTree.Iterative(root);
        
        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}