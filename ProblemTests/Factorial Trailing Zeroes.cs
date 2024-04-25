using System.Numerics;

public class Factorial_Trailing_Zeroes
{
    [Theory]
    [InlineData(3, 0)]
    [InlineData(5, 1)]
    [InlineData(8, 1)]
    [InlineData(13, 2)]
    [InlineData(30, 7)]
    public void Test(int input, int expected)
    {
        var s = new Solution();
        var result = s.TrailingZeroes(input);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int TrailingZeroes(int n)
    {
        //BigInteger cur = 1;

        //for (int i = 1; i <= n; i++)
        //{
        //    cur *= i;
        //}

        //var zeroes = 0;

        //while (cur > 0 && cur % 10 == 0)
        //{
        //    cur /= 10;
        //    zeroes++;
        //}
        //return zeroes;

        int timesZero = 0;
    
        for (int power5 = 5; power5 <= n; power5 *= 5) 
            timesZero += n / power5;

        return timesZero;
    }
}
