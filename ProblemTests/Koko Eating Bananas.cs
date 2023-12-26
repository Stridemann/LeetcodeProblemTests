public class Koko_Eating_Bananas
{
	[Theory]
	[InlineData(new[] { 3, 6, 7, 11 }, 8, 4)]
	[InlineData(new[] { 30, 11, 23, 4, 20 }, 5, 30)]
	[InlineData(new[] { 30, 11, 23, 4, 20 }, 6, 23)]
	[InlineData(new[] { 30, 11, 23, 4, 20 }, 2, 500000000)]
	public void Test(
		int[] nums,
		int h,
		int expected)
	{
		var s = new Solution();
		var result = s.MinEatingSpeed(nums, h);
		result.ShouldBe(expected);
	}
}

public class Solution
{
	private int[] _piles;

	public int MinEatingSpeed(int[] piles, int h)
	{
		_piles = piles;
		var left = 1;
		var right = piles.Max();
		var result = right;

		while (left <= right)
		{
			var mid = (left + right) / 2;
			var hours = GetK(mid);

			if (hours <= h)
			{
				right = mid - 1;
				result = Math.Min(result, mid);
			}
			else
			{
				left = mid + 1;
			}
		}

		return result;
	}

	private long GetK(int k)
	{
		var result = 0L;

		foreach (var t in _piles)
		{
			result += (long)Math.Ceiling((double)t / k);
		}

		return result;
	}
}