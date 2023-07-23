public class Decode_Ways
{
    [Theory]
    [InlineData("12", 2)]
    [InlineData("226", 3)]
    [InlineData("06", 0)]
    [InlineData("10", 1)]
    [InlineData("27", 1)]
    [InlineData("99", 1)]
    [InlineData("2101", 1)]
    [InlineData("10011", 0)]
    public void Test(string input, int expected)
    {
        var s = new Solution();
        var result = s.NumDecodings(input);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    private string _s;
    private Dictionary<int, (bool, int)> _memo = new Dictionary<int, (bool, int)>();

    //public int NumDecodings(string input)
    //{
    //    if (input[0] == '0')
    //        return 0;
    //    _s = input;

    //    if (!Solve(0, out var result))
    //        return 0;

    //    return result + 1;
    //}

    public int NumDecodings(string s)
    {
        if (s.Length == 0)
        {
            return 1;
        }

        int prev = 1;
        int current = s[^1] == '0' ? 0 : 1;

        for (var i = s.Length - 2; i >= 0; i--)
        {
            int temp = 0;

            if (s[i] > '0')
            {
                temp = current;

                if (s[i] < '2' || (s[i] == '2' && s[i + 1] <= '6'))
                {
                    temp += prev;
                }
            }

            prev = current;
            current = temp;
        }

        return current;
    }

    private bool Solve(int pos, out int result)
    {
        if (_memo.TryGetValue(pos, out var memo))
        {
            result = memo.Item2;

            return memo.Item1;
        }

        result = 0;

        if (pos >= _s.Length)
            return true;
        var digit = _s[pos] - '0';

        if (digit == 0)
            return false;

        var num = digit;

        var hasNext = pos < _s.Length - 1;
        var anySolved = false;

        if (hasNext)
        {
            var next = _s[pos + 1] - '0';

            num *= 10;
            num += next;

            if (num <= 26)
            {
                if (Solve(pos + 2, out var s))
                {
                    anySolved = true;

                    if (next != 0)
                        result++;
                    result += s;
                }
            }

            if (next != 0)
            {
                if (Solve(pos + 1, out var s))
                {
                    anySolved = true;
                    result += s;
                }
            }
        }
        else
        {
            if (Solve(pos + 1, out var s))
            {
                anySolved = true;
                result += s;
            }
        }

        _memo[pos] = (anySolved, result);

        return anySolved;
    }
}
