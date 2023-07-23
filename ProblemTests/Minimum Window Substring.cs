using System.Diagnostics;

public class Minimum_Window_Substring
{
    [Theory]
    [InlineData("ADOBECODEBANC", "ABC", "BANC")]
    [InlineData("a", "a", "a")]
    [InlineData("a", "aa", "")]
    [InlineData("cabwefgewcwaefgcf", "cae", "cwae")]
    [InlineData("cgklivwehljxrdzpfdqsapogwvjtvbzahjnsejwnuhmomlfsrvmrnczjzjevkdvroiluthhpqtffhlzyglrvorgnalk", "mqfff", "fsrvmrnczjzjevkdvroiluthhpqtff")]
    public void Test(string s, string t, string expected)
    {
        var sol = new Solution();
        var result = sol.MinWindow(s, t);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    private readonly int[] _charArr = new int['z' - 'A' + 1];
    private int _diff;

    public string MinWindow(string s, string t)
    {
        Array.Fill(_charArr, int.MinValue);

        foreach (var tCh in t)
        {
            ref int cnt = ref _charArr[tCh - 'A'];

            if (cnt == int.MinValue)
                cnt = 0;

            Decr(tCh);
        }

        var left = 0;
        var right = 0;
        var minIdx = -1;
        var minLen = int.MaxValue;

        do
        {
            if (_diff > 0)
            {
                if (right == s.Length)
                    break;
                var ch = s[right++];
                Inc(ch);
            }
            else if (_diff == 0)
            {
                var len = right - left;

                if (minLen > len)
                {
                    minLen = len;
                    minIdx = left;
                }

                if (left == s.Length)
                    break;
                var ch = s[left++];
                Decr(ch);
            }
            else
            {
                if (left == s.Length)
                    break;
                var ch = s[left++];
                Decr(ch);
            }
        } while (left < right);

        if (minIdx == -1)
            return string.Empty;

        return s.Substring(minIdx, minLen);
    }
    
    private void Decr(char ch)
    {
        var ind = ch - 'A';
        ref int val = ref _charArr[ind];

        if (val == int.MinValue)
            return;
        val--;

        if (val == -1)
        {
            _diff++;
        }
    }
    
    private void Inc(char ch)
    {
        var ind = ch - 'A';
        ref int val = ref _charArr[ind];

        if (val == int.MinValue)
            return;
        val++;

        if (val == 0)
        {
            _diff--;
        }
    }
}
