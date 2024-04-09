namespace LeetCode.Solutions.Easy;

public static class InvertBinaryTree
{
    /*
        226. Invert Binary Tree
        Link: https://leetcode.com/problems/invert-binary-tree/description/
        
        Given the root of a binary tree, invert the tree, and return its root.
        
        Example 1:
        
            Input: root = [4,2,7,1,3,6,9]
            Output: [4,7,2,9,6,3,1]
            
        Example 2:
        
            Input: root = [2,1,3]
            Output: [2,3,1]
            
        Example 3:
        
            Input: root = []
            Output: []
            
        Constraints:
       
           The number of nodes in the tree is in the range [0, 100].
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

    public static TreeNode Recursive(TreeNode root)
    {
        // This algorithm is called Depth-First Search, or DFS.
        // It helps us traverse the binary tree by enabling us to visit all the possible paths.
        // Each time we hit a leaf node, we turn back and go to the next unexplored path.
        // For each parent of the leaf node, we swap its left and right children.

        if (root == null)
        {
            return null;
        }

        TreeNode left = Recursive(root.left);
        TreeNode right = Recursive(root.right);
        root.left = right;
        root.right = left;

        return root;
    }

    public static TreeNode Iterative(TreeNode root)
    {
        if (root == null)
        {
            return null;
        }

        Queue<TreeNode> queue = new();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            TreeNode current = queue.Dequeue();
            TreeNode tmp = current.left;
            current.left = current.right;
            current.right = tmp;

            if (current.left != null)
            {
                queue.Enqueue(current.left);
            }

            if (current.right != null)
            {
                queue.Enqueue(current.right);
            }
        }

        return root;
    }
}