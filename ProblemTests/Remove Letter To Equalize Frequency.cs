using Shouldly;

public class Remove_Letter_To_Equalize_Frequency
{
    [Theory]
    [InlineData("abcc", true)]
    [InlineData("aazz", false)]
    [InlineData("cccaa", true)]
    [InlineData("bac", true)]
    [InlineData("cbbd", true)]
    [InlineData("abbcc", true)]
    [InlineData("zz", true)]
    [InlineData("cccd", true)]
    [InlineData("babbdd", false)]
    public void Test1(string digits, bool expected)
    {
        var s = new Solution();
        var result = s.EqualFrequency(digits);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public bool EqualFrequency(string word)
    {
        var hash = new byte['z' - 'a' + 1];

        foreach (var c in word)
        {
            var index = c - 'a';
            hash[index]++;
        }

        var total = 0;
        var sum = 0;
        var single = 0;

        for (var i = 0; i < hash.Length; i++)
        {
            var cur = hash[i];

            if (cur == 0)
                continue;
            total++;
            sum += cur;

            if (cur == 1)
                single++;
        }

        if (sum == total || total == 1)
            return true;

        var avg = (float)sum / total;
        var one = 1f / total;
        var aR = avg % 1;

        var r = MathF.Min(1 - aR, aR);

        if (r == 0 && single == 1)
            return true;
        var dff = r - one;
        var isOne = Math.Abs(dff) < 0.01f;

        return isOne;
    }
}
