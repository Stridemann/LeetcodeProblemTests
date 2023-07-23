public class Unique_Paths
{
    [Theory]
    [InlineData(3, 7, 28)]
    [InlineData(3, 2, 3)]
    [InlineData(1, 2, 1)]
    [InlineData(10, 10, 48620)]
    [InlineData(23, 12, 193536720)]
    public void Test(int n, int m, int expected)
    {
        var s = new Solution();
        var result = s.UniquePaths(n, m);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int UniquePaths(int m, int n)
    {
        if (m == 0 || n == 0) return 0;
        if (m == 1 || n == 1) return 1;

        var f1 = Factorial((ulong)(m + n - 2));
        var f2 = Factorial((ulong)(m - 1));
        var f3 = Factorial((ulong)(n - 1));

        return (int)(f1 / f2 / f3);
    }

    ulong Factorial(ulong n)
    {
        if (n == 1) return 1;

        return n * Factorial(n - 1);
    }
}
