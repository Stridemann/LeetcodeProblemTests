using Shouldly;
using Xunit;

public class Number_of_Substrings_with_All_Zeroes
{
	[Theory]
	[InlineData("00010011", 9)]
	public void Test(string a, int expected)
	{
		var s = new Solution();
		s.StringCount(a).ShouldBe(expected);
	}
}

class Solution
{
	public int StringCount(string str)
	{
		var total = 0;
		var current = 0;
		for (int i = 0; i < str.Length; i++)
		{
			if (str[i] == '0')
			{
				current++;
			}
			else
			{
				total += current * (current + 1) / 2;
				current = 0;
			}
		}
		total += current * (current + 1) / 2;
		return total;
	}
}