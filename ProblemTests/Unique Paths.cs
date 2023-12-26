namespace DefaultNamespace;

public class Unique_Paths
{
	[Theory]
	[InlineData(3, 7, 28)]
	[InlineData(3, 2, 3)]
	public void Test(
		int m,
		int n,
		int expected)
	{
		var s = new Solution();
		var result = s.UniquePaths(m, n);
		result.ShouldBe(expected);
	}
}

public class Solution
{
	public int UniquePaths(int h, int w)
	{
		if (h == 1 || w == 1)
			return 1;

		var dp = new int[h, w];
		for (var x = 1; x < w; x++)
		{
			dp[0, x] = 1;
		}

		for (var y = 1; y < h; y++)
		{
			dp[y, 0] = 1;

			for (var x = 1; x < w; x++)
			{
				dp[y, x] = dp[y - 1, x] + dp[y, x - 1];
			}
		}

		return dp[h - 1, w - 1];
	}
}