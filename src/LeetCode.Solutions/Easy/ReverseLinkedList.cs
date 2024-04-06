namespace LeetCode.Solutions.Easy;

public static class ReverseLinkedList
{
    /*
        206. Reverse Linked List
        Link: https://leetcode.com/problems/reverse-linked-list/description/
        
        Given the head of a singly linked list, reverse the list, and return the reversed list.
    */
    
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val, ListNode next)
        {
            this.val = val;
            this.next = next;
        }
    }

    public static ListNode Recursively(ListNode head)
    {
        // Time complexity: O(n)
        // Space complexity: O(n)
        
        if (head == null || head.next == null)
        {
            return head;
        }

        ListNode reversed = Recursively(head.next);
        head.next.next = head;
        head.next = null;

        return reversed;
    }

    public static ListNode Iteratively(ListNode head)
    {
        // Time complexity: O(n)
        // Space complexity: O(1)
        
        ListNode prev = null;
        ListNode current = head;
        
        while (current != null)
        {
            ListNode next = current.next;
            current.next = prev;
            prev = current;
            current = next;
        }

        return prev;
    }
}