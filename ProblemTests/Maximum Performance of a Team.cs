public class Maximum_Performance_of_a_Team
{
    [Theory]
    [InlineData(new[] { 2, 10, 3, 1, 5, 8 }, new[] { 5, 4, 3, 9, 7, 2 }, 2, 60)]
    [InlineData(new[] { 2, 10, 3, 1, 5, 8 }, new[] { 5, 4, 3, 9, 7, 2 }, 3, 68)]
    public void Test(
        int[] sp,
        int[] e,
        int k,
        int expected)
    {
        var s = new Solution();
        var result = s.MaxPerformance(sp.Length, sp, e, k);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int MaxPerformance(
        int n,
        int[] speed,
        int[] efficiency,
        int k)
    {
        var all = speed.Select((v, i) => (i, speed[i], efficiency[i], v * efficiency[i])).OrderByDescending(x => x.Item4).ToList();
        var max = speed.Select((v, i) => (speed[i], efficiency[i], v * efficiency[i])).OrderByDescending(x => x.Item3).Take(k).ToList();

        return max.Sum(x => x.Item1) * max.Min(x => x.Item2);
    }
}
