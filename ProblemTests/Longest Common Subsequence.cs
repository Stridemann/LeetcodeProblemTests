namespace DefaultNamespace;

public class Longest_Common_Subsequence
{
	[Theory]
	[InlineData("abcde", "ace", 3)]
	[InlineData("abc", "def", 0)]
	[InlineData("ezupkr", "ubmrapg", 2)]
	[InlineData("acef", "aefcfef", 4)]
	[InlineData("bsbininm", "jmjkbkjkv", 1)]
	public void Test(
		string str1,
		string str2,
		int expected)
	{
		var s = new Solution();
		var result = s.LongestCommonSubsequence(str1, str2);
		result.ShouldBe(expected);
	}
}

public class Solution
{
	public int LongestCommonSubsequence(string yCymb, string xCymb)
	{
		var dp = new int[yCymb.Length + 1][];
		for (var i = 0; i < dp.Length; i++) 
			dp[i] = new int[xCymb.Length + 1];

		for (var y = yCymb.Length - 1; y >= 0; y--)
		{
			var yRow = dp[y];

			for (var x = xCymb.Length - 1; x >= 0; x--)
			{
				ref var cellVal = ref yRow[x];

				if (yCymb[y] == xCymb[x])
				{
					cellVal = dp[y + 1][x + 1] + 1;
				}
				else
				{
					cellVal = Math.Max(yRow[x + 1], dp[y + 1][x]);
				}
			}
		}

		return dp[0][0];
	}
}