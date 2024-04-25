public class Best_Time_to_Buy_and_Sell_Stock_II
{
    [Theory]
    [InlineData(new int[] { 7, 1, 5, 3, 6, 4 }, 7)]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 4)]
    [InlineData(new int[] { 7, 6, 4, 3, 1 }, 0)]
    public void Test(int[] input, int expected)
    {
        var s = new Solution();
        var result = s.MaxProfit(input);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        var maxProfit = 0;

        for (var i = 1; i < prices.Length; i++)
        {
            var diff = prices[i] - prices[i-1];

            if (diff>0)
            {
                maxProfit += diff;
            }
        }

        return maxProfit;
    }
}
