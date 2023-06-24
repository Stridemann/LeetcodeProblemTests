using Shouldly;

public class Climbing_Stairs
{
    [Theory]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(4, 5)]
    public void Test(int input, int expected)
    {
        var s = new Solution();
        var result = s.ClimbStairs(input);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int ClimbStairs(int n)
    {
        if (n == 1)
        {
            return 1;
        }

        if (n == 2)
        {
            return 2;
        }

        int a = 1, b = 2, c = 0;

        for (int i = 3; i <= n; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }

        return c;
    }
}
