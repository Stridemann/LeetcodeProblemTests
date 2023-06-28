public class Wildcard_Matching
{
    [Theory]
    [InlineData("aa", "a", false)]
    [InlineData("aa", "*", true)]
    [InlineData("cb", "?a", false)]
    [InlineData("aaaaa", "aa*a", true)]
    [InlineData("abcabczzzde", "*abc???de*", true)]
    [InlineData("acdcb", "a*c?b", false)]
    [InlineData("adceb", "*a*b", true)]
    [InlineData("", "******", true)]
    [InlineData(
        "abbabaaabbabbaababbabbbbbabbbabbbabaaaaababababbbabababaabbababaabbbbbbaaaabababbbaabbbbaabbbbababababbaabbaababaabbbababababbbbaaabbbbbabaaaabbababbbbaababaabbababbbbbababbbabaaaaaaaabbbbbaabaaababaaaabb",
        "**aa*****ba*a*bb**aa*ab****a*aaaaaa***a*aaaa**bbabb*b*b**aaaaaaaaa*a********ba*bbb***a*ba*bb*bb**a*b*bb",
        false)]
    public void Test(string s, string p, bool expected)
    {
        var sol = new Solution();
        var result = sol.IsMatch(s, p);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public bool IsMatch(string s, string p)
    {
        int m = s.Length;
        int n = p.Length;

        var dp = new bool[m + 1, n + 1];
        dp[0, 0] = true;

        for (int pi = 1; pi <= n; pi++)
        {
            if (p[pi - 1] == '*')
            {
                dp[0, pi] = dp[0, pi - 1];
            }
        }

        for (int si = 1; si <= m; si++)
        {
            for (int pi = 1; pi <= n; pi++)
            {
                var p1 = p[pi - 1];
                var s1 = s[si - 1];

                ref bool final = ref dp[si, pi];

                if (s1 == p1 || p1 == '?')
                {
                    final = dp[si - 1, pi - 1];
                }
                else if (p1 == '*')
                {
                    final = dp[si - 1, pi - 1] || dp[si - 1, pi] || dp[si, pi - 1];
                }
            }
        }

        return dp[m, n];
    }
}
