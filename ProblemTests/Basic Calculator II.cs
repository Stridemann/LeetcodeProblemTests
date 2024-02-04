using System;

public class Basic_Calculator_II
{
	[Theory]
	[InlineData("3+2*2", 7)]
	[InlineData("3+2*2+2", 9)]
	[InlineData("0-2147483647", -2147483647)]
	[InlineData("14/3*2", 8)]
	public void Test(string expr, int expected)
	{
		var s = new Solution();
		var result = s.Calculate(expr);
		result.ShouldBe(expected);
	}
}

public class Solution
{
	public int Calculate(string s)
	{
		s = s.Trim();
		var sSpan = s.AsSpan();

		long GetSumNum(ref int i, ref ReadOnlySpan<char> sSpan)
		{
			var number = GetNextNum(ref i, ref sSpan);

			while (true)
			{
				while (i < s.Length && s[i] == ' ')
				{
					i++;
				}

				if (i < s.Length - 1)
				{
					if (s[i] == '*')
					{
						i++;
						var nextMult = GetNextNum(ref i, ref sSpan);
						number *= nextMult;
					}
					else if (s[i] == '/')
					{
						i++;
						var nextMult = GetNextNum(ref i, ref sSpan);
						number /= nextMult;
					}
					else
					{
						break;
					}
				}
				else
				{
					return number;
				}
			}

			return number;
		}

		long GetNextNum(ref int i, ref ReadOnlySpan<char> sSpan)
		{
			int? numStart = null;
			long number = 0;
			for (; i < s.Length; i++)
			{
				var c = s[i];
				if (c == ' ') continue;

				if (char.IsDigit(c))
				{
					if (!numStart.HasValue)
						numStart = i;

					if (i == s.Length - 1)
					{
						number = int.Parse(sSpan.Slice(numStart.Value));
						i++;
					}
				}
				else
				{
					number = int.Parse(sSpan.Slice(numStart.Value, i - numStart.Value));
					break;
				}
			}

			return number;
		}

		var i = 0;
		long result = GetSumNum(ref i, ref sSpan);
		for (; i < s.Length;)
		{
			var c = s[i];
			if (c == ' ') continue;

			var newC = s[i];
			if (newC == '+')
			{
				i++;
				result += GetSumNum(ref i, ref sSpan);
			}
			else if (newC == '-')
			{
				i++;
				result -= GetSumNum(ref i, ref sSpan);
			}
			else
			{
				throw new Exception("WTF");
			}
		}

		return (int)result;
	}
}