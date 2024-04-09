namespace LeetCode.Solutions.Easy;

public static class MaximumDepthOfBinaryTree
{
    /*
        104. Maximum Depth of Binary Tree
        Link: https://leetcode.com/problems/maximum-depth-of-binary-tree/description/
        
        Given the root of a binary tree, return its maximum depth.
        A binary tree's maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.
        
        Example 1:
        
            Input: root = [3,9,20,null,null,15,7]
            Output: 3
            
        Example 2:
       
            Input: root = [1,null,2]
            Output: 2
            
        Constraints:
       
            The number of nodes in the tree is in the range [0, 104].
            -100 <= Node.val <= 100 
    */
    
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    public static int Recursive(TreeNode root)
    {
        // Depth-First Search (DFS) algorithm.
        
        if (root == null)
        {
            return 0;
        }

        int left = Recursive(root.left);
        int right = Recursive(root.right);

        return Math.Max(left, right) + 1;
    }
    
    // TODO: implement using Breadth-First Search (BFS) algorithm
}