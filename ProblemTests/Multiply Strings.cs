using System.Text;
using Shouldly;

public class ultiply_Strings

{
    [Theory]
    [InlineData("2", "3", "6")]
    [InlineData("10", "10", "100")]
    public void Test(string a, string b, string expected)
    {
        var s = new Solution();
        var result = s.RemoveNthFromEnd(a, b);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public string RemoveNthFromEnd(string a, string b)
    {
        var spanA = a.AsSpan();
        var spanB = b.AsSpan();
        var minStrLen = Math.Min(a.Length, b.Length);
        var sb = new StringBuilder(Math.Max(a.Length, b.Length) + minStrLen);
        var reminder = 0;

        for (int i = 0; i < minStrLen; i++)
        {
            var aInt = spanA[i] - '0';
            var bInt = spanB[i] - '0';
            var curMult = aInt * bInt;
            var mult = curMult + reminder;
            reminder = curMult / 10;
            sb.Insert(0, mult % 10);
        }

        return sb.ToString();
    }
}
