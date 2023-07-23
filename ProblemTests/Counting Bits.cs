public class Counting_Bits
{
    [Theory]
    [InlineData(2, new[] { 0, 1, 1 })]
    [InlineData(5, new[] { 0, 1, 1, 2, 1, 2 })]
    public void Test(int input, int[] expected)
    {
        var s = new Solution();
        var result = s.CountBits(input);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int[] CountBits(int n)
    {
        var result = new int[n + 1];

        for (int i = 0; i <= n; i++)
        {
            result[i] = (int)System.Runtime.Intrinsics.X86.Popcnt.PopCount((uint)i);
        }

        return result;
    }
}
