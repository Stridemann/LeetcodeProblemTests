public class Find_All_Anagrams_in_a_String
{
    [Theory]
    [InlineData("cbaebabacd", "abc", new[] { 0, 6 })]
    [InlineData("abacbabc", "abc", new[] { 1, 2, 3, 5 })]
    [InlineData("abab", "ab", new[] { 0, 1, 2 })]
    [InlineData("aaaaaaaaaa", "aaaaaaaaaaaaa", new int[] { })]
    public void Test(string s, string p, int[] expected)
    {
        var sol = new Solution();
        var result = sol.FindAnagrams(s, p);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    private int[] _charArr;
    private int _diff;

    public IList<int> FindAnagrams(string s, string p)
    {
        if (p.Length > s.Length)
            return new List<int>();

        var result = new List<int>();
        _charArr = new int[26];

        foreach (var pChar in p)
        {
            Decr(pChar);
        }

        for (var i = 0; i < p.Length; i++)
        {
            Inc(s[i]);
        }

        var leftInd = 0;
        var rightInd = p.Length - 1;

        while (true)
        {
            if (_diff == 0)
            {
                result.Add(leftInd);
            }

            if (rightInd >= s.Length - 1)
                break;

            var decrChar = s[leftInd++];
            var incChar = s[++rightInd];
            Decr(decrChar);
            Inc(incChar);
        }

        return result;
    }

    private void Decr(char ch)
    {
        switch (System.Threading.Interlocked.Decrement(ref _charArr[ch - 'a']))
        {
            case 0:
                _diff--;

                return;
            case -1:
                _diff++;

                return;
        }
    }

    private void Inc(char ch)
    {
        switch (System.Threading.Interlocked.Increment(ref _charArr[ch - 'a']))
        {
            case 0:
                _diff--;

                return;
            case 1:
                _diff++;

                return;
        }
    }
}