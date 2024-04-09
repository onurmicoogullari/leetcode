using FluentAssertions;

namespace LeetCode.Solutions.Tests.Unit.Easy;
using TreeNode = Solutions.Easy.MaximumDepthOfBinaryTree.TreeNode;

public class MaximumDepthOfBinaryTreeTests
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
                        val: 3,
                        left: new TreeNode(val: 9),
                        right: new TreeNode(
                            val: 20,
                            left: new TreeNode(val: 15),
                            right: new TreeNode(val: 7))), 
                    
                   3, 
                },
                new object[] 
                { 
                    new TreeNode(
                        val: 1,
                        left: null,
                        right: new TreeNode(val: 2)), 
                    
                    2, 
                }
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Recursive_ReturnsMaximumDepth_GivenBinaryTree(TreeNode root, int expected)
    {
        // Act
        int result = Solutions.Easy.MaximumDepthOfBinaryTree.Recursive(root);
        
        // Assert
        result.Should().Be(expected);
    }
}