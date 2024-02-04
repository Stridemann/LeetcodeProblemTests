using System;

public class Burst_Balloons
{
	[Theory]
	[InlineData(new int[] { 3, 1, 5, 8 }, 167)]
	[InlineData(new int[] { 1, 5 }, 10)]
	public void Test(int[] arr, int expected)
	{
		var s = new Solution();
		var result = s.MaxCoins(arr);
		result.ShouldBe(expected);
	}
}

public class Solution
{
	private int[,] _dp;
	private int[] _nums;

	public int MaxCoins(int[] nums)
	{
		var n = nums.Length + 2;
		_dp = new int[n, n];
		_nums = new int[n];
		_nums[0] = 1;
		_nums[^1] = 1;
		for (int i = 1; i < n - 1; i++) _nums[i] = nums[i - 1];

		return Dfs(1, nums.Length);
	}

	private int Dfs(int l, int r)
	{
		if (l > r)
			return 0;

		ref int cached = ref _dp[l, r];
		if (cached != 0)
		{
			return cached;
		}

		cached = 0;

		for (int i = l; i < r + 1; i++)
		{
			var coins = _nums[l - 1] * _nums[i] * _nums[r + 1];
			coins += Dfs(l, i - 1) + Dfs(i + 1, r);
			cached = Math.Max(coins, cached);
		}

		return cached;
	}
}

//public class Solution
//{
//	private LinkedList<int> _list;

//	public int MaxCoins(int[] nums)
//	{
//		_list = new LinkedList<int>(nums);

//		return Dfs();
//	}

//	private int Dfs()
//	{
//		if (_list.Count == 0)
//			return 0;
//		var result = 0;

//		for (var iter = _list.First; iter != null; iter = iter.Next)
//		{
//			var score = iter.Value;
//			score *= iter.Next?.Value ?? 1;
//			score *= iter.Previous?.Value ?? 1;

//			var prev = iter.Previous;
//			_list.Remove(iter);
//			var cur = Dfs() + score;
//			if (result < cur)
//				result = cur;
//			if (prev == null)
//				_list.AddFirst(iter);
//			else
//				_list.AddAfter(prev, iter);
//		}

//		return result;
//	}
//}