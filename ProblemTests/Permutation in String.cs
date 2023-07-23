public class Permutation_in_String
{
    [Theory]
    [InlineData("ab", "eidbaooo", true)]
    [InlineData("ab", "eidboaoo", false)]
    public void Test(string input, string input2, bool expected)
    {
        var s = new Solution();
        var result = s.CheckInclusion(input, input2);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    private readonly int[] _charArr = new int[26];
    private int _diff;

    public bool CheckInclusion(string p, string s)
    {
        if (s.Length < p.Length)
            return false;

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
                return true;
            }

            if (rightInd >= s.Length - 1)
                break;

            var decrChar = s[leftInd++];
            var incChar = s[++rightInd];
            Decr(decrChar);
            Inc(incChar);
        }

        return false;
    }

    private void Decr(char ch)
    {
        switch (--_charArr[ch - 'a'])
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
        switch (++_charArr[ch - 'a'])
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
