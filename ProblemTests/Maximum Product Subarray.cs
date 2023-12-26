namespace DefaultNamespace;

public class Maximum_Product_Subarray
{
	[Theory]
	[InlineData(new[] { 2, 3, -2, 4 }, 6)]
	[InlineData(new[] { -2, 0, -1 }, 0)]
	[InlineData(new[] { -2, 3, -4 }, 24)]
	[InlineData(new[] { 6, -3, 5, 4, 2, 3 }, 120)]
	[InlineData(new[] { -2 }, -2)]
	public void Test(int[] nums, int expected)
	{
		var s = new Solution();
		var result = s.MaxProduct(nums);
		result.ShouldBe(expected);
	}
}

public class Solution
{
	public int MaxProduct(int[] nums)
	{
		var maxProduct = nums.Max();
		(int curMin, int curMax) = (1, 1);

		foreach (var n in nums)
		{
			var tmp = curMax * n;

			curMax = Math.Max(n, Math.Max(n * curMin, n * curMax));
			curMin = Math.Min(n, Math.Min(n * curMin, tmp));

			maxProduct = Math.Max(maxProduct, curMax);
		}

		return maxProduct;
	}
}