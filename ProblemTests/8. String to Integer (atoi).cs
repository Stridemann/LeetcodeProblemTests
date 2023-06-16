using Shouldly;

public class String_to_Integer__atoi_
{
    [Theory]
    [InlineData("42", 42)]
    [InlineData(" 42", 42)]
    [InlineData("     -42-29 ", -42)]
    [InlineData("4193 with words", 4193)]
    [InlineData("sdf with words", 0)]
    [InlineData("words and 987", 0)]
    [InlineData("-91283472332", -2147483648)]
    [InlineData("3.14159", 3)]
    [InlineData(".1", 0)]
    [InlineData("+-12", 0)]
    [InlineData("", 0)]
    [InlineData("+", 0)]
    [InlineData("-", 0)]
    [InlineData(".", 0)]
    [InlineData("1", 1)]
    [InlineData("  ", 0)]
    [InlineData("21474836460", 2147483647)]
    [InlineData("  -0012a42", -12)]
    [InlineData("20000000000000000000", 2147483647)]
    [InlineData("  +  413", 0)]
    [InlineData("-9223372036854775809", -2147483648)]
    public void Test(string a, int expected)
    {
        var s = new Solution();
        s.MyAtoi(a).ShouldBe(expected);
    }
}

public class Solution
{
    public int MyAtoi(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }

        if (s.Length == 1)
        {
            if (char.IsDigit(s[0]))
            {
                return s[0] - '0';
            }

            return 0;
        }

        var signIndex = -1;
        var digitStartIndex = -1;
        var digitEndIndex = -1;

        for (var i = 0; i < s.Length; i++)
        {
            var ch = s[i];

            if (char.IsLetter(ch))
            {
                break;
            }

            if (digitStartIndex == -1)
            {
                if (ch == '.')
                {
                    return 0;
                }

                if (char.IsDigit(ch))
                {
                    digitStartIndex = i;
                    digitEndIndex = i;
                }
                else if (ch == '-' || ch == '+')
                {
                    if (signIndex != -1)
                    {
                        return 0;
                    }

                    signIndex = i;
                }
                else if (signIndex != -1)
                {
                    return 0;
                }
            }
            else if (char.IsDigit(ch))
            {
                digitEndIndex = i;
            }
            else
            {
                break;
            }
        }

        if (digitStartIndex == -1)
            return 0;

        int start;
        int end;

        if (signIndex != -1 && signIndex == digitStartIndex - 1)
        {
            start = signIndex;
            end = digitEndIndex - signIndex + 1;
        }
        else
        {
            start = digitStartIndex;
            end = digitEndIndex - digitStartIndex + 1;
        }

        var span = s.AsSpan(start, end);

        if (long.TryParse(span, out var num))
        {
            if (num > int.MaxValue)
            {
                return int.MaxValue;
            }

            if (num < int.MinValue)
            {
                return int.MinValue;
            }

            return (int)num;
        }

        if (span[0] == '-')
            return int.MinValue;

        return int.MaxValue;
    }
}
