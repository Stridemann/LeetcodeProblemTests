using Math = System.Math;

public class Min_Cost_Climbing_Stairs
{
    [Theory]
    [InlineData(new[] { 10, 15, 20 }, 15)]
    [InlineData(new[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 }, 6)]
    [InlineData(new[] { 0, 2, 2, 1 }, 2)]
    [InlineData(new[] { 2, 2, 1 }, 2)]
    public void Test(int[] nums, int expected)
    {
        var s = new Solution();
        var result = s.MinCostClimbingStairs(nums);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int MinCostClimbingStairs(int[] cost)
    {
        if (cost.Length == 2)
            return Math.Min(cost[0], cost[1]);

        for (var i = cost.Length - 3; i >= 0; i--)
        {
            var prev = cost[i + 1];
            var prevprev = cost[i + 2];
            cost[i] += Math.Min(prev, prevprev);
        }

        return Math.Min(cost[0], cost[1]);
    }
}
