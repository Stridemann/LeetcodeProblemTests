public class Divide_Two_Integers
{
    [Theory]
    [InlineData(10, 3, 3)]
    [InlineData(7, -3, -2)]
    [InlineData(1, 1, 1)]
    [InlineData(-2147483648, -1, 2147483647)]
    [InlineData(-2147483648, 1, -2147483648)]
    [InlineData(2147483647, 1, 2147483647)]
    [InlineData(2147483647, 2, 1073741823)]
    [InlineData(-2147483648, -2, -1)]
    public void Test(int dividend, int divisor, int expected)
    {
        var s = new Solution();
        var result = s.Divide(dividend, divisor);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int Divide(int dividend, int divisor)
    {
        checked
        {
            if (dividend == int.MaxValue && divisor == -1)
            {
                return int.MinValue;
            }

            if (dividend == int.MaxValue && divisor == 1)
            {
                return int.MaxValue;
            }

            if (dividend == int.MinValue && divisor == -1)
            {
                return int.MaxValue;
            }

            if (dividend == int.MinValue && divisor == 1)
            {
                return int.MinValue;
            }

            var step = Math.Abs(divisor);
            var to = Math.Abs(dividend);
            var counter = -1;

            for (var i = 0; i <= to; )
            {
                counter++;

                if (i > int.MaxValue - step)
                {
                    break;
                }

                i += step;
            }

            var sign = Math.Sign(dividend) * Math.Sign(divisor);

            return counter * sign;
        }
    }
}
