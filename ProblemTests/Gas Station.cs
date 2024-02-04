public class Gas_Station
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5, 1, 2 }, 3)]
    [InlineData(new int[] { 2, 3, 4 }, new int[] { 3, 4, 3 }, -1)]
    [InlineData(new int[] { 5, 8, 2, 8 }, new int[] { 6, 5, 6, 6 }, 3)]
    public void Test(int[] gas, int[] cost, int expected)
    {
        var s = new Solution();
        s.CanCompleteCircuit(gas, cost).ShouldBe(expected);
    }
}

public class Solution
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        var diff = new int[gas.Length];
        var summ = 0;
        var total = 0;
        var start = 0;

        for (int i = 0; i < diff.Length; i++)
        {
            summ += diff[i] = gas[i] - cost[i];
            total += diff[i];

            if (total < 0)
            {
                total = 0;
                start = i + 1;
            }
        }

        if (summ < 0)
            return -1;

        return start;
    }
}
