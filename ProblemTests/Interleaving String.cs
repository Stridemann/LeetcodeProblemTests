public class Interleaving_String
{
	[Theory]
	[InlineData(
		"aabcc",
		"dbbca",
		"aadbbcbcac",
		true)]
	[InlineData(
		"",
		"",
		"",
		true)]
	[InlineData(
		"a",
		"",
		"a",
		true)]
	[InlineData(
		"aabcc",
		"dbbca",
		"aadbbbaccc",
		true)]
	public void Test(
		string s1,
		string s2,
		string s3,
		bool expected)
	{
		var s = new Solution();
		var result = s.IsInterleave(s1, s2, s3);
		result.ShouldBe(expected);
	}
}

public class Solution
{
	public bool IsInterleave(
		string s1,
		string s2,
		string s3)
	{
		if (s1.Length + s2.Length != s3.Length)
			return false;
		var dp = new Dictionary<(int, int), bool>();

		bool Dfs(int ind1, int ind2)
		{
			var key = (ind1, ind2);
			if (dp.TryGetValue(key, out var val))
				return val;

			if (ind1 < s1.Length && s1[ind1] == s3[ind1 + ind2])
			{
				val = Dfs(ind1 + 1, ind2);
				if (val)
				{
					return true;
				}
			}

			if (ind2 < s2.Length && s2[ind2] == s3[ind1 + ind2])
			{
				val = Dfs(ind1, ind2 + 1);
				if (val)
				{
					return true;
				}
			}

			dp.Add(key, ind1 + ind2 == s3.Length);

			return ind1 + ind2 == s3.Length;
		}

		return Dfs(0, 0);
	}
}