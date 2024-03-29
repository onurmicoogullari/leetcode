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

    private Node _head = new Node();
    private Node _tail = new Node();
    private Dictionary<int, Node> _cache;
    private int _cap;

    public LRUCache(int capacity)
    {
        _cache = new Dictionary<int, Node>(capacity);
        _cap = capacity;
        _head.next = _tail;
        _tail.prev = _head;
    }
    
    public int Get(int key)
    {
        int result = -1;
        
        if (_cache.TryGetValue(key, out Node node))
        {
            result = node.val;
            Remove(node);
            Add(node);
        }

        return result;
    }
    
    public void Put(int key, int value) {
        if (_cache.TryGetValue(key, out Node node))
        {
            Remove(node);
            node.val = value;
            Add(node);
        }
        else
        {
            if (_cache.Count == _cap)
            {
                _cache.Remove(_tail.prev.key);
                Remove(_tail.prev);
            }
            
            Node nodeToAdd = new Node(key, value);
            _cache.Add(key, nodeToAdd);
            Add(nodeToAdd);
        }
    }

    private void Add(Node nodeToAdd)
    {
        // Take the current most recent node
        Node mostRecentNode = _head.next;
        
        // Assign the new most recent nodes 'next' to the old most recent node
        nodeToAdd.next = mostRecentNode;
        
        // Assign the old most recent nodes 'prev' to the new most recent node
        mostRecentNode.prev = nodeToAdd;
        
        // Assign the 'dummy heads' 'next' to the new most recent node
        _head.next = nodeToAdd;
        
        // Assign the new most recent nodes 'prev' to the 'dummy heads' 'prev'
        nodeToAdd.prev = _head;
    }

    private void Remove(Node nodeToRemove)
    {
        // Take the last recent nodes 'next' and 'prev' nodes
        Node next = nodeToRemove.next;
        Node prev = nodeToRemove.prev;
        
        // Link the above nodes to the new last recent node
        next.prev = prev;
        prev.next = next;
    }
    
    class Node
    {
        public int key;
        public int val;
        public Node prev;
        public Node next;

        public Node()
        {
            
        }
        
        public Node(int key, int val)
        {
            this.key = key;
            this.val = val;
        }
    }
}