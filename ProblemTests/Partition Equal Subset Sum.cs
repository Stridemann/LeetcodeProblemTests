namespace DefaultNamespace;

public class Partition_Equal_Subset_Sum
{
	[Theory]
	[InlineData(new[] { 1, 5, 11, 5 }, true)]
	[InlineData(new[] { 1, 2, 3, 5 }, false)]
	[InlineData(new[] { 3, 3, 3, 4, 5 }, true)]
	public void Test(int[] nums, bool expected)
	{
		var s = new Solution();
		var result = s.CanPartition(nums);
		result.ShouldBe(expected);
	}
}

public class Solution
{
	public bool CanPartition(int[] nums)
	{
		var sum = nums.Sum();
		if (sum % 2 != 0)
		{
			return false;
		}

		return subSetSum(nums, sum / 2);
	}

	private bool subSetSum(int[] nums, int target)
	{
		var dp = new bool[nums.Length + 1, target + 1];

		for (var i = 0; i < nums.Length + 1; i++)
		{
			dp[i, 0] = true;
		}

		for (var i = 1; i < nums.Length + 1; i++)
		{
			for (var j = 1; j < target + 1; j++)
			{
				if (nums[i - 1] <= j)
				{
					dp[i, j] = dp[i - 1, j] || dp[i - 1, j - nums[i - 1]];
				}
				else
					dp[i, j] = dp[i - 1, j];
			}
		}

		return dp[nums.Length, target];
	}
}