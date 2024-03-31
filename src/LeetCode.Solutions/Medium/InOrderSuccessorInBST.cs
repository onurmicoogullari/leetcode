namespace LeetCode.Solutions.Medium;

public static class InOrderSuccessorInBST
{
    /*
        285. Inorder Successor in BST
        Link: https://leetcode.com/problems/inorder-successor-in-bst/description/
        
        Given the root of a binary search tree and a node p in it, return the in-order successor of that node in the BST. If the given node has no in-order successor in the tree, return null.
       
        The successor of a node p is the node with the smallest key greater than p.val.
       
        Example 1:
       
            Input: root = [2,1,3], p = 1
            Output: 2
            Explanation: 1's in-order successor node is 2. Note that both p and the return value is of TreeNode type.
            
        Example 2:
       
           Input: root = [5,3,6,2,4,null,null,1], p = 6
           Output: null
           Explanation: There is no in-order successor of the current node, so the answer is null.
           
        Constraints:
       
           The number of nodes in the tree is in the range [1, 104].
           -105 <= Node.val <= 105
           All Nodes will have unique values.
        
    */

    public static TreeNode Solution(TreeNode root, TreeNode p)
    {
        TreeNode successor = null;

        while (root is not null)
        {
            if (p.val < root.val)
            {
                successor = root;
                root = root.left;
            }
            else
            {
                root = root.right;
            }
        }

        return successor;
    }
        
    public class TreeNode 
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int value)
        {
            val = value;
        }

        public TreeNode(int value, TreeNode left = null, TreeNode right = null)
        {
            val = value;
            this.left = left;
            this.right = right;
        }
    }
}