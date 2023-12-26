namespace DefaultNamespace;

public class Longest_Increasing_Subsequence
{
	[Theory]
	[InlineData(new[] { 10, 9, 2, 5, 3, 7, 101, 18 }, 4)]
	[InlineData(new[] { 0, 1, 0, 3, 2, 3 }, 4)]
	[InlineData(new[] { 7, 7, 7, 7, 7, 7, 7 }, 1)]
	public void Test(int[] nums, int expected)
	{
		var s = new Solution();
		var result = s.LengthOfLIS(nums);
		result.ShouldBe(expected);
	}
}

public class Solution
{
	public int LengthOfLIS(int[] nums)
	{
		var length = 1;
		var dp = new int[nums.Length];
		for (int h = 0; h < dp.Length; h++)
		{
			dp[h] = 1;
		}

		for (int curI = 0; curI < nums.Length; curI++)
		{
			for (int nextI = curI + 1; nextI < nums.Length; nextI++)
			{
				if (nums[nextI] > nums[curI])
				{
					dp[nextI] = Math.Max(dp[nextI], dp[curI] + 1);
					if (length < dp[nextI])
						length = dp[nextI];
				}
			}
		}

		return length;
	}
}