public class Longest_Palindromic_Substring
{
    [Theory]
    [InlineData("babad", "bab")]
    [InlineData("cbbd", "bb")]
    [InlineData("ac", "a")]
    [InlineData("bb", "bb")]
    [InlineData("ccc", "ccc")]
    [InlineData("aaaa", "aaaa")]
    [InlineData("aacabdkacaa", "aca")]
    public void Test(string input, string expected)
    {
        var s = new Solution();
        var result = s.LongestPalindrome(input);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public string LongestPalindrome(string s)
    {
        if (s.Length == 1)
        {
            return s;
        }
        var T = new char[s.Length * 2 + 3];
        T[0] = '$';
        T[s.Length * 2 + 2] = '@';
        for (var i = 0; i < s.Length; i++)
        {
            T[2 * i + 1] = '#';
            T[2 * i + 2] = s[i];
        }
        T[s.Length * 2 + 1] = '#';
        ///////////////////////////////////
        var p = new int[T.Length];
        int center = 0, right = 0;
        for (var i = 1; i < T.Length - 1; i++)
        {
            var mirr = 2 * center - i;
            if (i < right)
                p[i] = Math.Min(right - i, p[mirr]);
            while (T[i + 1 + p[i]] == T[i - (1 + p[i])])
                p[i]++;

            if (i + p[i] > right)
            {
                center = i;
                right = i + p[i];
            }
        }
        ///////////////////////////////////
        var length = 0;
        center = 0;
        for (var i = 1; i < p.Length - 1; i++)
        {
            if (p[i] > length)
            {
                length = p[i];
                center = i;
            }
        }
        var startIndex = (center - 1 - length) / 2;
        return s.Substring(startIndex, length);
    }
}
