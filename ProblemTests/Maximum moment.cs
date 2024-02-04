using Xunit;

public class Maximum_moment
{
	[Theory]
	[InlineData("2?:00", 20)]
	public void Test(string a, int expected)
	{
		var s = new Solution();
		s.MaximumMoment(a).ShouldBe(expected);
	}
}


class Solution
{
	public string MaximumMoment(string time)
	{
		var sb = new System.Text.StringBuilder(time);
		var first = time[0];
		var second = time[1];

		var noSecond = second == '?';

		if (first == '?')
		{
			if (second <= '3' || noSecond)
			{
				sb[0] = '2';
			}
			else
			{
				sb[0] = '1';
			}
		}

		if (noSecond)
		{
			if (sb[0] == '2')
			{
				sb[1] = '3';
			}
			else
			{
				sb[1] = '9';
			}
		}

		if (time[^2] == '?')
		{
			sb[^2] = '5';
		}

		if (time[^1] == '?')
		{
			sb[^1] = '9';
		}

		return sb.ToString();
	}
}