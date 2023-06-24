namespace ProblemTests.Unused
{
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
        public void Test1(string s, string p, bool result)
        {
            var sol = new Solution();
            Assert.Equal(result, sol.IsMatch(s, p));
        }

        public class Solution
        {
            public bool IsMatch(string s, string p)
            {
                var si = 0;
                int pi = 0;

                for (; pi < p.Length; pi++)
                {
                    var pattChar = p[pi];
                    var repeat = pi < p.Length - 1 && p[pi + 1] == '*';
                    var any = pattChar == '.';
                    char? waitNextChar = null;

                    if (repeat && pi < p.Length - 2)
                    {
                        waitNextChar = p[pi + 2];
                    }

                    if (repeat)
                        pi++;

                    if (repeat && any && !waitNextChar.HasValue)
                        return true;

                    if (si >= s.Length)//if string is ended
                    {
                        if (!any && !repeat)//if we wait some exact cymbol but string ended
                            return false;
                        continue;
                    }

                    if (repeat)
                    {
                        if (waitNextChar.HasValue)
                        {
                            if (pattChar == waitNextChar.Value)//special case "a*a"
                            {
                                while (s[si] == waitNextChar.Value && si < s.Length - 1 && s[si + 1] == waitNextChar.Value)
                                {
                                    si++;

                                    if (si >= s.Length)
                                    {
                                        return false; //expect char after repeating, but string is ended
                                    }
                                }
                            }
                            else
                            {
                                if (any)
                                {
                                    while (s[si] != waitNextChar.Value)//wait for exact cymbol
                                    {
                                        si++;

                                        if (si >= s.Length)
                                        {
                                            return false; //expect char after repeating, but string is ended
                                        }
                                    }
                                }
                                else
                                {
                                    while (s[si] == pattChar)
                                    {
                                        si++;

                                        if (si >= s.Length)
                                        {
                                            return false; //expect char after repeating, but string is ended
                                        }

                                        if (s[si] == waitNextChar.Value)
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            while (s[si] == pattChar)//'any' is already processed abowe
                            {
                                si++;

                                if (si >= s.Length)
                                {
                                    break; //ends with "aaa" with pattern "a*"
                                }
                            }
                        }
                    }
                    else
                    {
                        if (s[si] != pattChar && !any)
                        {
                            return false;
                        }

                        si++;
                    }
                }

                return pi == p.Length && si == s.Length;
            }
        }
    }
}
