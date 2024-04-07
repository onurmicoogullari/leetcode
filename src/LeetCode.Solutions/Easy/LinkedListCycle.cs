namespace LeetCode.Solutions.Easy;

public static class LinkedListCycle
{
    /*
        141. Linked List Cycle
        Link: https://leetcode.com/problems/linked-list-cycle/description/
        
        Given head, the head of a linked list, determine if the linked list has a cycle in it.
        There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to. Note that pos is not passed as a parameter.
        Return true if there is a cycle in the linked list. Otherwise, return false.
        
        Example 1:
        
            Input: head = [3,2,0,-4], pos = 1
            Output: true
            Explanation: There is a cycle in the linked list, where the tail connects to the 1st node (0-indexed).
            
        Example 2:
        
            Input: head = [1,2], pos = 0
            Output: true
            Explanation: There is a cycle in the linked list, where the tail connects to the 0th node.
            
        Example 3:
        
            Input: head = [1], pos = -1
            Output: false
            Explanation: There is no cycle in the linked list.
            
        Constraints:
       
           The number of the nodes in the list is in the range [0, 104].
           -105 <= Node.val <= 105
           pos is -1 or a valid index in the linked-list.
    */

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public static bool BruteForce(ListNode head)
    {
        HashSet<ListNode> nodes = new();
        ListNode current = head;

        while (current != null)
        {
            if (!nodes.Add(current))
            {
                return true;
            }

            current = current.next;
        }

        return false;
    }

    public static bool Efficient(ListNode head)
    {
        // This method is called Floyd's Tortoise and Hare (fast one ALWAYS catches slow one if it's a endless loop).

        ListNode slow = head;
        ListNode fast = head;
        
        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast)
            {
                return true;
            }
        }

        return false;
    }
}