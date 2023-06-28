using Shouldly;

public class Trapping_Rain_Water_II
{
    [Theory]
    [InlineData(new[] { -1, 2, 1, -4 }, 2)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.RemoveNthFromEnd(nums, target);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int TrapRainWater(int[][] heightMap)
    {
        var v = new int[h.Length];
        int a = 0;

        for (int i = 0, lMax = 0; i < h.Length; ++i)
        {
            lMax = v[i] = Math.Max(h[i], lMax);
        }

        for (int i = h.Length - 1, rMax = 0; i >= 0; i--)
        {
            rMax = Math.Max(h[i], rMax);
            a += Math.Min(v[i], rMax) - h[i];
        }

        return a;
    }
}
