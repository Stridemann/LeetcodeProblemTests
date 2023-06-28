public class Best_Time_to_Buy_and_Sell_Stock
{
    [Theory]
    [InlineData(new[] { 7, 1, 5, 3, 6, 4 }, 5)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.MaxProfit(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        var maxProfit = 0;
        var cheapest = prices[0];

        for (int i = 1; i < prices.Length; i++)
        {
            var cur = prices[i];

            if (cur < cheapest)
                cheapest = cur;
            else if (maxProfit < cur - cheapest)
            {
                maxProfit = cur - cheapest;
            }
        }

        return maxProfit;
    }
}