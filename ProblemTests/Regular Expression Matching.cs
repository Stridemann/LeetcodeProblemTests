public class UnitTest1
{
    [Theory]
    [InlineData("a", "aa", false)]
    [InlineData("aa", "a", false)]
    [InlineData("aa", "a*", true)]
    [InlineData("a", "ab", false)]
    [InlineData("a", "ab*", true)]
    [InlineData("aa", "aabb*", false)]
    [InlineData("a", "ab*a", false)]
    [InlineData("aaabbb", ".*", true)]
    [InlineData("mississippi", "mis*is*ip*.", true)]
    [InlineData("ab", ".*c", false)]
    [InlineData("abc", ".*c", true)]
    [InlineData("aaa", "aaaa", false)]
    [InlineData("aaa", "a*a", true)]
    [InlineData("aaa", "ab*a*c*a", true)]
    [InlineData("aaa", "ab*a", false)]
    public void Test1(string s, string p, bool result)
    {
        var sol = new Solution();
        sol.IsMatch(s, p).ShouldBe(result);
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
                dp[0, pi] = dp[0, pi - 2];
            }
        }

        for (int si = 1; si <= m; si++)
        {
            for (int pi = 1; pi <= n; pi++)
            {
                var p1 = p[pi - 1];
                var s1 = s[si - 1];

                ref bool final = ref dp[si, pi];

                if (s1 == p1 || p1 == '.')
                {
                    final = dp[si - 1, pi - 1];
                }
                else if (p1 == '*')
                {
                    final = dp[si, pi - 2];

                    if (p[pi - 2] == '.' || p[pi - 2] == s[si - 1])
                    {
                        final = final || dp[si - 1, pi];
                    }
                }
            }
        }

        return dp[m, n];
    }
}