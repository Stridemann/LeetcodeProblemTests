using Microsoft.VisualBasic;

namespace DefaultNamespace;

public class Best_Time_to_Buy_and_Sell_Stock_with_Cooldown
{
	[Theory]
	[InlineData(new int[] { 1, 2, 3, 0, 2 }, 3)]
	public void Test(int[] arr, int expected)
	{
		var s = new Solution();
		var result = s.MaxProfit(arr);
		result.ShouldBe(expected);
	}
}

public class Solution
{
	public int MaxProfit(int[] prices)
	{
		var dict = new Dictionary<(int, bool), int>();

		int Dfs(int index, bool canBuy)
		{
			if (index >= prices.Length)
				return 0;
			if (dict.TryGetValue((index, canBuy), out var val))
				return val;

			var cooldown = Dfs(index + 1, canBuy);
			if (canBuy)
			{
				var buy = Dfs(index + 1, !canBuy) - prices[index];
				dict[(index, canBuy)] = val = Math.Max(buy, cooldown);
			}
			else
			{
				var sell = Dfs(index + 2, !canBuy) + prices[index];
				dict[(index, canBuy)] = val = Math.Max(sell, cooldown);
			}

			return val;
		}

		return Dfs(0, true);
	}
}