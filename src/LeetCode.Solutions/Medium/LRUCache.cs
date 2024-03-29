namespace LeetCode.Solutions.Medium;

public class LRUCache
{
    /*
        146. LRU Cache
        Link: https://leetcode.com/problems/lru-cache/description/

        Design a data structure that follows the constraints of a Least Recently Used (LRU) cache.

        Implement the LRUCache class:

        LRUCache(int capacity) Initialize the LRU cache with positive size capacity.
        int get(int key) Return the value of the key if the key exists, otherwise return -1.
        void put(int key, int value) Update the value of the key if the key exists. Otherwise, add the key-value pair to the cache. If the number of keys exceeds the capacity from this operation, evict the least recently used key.
        The functions get and put must each run in O(1) average time complexity.



        Example 1:

           Input
           ["LRUCache", "put", "put", "get", "put", "get", "put", "get", "get", "get"]
           [[2], [1, 1], [2, 2], [1], [3, 3], [2], [4, 4], [1], [3], [4]]
           Output
           [null, null, null, 1, null, -1, null, -1, 3, 4]

           Explanation
           LRUCache lRUCache = new LRUCache(2);
           lRUCache.put(1, 1); // cache is {1=1}
           lRUCache.put(2, 2); // cache is {1=1, 2=2}
           lRUCache.get(1);    // return 1
           lRUCache.put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
           lRUCache.get(2);    // returns -1 (not found)
           lRUCache.put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
           lRUCache.get(1);    // return -1 (not found)
           lRUCache.get(3);    // return 3
           lRUCache.get(4);    // return 4


        Constraints:

           1 <= capacity <= 3000
           0 <= key <= 104
           0 <= value <= 105
           At most 2 * 105 calls will be made to get and put.
    */
    
    private int _cap;
    private DoubleLinkedList _list = new DoubleLinkedList();
    private Dictionary<int, ListNode> _cache;
    
    public LRUCache(int capacity)
    {
        _cap = capacity;
        _cache = new Dictionary<int, ListNode>(_cap);
    }

    public void Put(int key, int value)
    {
        // Update key if it exists
        // If it doesn't, add it to cache
        // If capacity is full, remove the least recently used (LRU) before adding the new one
        
        if (_cache.TryGetValue(key, out ListNode? currentNode))
        { 
            _list.Remove(currentNode);
            currentNode.Value = value;
            _list.Add(currentNode);
        }
        else
        {
            if (_cache.Count == _cap)
            {
                ListNode lruNode = _list.LastOrDefault()!;
                _list.Remove(lruNode);
                _cache.Remove(lruNode.Key);
            }
            
            ListNode newNode = new ListNode(key, value);
            _list.Add(newNode);
            _cache.Add(key, newNode);
        }
       
    }
    
    public int Get(int key)
    {
        int result = -1;

        if (_cache.TryGetValue(key, out ListNode? node))
        {
            result = node.Value;
            _list.Remove(node);
            _list.Add(node);
        }

        return result;
    }
    
    public class DoubleLinkedList
    {
        private readonly ListNode _head;
        private readonly ListNode _tail;

        public DoubleLinkedList()
        {
            _head = new ListNode(0, 0);
            _tail = new ListNode(0, 0);
        
            _head.Next = _tail;
            _tail.Prev = _head;
        }

        public void Add(ListNode newNode)
        {
            // Get the most recent node
            ListNode mostRecent = _head.Next;
        
            // Push the most recent node forward, making the new node the most recent
            newNode.Next = mostRecent;
            mostRecent.Prev = newNode;

            // Point the head to the new most recent node
            _head.Next = newNode;
            newNode.Prev = _head;
        }

        public void Remove(ListNode nodeToRemove)
        {
            ListNode next = nodeToRemove.Next;
            ListNode prev = nodeToRemove.Prev;

            next.Prev = prev;
            prev.Next = next;
        }

        public ListNode? LastOrDefault()
        {
            return _tail.Prev;
        }
    }
    
    public class ListNode
    {
        public int Key { get; set; }
        public int Value { get; set; }
        public ListNode Next { get; set; }
        public ListNode Prev { get; set; }

        public ListNode(int key, int val)
        {
            Key = key;
            Value = val;
        }
    }
}



