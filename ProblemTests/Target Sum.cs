public class Target_Sum
{
	[Theory]
	[InlineData(new int[] { 1, 1, 1, 1, 1 }, 3, 5)]
	[InlineData(new int[] { 1 }, 1, 1)]
	public void Test(
		int[] arr,
		int target,
		int expected)
	{
		var s = new Solution();
		var result = s.FindTargetSumWays(arr, target);
		result.ShouldBe(expected);
	}
}

public class Solution
{
	public int FindTargetSumWays(int[] nums, int target)
	{
		var dp = new Dictionary<(int, int), int>();

		int Dfs(int index, int value)
		{
			if (index >= nums.Length)
			{
				if (value == target)
					return 1;
				return 0;
			}
			var key = (index, value);

			if(dp.TryGetValue(key, out var val))
				return val;

			val = Dfs(index + 1, value + nums[index]) + Dfs(index + 1, value - nums[index]);
			dp[key] = val;
			return val;
		}

		return Dfs(0, 0);
	}
}