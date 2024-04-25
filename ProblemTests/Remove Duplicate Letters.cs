using System.Text;

public class Remove_Duplicate_Letters
{
    [Theory]
    [InlineData("bcabc", "abc")]
    [InlineData("cbacdcbc", "acdb")]
    public void Test(string input, string expected)
    {
        var s = new Solution();
        var result = s.RemoveDuplicateLetters(input);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public string RemoveDuplicateLetters(string s)
    {
        var dict = new bool['z' - 'a' + 1];
        var min = int.MaxValue;
        var minCh = 'z';

        for (int i = 0; i < s.Length; i++)
        {
            var ch = s[i];

            if (ch < minCh)
            {
                minCh = ch;
                min = i;
            }

            dict[ch - 'a'] = true;
        }

        var sb = new StringBuilder();
        sb.Append(minCh);
        var curCh = 'a';

        for (char i = (char)(minCh + 1); i <= 'z' + 1; i++)
        {
            if (dict[i - 'a'])
            {
                curCh = i;

                break;
            }

            if (i == 'z')
            {
                return sb.ToString();
            }
        }

        for (var si = min + 1; si < s.Length; si++)
        {
            var ch = s[si];

            if (ch == curCh)
            {
                sb.Append(ch);

                for (char i = ++curCh; i <= 'z' + 1; i++)
                {
                    if (dict[i - 'a'])
                    {
                        curCh = i;

                        break;
                    }

                    if (i == 'z')
                    {
                        return sb.ToString();
                    }
                }
            }
        }

        return sb.ToString();
    }
}
