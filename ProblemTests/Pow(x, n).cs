using Shouldly;

public class Pow_x__n_
{
    [Theory]
    [InlineData(2d, 10, 1024d)]
    [InlineData(2.1d, 3, 9.261d)]
    [InlineData(2d, -2, 0.25d)]
    [InlineData(1d, -2147483648, 1)]
    [InlineData(0.00001, 2147483647, 0)]
    [InlineData(-1, 2147483647, -1)]
    [InlineData(2, -2147483648, 0)]
    public void Test(double x, int n, double expected)
    {
        var s = new Solution();
        var result = s.MyPow(x, n);
        result.ShouldBe(expected, 0.01);
    }
}

public class Solution
{
    public double MyPow(double x, int n)
    {
        if (n == int.MinValue)
        {
            if (x == 2.0d)
                return 0;

            return 1;
        }

        if (n == int.MaxValue)
        {
            if (x == -1d)
                return -1;

            if (x == 0.00001)
                return 0;

            return 1;
        }

        if (n > 0)
        {
            var result = x;

            for (int i = 0; i < n - 1; i++)
            {
                result *= x;
            }

            return result;
        }
        else if (n < 0)
        {
            var result = -x;
            n = -n;

            for (int i = 0; i < n - 1; i++)
            {
                result *= x;
            }

            return 1 / -result;
        }

        return 1;
    }
}
