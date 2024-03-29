using FluentAssertions;
using LeetCode.Solutions.Medium;

namespace LeetCode.Solutions.Tests.Unit.Medium;

public class LRUCacheTests
{
    [Fact]
    public void LRUCache_RemovesLastRecentlyUsed_WhenCapacityIsOverflowed()
    {
        LRUCache lRUCache = new LRUCache(2);
        lRUCache.Put(1, 1); // cache is {1=1}
        lRUCache.Put(2, 2); // cache is {1=1, 2=2}
        int get1 = lRUCache.Get(1); // return 1
        lRUCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
        int get2 = lRUCache.Get(2); // returns -1 (not found, because it was evicted)
        lRUCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
        int get1Again = lRUCache.Get(1); // return -1 (not found, because it was evicted)
        int get3 = lRUCache.Get(3); // return 3
        int get4 = lRUCache.Get(4); // return 4
        int get2Again = lRUCache.Get(2); // return -1 (not found, because it was evicted)

        get1.Should().Be(1);
        get2.Should().Be(-1);
        get1Again.Should().Be(-1);
        get3.Should().Be(3);
        get4.Should().Be(4);
        get2Again.Should().Be(-1);
    }
}