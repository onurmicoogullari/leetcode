using FluentAssertions;

namespace LeetCode.Solutions.Tests.Unit.Easy;

public class BestTimeToBuyAndSellStockTests
{
    // Arrange
    public static IEnumerable<object[]> TestData
    {
        get
        {
            return new object[][]
            {
                new object[] { new int[] { 7,1,5,3,6,4 },  5 },
                new object[] { new int[] { 7,6,4,3,1 },  0 },
            };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Solution_ReturnsMaxProfit_GivenArrayWithStockPricePerDay(int[] prices, int expected)
    {
        // Act
        int result = Solutions.Easy.BestTimeToBuyAndSellStock.Solution(prices);
        
        // Assert
        result.Should().Be(expected);
    }
}