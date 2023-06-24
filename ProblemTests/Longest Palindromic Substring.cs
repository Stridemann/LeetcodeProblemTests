using Shouldly;

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
            return s;
        var sbstrInd = 0;
        var sbstrLen = 1;

        for (int i = 0; i < s.Length - 1; i++)
        {
            var testOdd = true;
            var testPair = true;

            for (int chkOffst = 1; chkOffst <= s.Length / 2; chkOffst++)
            {
                var rt = i + chkOffst;

                if (rt >= s.Length)
                    break;

                var lt = i - chkOffst;
                var lt2 = i - chkOffst + 1;

                var found = false;

                if (lt2 >= 0 && s[lt2] == s[rt] && (chkOffst == 1 || testOdd))
                {
                    var len = rt - lt2 + 1;

                    if (sbstrLen < len)
                    {
                        sbstrInd = lt2;
                        sbstrLen = len;
                    }

                    found = true;
                }
                else
                {
                    testOdd = false;
                }

                if (lt >= 0 && s[lt] == s[rt] && (chkOffst == 1 || testPair))
                {
                    var len = rt - lt + 1;

                    if (sbstrLen < len)
                    {
                        sbstrInd = lt;
                        sbstrLen = len;
                    }

                    found = true;
                }
                else
                {
                    testPair = false;
                }

                if (!found)
                    break;
            }
        }

        if (sbstrInd == -1)
            return string.Empty;

        return s.Substring(sbstrInd, sbstrLen);
    }
}
