using Shouldly;

public class Longest_Substring_Without_Repeating_Characters
{
    [Theory]
    [InlineData("abcabcbb", 3)]
    [InlineData("bbbbb", 1)]
    [InlineData("pwwkew", 3)]
    [InlineData("dvdf", 3)]
    [InlineData("ibaz", 4)]
    public void Test(string input, int expected)
    {
        var s = new Solution();
        var result = s.LengthOfLongestSubstring(input);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        var cache = new int[0x7f];
        var maxLen = 0;
        var strStart = 0;

        for (var i = 0; i < s.Length; i++)
        {
            var c = s[i];
            var val = cache[c] - 1;

            if (val == -1 || val < strStart)
            {
                cache[c] = i + 1;
            }
            else
            {
                var curLen = i - strStart;

                if (maxLen < curLen)
                    maxLen = curLen;
                strStart = val + 1;
                cache[c] = i + 1;
            }
        }

        if (maxLen < s.Length - strStart)
            maxLen = s.Length - strStart;

        return maxLen;
    }
}
