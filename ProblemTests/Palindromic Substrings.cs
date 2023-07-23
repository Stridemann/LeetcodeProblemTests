using System.Reflection.Metadata;

public class Palindromic_Substrings
{
    [Theory]
    [InlineData("abc", 3)]
    [InlineData("aaa", 6)]
    public void Test(string input, int expected)
    {
        var s = new Solution();
        var result = s.CountSubstrings(input);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int CountSubstrings(string s)
    {
        if (s.Length == 1)
        {
            return 1;
        }

        var T = new (char c, int cnt)[s.Length * 2 + 3];
        T[0].c = '$';
        T[s.Length * 2 + 2].c = '@';

        for (var i = 0; i < s.Length; i++)
        {
            T[2 * i + 1].c = '#';
            T[2 * i + 2].c = s[i];
        }

        T[s.Length * 2 + 1].c = '#';
        ///////////////////////////////////
        int center = 0, right = 0;

        for (var i = 1; i < T.Length - 1; i++)
        {
            var mirr = 2 * center - i;

            if (i < right)
                T[i].cnt = Math.Min(right - i, T[mirr].cnt);

            while (T[i + 1 + T[i].cnt].c == T[i - (1 + T[i].cnt)].c)
                T[i].cnt++;

            if (i + T[i].cnt > right)
            {
                center = i;
                right = i + T[i].cnt;
            }
        }

        ///////////////////////////////////
        var total = 0;

        for (var i = 1; i < T.Length - 1; i++)
        {
            var cnt = T[i].cnt;

            if (cnt == 0)
                continue;

            if (i % 2 == 0) //1,3
            {
                total += (cnt + 1) / 2;
            }
            else //2
            {
                total += cnt / 2;
            }
        }

        return total;
    }
}
