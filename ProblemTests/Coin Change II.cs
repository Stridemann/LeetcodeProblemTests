public class Coin_Change_II
{
	[Theory]
	[InlineData(new[] { 1, 2, 5 }, 5, 4)]
	[InlineData(new[] { 2 }, 3, 0)]
	[InlineData(new[] { 10 }, 10, 1)]
	public void Test(
		int[] nums,
		int target,
		int expected)
	{
		var s = new Solution();
		var result = s.Change(target, nums);
		result.ShouldBe(expected);
	}
}

public class Solution
{
	public int Change(int amount, int[] coins)
	{
		int[] dp = new int[amount + 1];
		dp[0] = 1;

		foreach (var coin in coins)
		{
			for (int i = 1; i <= amount; i++)
			{
				if (coin <= i)
				{
					dp[i] += dp[i - coin];
				}
			}
		}

		return dp[amount];
	}
}


/*
 * 
 * public class Solution
   {
   public int Change(int amount, int[] coins)
   {
   var dp = new int[coins.Length][];
   for (int i = 0; i < coins.Length; i++)
   {
   dp[i] = new int[amount + 1];
   dp[i][0] = 1;
   }
   
   for (int c = coins.Length - 1; c >= 0; c--)
   {
   var rowY = dp[c];
   for (int x = 1; x < amount + 1; x++)
   {
   ref int cur = ref rowY[x];
   
   var indexMax = x - coins[c];
   if (indexMax >= 0)
   {
   cur += rowY[indexMax];
   }
   
   if (c < coins.Length - 1)
   cur += dp[c + 1][x];
   }
   }
   
   return dp[0][^1];
   }
   }
*/