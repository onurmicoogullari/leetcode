using FluentAssertions;
using LeetCode.Solutions.Medium;

namespace LeetCode.Solutions.Tests.Unit.Medium;

public class LRUCacheTests
{
    [Fact]
    public void LRUCache_RemovesLastRecentlyUsed_WhenCapacityIsOverflowed()
    {
        LRUCache cache = new LRUCache(2);
        cache.Put(1, 1);
        cache.Put(2, 2);
        int get1 = cache.Get(1);
        cache.Put(3, 3);
        int get2 = cache.Get(2);
        cache.Put(4, 4);
        int get1Again = cache.Get(1);
        int get3 = cache.Get(3);
        int get4 = cache.Get(4);
        int get2Again = cache.Get(2);

        get1.Should().Be(1);
        get2.Should().Be(-1); // Removed, because it was last recently used
        get1Again.Should().Be(-1); // Removed, because it was last recently used
        get3.Should().Be(3);
        get4.Should().Be(4);
        get2Again.Should().Be(-1); // Removed, because it was last recently used
    }
}